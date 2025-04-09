using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefalutMove : MonoBehaviour
{
    // move
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;

    private Vector3 moveVec;
    private float moveX;
    private float moveY;
    private float mouseX;

    // trace
    private Vector3 targetPos;
    private bool isTrace;

    // component
    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if ((Input.GetMouseButton(0))) TargetSetting();
        InputXY();
        Move();
        if (isTrace) MoveToTarget();
    }

    /// Input
    private void InputXY()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
    }

    /// Key Move
    private void Move()
    {
        if(Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            isTrace = false;

        moveVec = (Vector3.right * moveX + Vector3.forward * moveY).normalized;
        rb.velocity = moveVec * moveSpeed;
    }

    /// Target Setting
    public void TargetSetting()
    {
        Vector3 mousePos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000f))
        {
            targetPos = hit.point;
            transform.LookAt(targetPos);

            Quaternion q = transform.localRotation;
            q.x = 0; q.z = 0;
            transform.localRotation = q;
            isTrace = true;
        }
    }

    /// Target Tracing
    private void MoveToTarget()
    {
        if ((targetPos - this.transform.position).magnitude > 1.5f)
            rb.velocity = transform.forward * moveSpeed;
        else
            isTrace = false;
    }
}

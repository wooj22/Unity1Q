using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    private float moveX;
    private float moveY;
    private float mouseX;
    private Vector3 moveVec;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        InputXY();
        Move();
        Rotation();
    }

    private void InputXY()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");
    }

    private void Move()
    {
        moveVec = (transform.right * moveX + transform.forward * moveY).normalized;
        rb.velocity = moveVec * moveSpeed;
    }

    private void Rotation()
    {
        rb.angularVelocity = transform.up * mouseX * rotationSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Debug.Log("æ∆¿Ã≈€ ∏‘¿Ω");
            Destroy(collision.gameObject);
        }
    }
}

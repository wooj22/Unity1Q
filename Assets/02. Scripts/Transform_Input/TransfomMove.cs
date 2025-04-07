using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TransfomMove : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;

    private Vector3 movement;
    private float horizontal;
    private float vertical;

    void Update()
    {
        //Move();
        Move2();
        Rotation();
        LookatTarget();
    }

    void Move()
    {
        if(Input.GetKey(KeyCode.UpArrow))
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow))
            transform.position += transform.forward * -moveSpeed * Time.deltaTime;
    }

    void Move2()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        movement.Set(horizontal, 0, vertical);
        movement.Normalize();

        transform.position += movement * moveSpeed * Time.deltaTime;
    }

    void Rotation()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(transform.up * rotateSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(transform.up * -rotateSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.R))
            transform.RotateAround(Vector3.zero, Vector3.up, 90 * Time.deltaTime);
    }

    void LookatTarget()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            transform.LookAt(target.transform);

            Quaternion q = transform.localRotation;
            q.x = 0; q.z = 0;
            transform.localRotation = q;
        }
    }
}

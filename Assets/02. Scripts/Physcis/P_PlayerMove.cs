using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class P_PlayerMove : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform shootPos;
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
        Cursor.visible = false;
    }
    private void Update()
    {
        Shoot();
    }

    private void FixedUpdate()
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
    
    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0)) {
            GameObject bullet = Instantiate(bulletPrefab, shootPos.position, this.transform.rotation);
            bullet.transform.SetParent(shootPos);        
        }
    }
}

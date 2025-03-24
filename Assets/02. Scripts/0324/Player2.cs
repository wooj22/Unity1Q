using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private float moveX;
    private float moveY;

    private void Update()
    {
        InputKey();
        Move();
    }

    void InputKey()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
    }

    void Move()
    {
        Vector3 move = (transform.right* moveX + transform.forward* moveY).normalized;
        transform.Translate(move * moveSpeed * Time.deltaTime);
    }
}

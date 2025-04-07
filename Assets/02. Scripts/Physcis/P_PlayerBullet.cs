using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_PlayerBullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.velocity = transform.forward * moveSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}

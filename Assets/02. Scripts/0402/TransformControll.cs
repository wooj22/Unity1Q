using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class TransformControll : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform target;

    void Start()
    {
        Vector3 v = Vector3.forward * 2;
        Debug.Log(v.magnitude);     // 길이
        Debug.Log(v.normalized);    // 방향

        this.transform.position = Vector3.zero;
        transform.LookAt(target);
    }

    private void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}

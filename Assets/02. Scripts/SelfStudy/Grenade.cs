using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    private bool isStuck = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (isStuck) return;

        Rigidbody targetRb = collision.rigidbody;

        if (targetRb != null)
        {
            // 고정 조인트 생성
            FixedJoint joint = gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = targetRb;
            isStuck = true;

            Debug.Log("점착!");
        }
    }
}

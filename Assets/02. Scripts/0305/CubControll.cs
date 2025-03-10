using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubControll : MonoBehaviour
{
    private float spinSpeed = 0.1f;

    private void Update()
    {
        Spin();
    }

    void Spin()
    {
        transform.Rotate(spinSpeed, spinSpeed, spinSpeed);
    }

    // 플레이어 충돌
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("플레이어와 닿았다!");
            GameObject.Find("ObManager").GetComponent<ObManager>().RemoveEnemyList();
            GetComponent<BoxCollider>().enabled = false;
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2 : MonoBehaviour
{
    //[SerializeField] private GameObject player;

    void Start()
    {
        //// ���� ������Ʈ find
        ////player = GameObject.Find("Player");
        //Transform transform = player.GetComponent<Transform>();
        //transform.position = new Vector3(0, 0, 0);
        //Debug.Log(player.name);

        //// �±׷� find
        //GameObject tagOb = GameObject.FindGameObjectWithTag("Player");
        //Debug.Log(tagOb.name);

        //// �ڽ� ���� ������Ʈ find
        //Transform cube = this.gameObject.transform.Find("CubeFind");
        //Debug.Log(cube.gameObject.name);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("�÷��̾�� ��Ҵ�!");
            GameObject.Find("ObManager").GetComponent<ObManager>().RemoveEnemyList();
            GetComponent<CapsuleCollider>().enabled = false;
            Destroy(this.gameObject);
        }
    }
}

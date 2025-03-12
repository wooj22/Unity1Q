using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgrammingTest : MonoBehaviour
{
    void Start()
    {   

        // ���̾��Ű â���� ������Ʈ�� ã�� ���� ���� ����ϱ�
        //FindObjectPrint();

        // ������Ʈ ������Ʈ �����ϱ�
        //ObjectComponetControlling();
    }

    void FindObjectPrint()
    {
        GameObject ob = GameObject.Find("House");
        print(ob.name);
        print(ob.tag);

        GameObject ob2 = GameObject.FindGameObjectWithTag("Player");
        print(ob.name + "�� Posistion : " + ob.transform.position);
    }

    void ObjectComponetControlling()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        player.transform.position = new Vector3(1f, 1f, 1f);
        player.transform.rotation = Quaternion.Euler(0, 0, 0);
        player.GetComponent<CapsuleCollider>().enabled = false;
        player.AddComponent<CapsuleCollider>();
        player.SetActive(false);
    }
}

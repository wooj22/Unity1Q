using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgrammingTest : MonoBehaviour
{
    void Start()
    {   

        // 하이어라키 창에서 오브젝트를 찾아 관련 정보 출력하기
        //FindObjectPrint();

        // 오브젝트 컴포넌트 제어하기
        //ObjectComponetControlling();
    }

    void FindObjectPrint()
    {
        GameObject ob = GameObject.Find("House");
        print(ob.name);
        print(ob.tag);

        GameObject ob2 = GameObject.FindGameObjectWithTag("Player");
        print(ob.name + "의 Posistion : " + ob.transform.position);
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

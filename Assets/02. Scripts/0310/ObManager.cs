using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObManager : MonoBehaviour
{
    [SerializeField] public GameObject enemyPrefab;
    [SerializeField] private Transform enemyPrent;
    [SerializeField] private Transform cubePrent;
    [SerializeField] private KeyCode createEnemyKey = KeyCode.C;
    [SerializeField] private KeyCode createObKey = KeyCode.X;
    [SerializeField] private KeyCode deleteKey = KeyCode.D;
    [SerializeField] private List<GameObject> enemyList = new List<GameObject>();

     /// C를 누르면 랜덤한 위치의 enemy 생성
     /// D를 누르면 최근에 생성된 enmey 제거
     /// enemy는 플레이어와 충돌시 콜라이더를 끄고 소멸 (Cubcontroll.cs)
     /// X 를 누르면 기본 오브젝트(큐브 생성), 10초뒤 자동 소멸

    private void Update()
    {
        InputKeyCheaking();
    }

    // key input cheak
    private void InputKeyCheaking()
    {
        if (Input.GetKeyDown(createEnemyKey)) { CreatingEnemy(); }
        if (Input.GetKeyDown(deleteKey)) { DeleteEnemy(); }
        if (Input.GetKeyDown(createObKey)) { CreatingDefulatOb(); }
    }

    // enemy Create
    private void CreatingEnemy()
    {
        float xPos = Random.Range(-10f, 11f);
        float yPos = Random.Range(0, 5f);
        float zPos = Random.Range(-10f, 11f);

        GameObject enemy = Instantiate(enemyPrefab, new Vector3(xPos, yPos, zPos), Quaternion.identity);
        
        enemy.transform.SetParent(enemyPrent);
        enemyList.Add(enemy);

        Debug.Log("enemy ctreating");
    }

    // enemy Destroy
    private void DeleteEnemy()
    {
        Destroy(enemyList[enemyList.Count - 1].gameObject);
        RemoveEnemyList();
    }

    // enemy 리스트 제거
    public void RemoveEnemyList()
    {
        enemyList.RemoveAt(enemyList.Count - 1);
        Debug.Log("enemy delete");
    }

    // 기본오브젝트 생성
    private void CreatingDefulatOb()
    {
        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        obj.transform.SetParent(cubePrent);
        Destroy(this.gameObject, 10f);
    }
}

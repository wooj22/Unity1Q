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

     /// C�� ������ ������ ��ġ�� enemy ����
     /// D�� ������ �ֱٿ� ������ enmey ����
     /// enemy�� �÷��̾�� �浹�� �ݶ��̴��� ���� �Ҹ� (Cubcontroll.cs)
     /// X �� ������ �⺻ ������Ʈ(ť�� ����), 10�ʵ� �ڵ� �Ҹ�

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

    // enemy ����Ʈ ����
    public void RemoveEnemyList()
    {
        enemyList.RemoveAt(enemyList.Count - 1);
        Debug.Log("enemy delete");
    }

    // �⺻������Ʈ ����
    private void CreatingDefulatOb()
    {
        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        obj.transform.SetParent(cubePrent);
        Destroy(this.gameObject, 10f);
    }
}

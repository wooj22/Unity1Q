using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnimation : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private int HP = 100;
    [SerializeField] private int Power = 10;
    private Animator ani;

    private void Start()
    {
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Attack();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            ani.SetBool("isWalk", true);
            this.transform.localRotation  = Quaternion.Euler(0, 0, 0);
            transform.Translate(Vector3.right * -moveSpeed * Time.deltaTime);
        } 
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            ani.SetBool("isWalk", true);
            this.transform.localRotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(Vector3.right * -moveSpeed * Time.deltaTime);
        }
        else
            ani.SetBool("isWalk", false);
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("[Hero] : attack!");
            ani.SetTrigger("Attack");

            float dist = (enemy.transform.position - transform.position).magnitude;
            if (dist <= 4f && this.transform.localPosition.y == 0f)
                enemy.GetComponent<EnemyAnimation>().Hit(Power);
        }
    }

    public void Hit(int damage)
    {
        this.transform.localRotation = Quaternion.Euler(0, 0, 0);

        HP -= damage;
        if (HP < 0) HP = 0;

        if (HP <= 0)
        {
            ani.SetTrigger("Death");
            Debug.Log("[Hero] : die");
            HP = 100;
        }
        else ani.SetTrigger("Damage");
    }
}

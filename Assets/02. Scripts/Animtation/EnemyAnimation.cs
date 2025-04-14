using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private GameObject hero;
    [SerializeField] private int HP = 30;
    [SerializeField] private int Power = 10;
    private Animator ani;

    private void Start()
    {
        ani = GetComponent<Animator>();
        InvokeRepeating(nameof(Attack), 3f, 5f);
    }

    void Attack()
    {
        float dist = (hero.transform.position - transform.position).magnitude;
        if (dist <= 4f)
        {
            Debug.Log("[Enemy] : attack!");
            ani.SetTrigger("Attack");
            hero.GetComponent<HeroAnimation>().Hit(Power);
        }
    }

    public void Hit(int damage)
    {
        HP -= damage;
        if (HP < 0) HP = 0;

        if (HP <= 0) {
            ani.SetTrigger("Death");
            Debug.Log("[Enemy] : die");
            HP = 30;
        } 
        else ani.SetTrigger("Damage");
    }
}

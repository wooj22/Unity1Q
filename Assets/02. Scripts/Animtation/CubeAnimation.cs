using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAnimation : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(AnimationCo());
    }

    IEnumerator AnimationCo()
    {
        animator.SetTrigger("Cube1");
        yield return new WaitForSeconds(5f);

        animator.SetTrigger("Idle");
        yield return new WaitForSeconds(5f);

        animator.SetTrigger("Cube2");
        yield return new WaitForSeconds(5f);

        animator.SetTrigger("Idle");
    }
}

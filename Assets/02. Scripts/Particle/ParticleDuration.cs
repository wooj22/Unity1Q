using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDuration : MonoBehaviour
{
    private ParticleSystem ps;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        StartCoroutine(WaitingAndOff());
    }

    IEnumerator WaitingAndOff()
    {
        yield return new WaitForSeconds(ps.main.duration);
        this.gameObject.SetActive(false);
    }
}

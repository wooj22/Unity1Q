using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] GameObject VFX_Hit;
    [SerializeField] int HitPullingCount;
    private List<GameObject> VFX_HitList = new List<GameObject>();

    private void Start()
    {
        Pulling();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) HitParticle();
    }

    /// object pulling
    void Pulling()
    {
        for(int i=0; i<HitPullingCount; i++)
        {
            GameObject vfx_hit = Instantiate(VFX_Hit);
            vfx_hit.transform.SetParent(this.transform);
            vfx_hit.SetActive(false);
            VFX_HitList.Add(vfx_hit);
        }
    }

    /// particle play
    void HitParticle()
    {
        Vector3 mousePos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000f))
        {
            foreach (GameObject vfx_hit in VFX_HitList)
            {
                if (!vfx_hit.activeInHierarchy)
                {
                    vfx_hit.transform.position = hit.point;
                    vfx_hit.SetActive(true);
                    vfx_hit.GetComponent<ParticleSystem>().Play();
                    break;
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatarialChange : MonoBehaviour
{
    MeshRenderer meshRenderer;


    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        InvokeRepeating((nameof(ColorChange)), 0, 0.5f);
    }

    void ColorChange()
    {
        meshRenderer.material.color = Random.ColorHSV();
    }
}

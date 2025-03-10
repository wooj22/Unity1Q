using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    [SerializeField] GameObject cube;

    // ���� ����
    public void GameStartButton()
    {
        SceneSwitch.Instance.SceneChange("Main");
    }

    // �÷� ����
    public void ChangeMaterial()
    {
        cube.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
}

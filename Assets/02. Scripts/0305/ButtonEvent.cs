using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    [SerializeField] GameObject cube;

    // 게임 시작
    public void GameStartButton()
    {
        SceneSwitch.Instance.SceneChange("Main");
    }

    // 컬러 변경
    public void ChangeMaterial()
    {
        cube.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
}

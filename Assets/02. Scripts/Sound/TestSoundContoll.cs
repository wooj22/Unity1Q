using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSoundContoll : MonoBehaviour
{
    private void Start()
    {
        SoundManager.Instance.SetBGM("bgm_main");
        SoundManager.Instance.FadeInBGM();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) SoundManager.Instance.PlaySFX("snd_shoot");
        if (Input.GetMouseButtonDown(0)) SoundManager.Instance.PlaySFX("snd_ui_click");
    }
}

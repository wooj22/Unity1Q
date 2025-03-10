using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    // �̱���
    public static SceneSwitch Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // �� �ε�
    public void SceneChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

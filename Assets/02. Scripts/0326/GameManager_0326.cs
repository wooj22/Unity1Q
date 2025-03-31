using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_0326 : MonoBehaviour
{
    [SerializeField] private GameObject CarPrefab;
    [SerializeField] private KeyCode createdCarKey = KeyCode.Space;

    private void Start()
    {
        CarPrefab = Resources.Load<GameObject>("Car");
    }

    private void Update()
    {
        InputKeyCheaking();
    }

    private void InputKeyCheaking()
    {
        if (Input.GetKeyDown(createdCarKey)) { CarCreating(); }
    }

    private void CarCreating()
    {
        Instantiate(CarPrefab);
    }
}

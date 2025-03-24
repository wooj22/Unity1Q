using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityLiftCycleTest : MonoBehaviour
{
    /// 유니티 이벤트 함수 (Unity Life Cycle)
    /// 스크립트 실행순서 : 유니티의 게임 루프에 따라 스크립트를 실행
    /// Edit > Project Settings > Script Execution Order
    /// Awake - OnEnable – Start – FixedUpdate - Update – LateUpdate - OnDisable – OnDestroy

    void Awake() { print("Awake " + gameObject.name); }
    void Start() { print("Start " + gameObject.name); }
    void FixedUpdate() { print("FixedUpdate " + gameObject.name); }
    void Update() { print("Update " + gameObject.name); }
    void LateUpdate() { print("LateUpdate " + gameObject.name); }
    void OnEnable() { print("OnEnable " + gameObject.name); }
    void OnDisable() { print("OnDisable " + gameObject.name); }
    private void OnDestroy()
    {
        print("OnDestroy " + gameObject.name);
    }
}

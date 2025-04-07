using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    private float wheelInput;
    private Vector2 wheelDelta;

    void Update()
    {
        InputDebug();
        RayCastHitDebug();
    }

    void InputDebug()
    {
        if (Input.anyKeyDown) Debug.Log("Key Pressed");
        if (Input.GetKeyDown(KeyCode.A)) Debug.Log("A key Down");
        if (Input.GetKey(KeyCode.A)) Debug.Log("A key Pressed");
        if (Input.GetKeyUp(KeyCode.A)) Debug.Log("A key Up");
        if (Input.GetMouseButtonDown(0)) Debug.Log("Mouse Left Button Down");
        if (Input.GetMouseButton(0)) Debug.Log("Mouse Left Button Pressed");
        if (Input.GetMouseButtonUp(0)) Debug.Log("Mouse Left Button Up");

        wheelInput = Input.GetAxis("Mouse ScrollWheel");
        if (wheelInput > 0) Debug.Log("Wheel Input Up");
        else if (wheelDelta.y < 0) Debug.Log("Wheel Input Down");

        wheelDelta = Input.mouseScrollDelta;
        if(wheelDelta.y > 0) Debug.Log("Wheel Input Up");
        else if(wheelDelta.y < 0) Debug.Log("Wheel Input Down");
    }

    void RayCastHitDebug()
    {
        if (Input.GetMouseButton(0))
        {
            // Screen Position
            Vector3 mousePos = Input.mousePosition;
            Debug.Log("Mouse Screen Pos : " + mousePos);

            // screen to world position (Laycast, ÇÇÅ·)
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Hit Object : " + hit.collider.gameObject.name);
                Debug.Log("Hit Point : " + hit.point);
                Debug.Log("Hit Normal : " + hit.normal);
                Debug.Log("Hit Distance : " + hit.distance);
            }
            else
            {
                Debug.Log("No Hit");
            }
        }
    }
}

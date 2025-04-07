using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 쿼터뷰 카메라 오프셋 제어 */
public class CameraControll : MonoBehaviour
{
    public Transform _cameraTransform;
    public Transform _targetTransform;
    public Vector3 targetOffset = new Vector3(0, 1, 0);    //위치
    public float fDistance = 15.0f;                        //Editor 우선 참조
    public float fPitch = 30.0f;
    public float fYaw = 0.0f;

    float minimumX = -360F;
    float maximumX = 360F;
    float minimumY = -0F;   // fPitch max
    float maximumY = 90F;
    float minimumZ = 1F;    // fDistance max
    float maximumZ = 30F;


    private float fVelocity = 0.0f;
    float fDistance_cur;
    float fSmoothTime = 0.1F;   // smooth, smaller is faster.

    private float angleVelocity = 0.0f;
    private float angularSmoothTime = 0.2f;
    private float angularMaxSpeed = 15.0f;


    void Awake()
    {
        if (!_cameraTransform && Camera.main)
            _cameraTransform = Camera.main.transform;
        if (!_cameraTransform)
        {
            Debug.Log("Please assign a camera to the CameraController script.");
            enabled = false;
        }

        if (!_targetTransform)
        {
            Debug.Log("Please assign a target Transform.");
        }

    }

    void Update()
    {
        // 우클릭 카메라 조정
        if (Input.GetMouseButton(1)) 
        {
            fYaw += Input.GetAxis("Mouse X");	
            fPitch -= Input.GetAxis("Mouse Y");
            fPitch = Mathf.Clamp(fPitch, minimumY, maximumY);
        }

        fDistance -= Input.GetAxis("Mouse ScrollWheel");
        fDistance = Mathf.Clamp(fDistance, minimumZ, maximumZ);

        // 좌클릭 위치 Target Setting
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f))
                GetComponent<DefalutMove>().SetTargetRotation(hit.point);
        }
    }

    void LateUpdate()
    {
        if (!_targetTransform) return;

        Quaternion currentRotation = Quaternion.Euler(fPitch, fYaw, 0);

        // target position
        Vector3 targetPos = _targetTransform.position + targetOffset;

        // camera position
        fDistance_cur = Mathf.SmoothDamp(fDistance_cur, fDistance, ref fVelocity, fSmoothTime);
        _cameraTransform.position = targetPos + currentRotation * Vector3.back * fDistance_cur;

        // camera rotation
        Vector3 relativePos = targetPos - _cameraTransform.position;
        _cameraTransform.rotation = Quaternion.LookRotation(relativePos);	
    }
}

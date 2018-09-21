using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    float mouseSensitivity = 10;
    [SerializeField]
    Transform cameraTarget;
    [SerializeField]
    float offsetFromTarget = 2;

    Vector2 pitchMinMax = new Vector2(-40, 85);

    float rotationSmoothTime = 0.05f;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    float yaw;
    float pitch;

    bool lockMouseCursor = true;

    void Start()
    {
        if (lockMouseCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    
    void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
        
        transform.eulerAngles = currentRotation;

        transform.position = cameraTarget.position - transform.forward * offsetFromTarget;
    }
}

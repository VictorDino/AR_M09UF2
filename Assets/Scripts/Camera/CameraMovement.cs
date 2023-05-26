using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerTransform;
    public float sensitivity = 5.0f;
    public float maxYAngle = 80.0f;
    public float minYAngle = -80.0f;

    private Vector2 currentRotation;

    void Start()
    {
        currentRotation = transform.rotation.eulerAngles;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        currentRotation.x += mouseX * sensitivity;
        currentRotation.y -= mouseY * sensitivity;

        currentRotation.y = Mathf.Clamp(currentRotation.y, minYAngle, maxYAngle);

        transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0.0f);
        playerTransform.rotation = Quaternion.Euler(0.0f, currentRotation.x, 0.0f);
    }
}

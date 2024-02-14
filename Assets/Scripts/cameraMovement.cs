using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public float sensitivity = 100f;
    public Transform player;
    float RotationX = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        RotationX -= mouseY; //RotationX = RotationX - mouseY
        RotationX = Mathf.Clamp(RotationX, -90f, 90);

        transform.localRotation = Quaternion.Euler(RotationX, 0, 0);

        player.Rotate(Vector3.up * mouseX);
    }
}

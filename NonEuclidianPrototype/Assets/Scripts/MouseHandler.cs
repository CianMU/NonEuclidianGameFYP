using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandler : MonoBehaviour
{
    // horizontal rotation speed
    public float horizontalSpeed = 1f;
    // vertical rotation speed
    public float verticalSpeed = 1f;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;
    private Camera cam;
    private Transform playerTransform;

    void Start()
    {
        cam = Camera.main;
        playerTransform = GetComponent<Transform>();
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * horizontalSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * verticalSpeed;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        // Im not incredibly statisfied with this, there should be a way to rotate with a parent
        cam.transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);
        playerTransform.eulerAngles = new Vector3(0.0f, yRotation, 0.0f);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraOrbit : MonoBehaviour
{
    [SerializeField]
    private float mouseSensitivity = 3;

    private float rotationY;
    private float rotationX;
    
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float distanceFromTarget = 3;

    private Vector3 currentRotation;
    private Vector3 smoothVelocity = Vector3.zero;
    
    [SerializeField]
    private float smoothTime = 0.2f;

    void Update() {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationY += mouseX;
        rotationX += mouseY;

        rotationX = Mathf.Clamp(rotationX, 0, 40);

        Vector3 nextRotation = new Vector3(rotationX, rotationY);
        currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation, ref smoothVelocity, smoothTime);
        transform.localEulerAngles = currentRotation;

        transform.position = target.position - transform.forward * distanceFromTarget;
    }
}

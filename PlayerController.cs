using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed;

    float inputX, inputY;
    float rotX, rotY;

    [SerializeField]
    Transform PlayerCamera;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        UiManager.instance.SetCurser(false);
    }
    private void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        Vector3 movementDirection = ((PlayerCamera.forward * inputY) + (PlayerCamera.right * inputX));
        movementDirection.y = 0;

        rb.position += movementDirection * Time.deltaTime * speed;

        rotX = Input.GetAxis("Mouse X");
        rotY -= Input.GetAxis("Mouse Y");
        rotY = Mathf.Clamp(rotY, -60, 80);
        transform.rotation *= Quaternion.Euler(0, rotX, 0);
        PlayerCamera.localRotation = Quaternion.Euler(rotY, 0, 0);
    }
}

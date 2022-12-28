using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour {
    // Character Controller
    private CharacterController controller;
    private Vector3 velocity;
    public float speed = 5f;

    // Character View
    public Camera cam;
    private float xRotation = 0f;

    public float xSensitivity = 30f;
    public float ySensitivity = 30f;
    // Start is called before the first frame update
    void Start() {
        controller = GetComponent<CharacterController>();
    }

    // Look Screen
    public void Look(Vector2 input) {
        float mouseX = input.x;
        float mouseY = input.y;

        // Change Camera Rotation
        xRotation -= mouseY * ySensitivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        // Camera & Player rotation
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX * xSensitivity * Time.deltaTime);
    }
    // Move Player
    public void Move(Vector3 input) {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        // Move Player
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
    }
}

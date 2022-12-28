using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {
    // Player
    private PlayerInput playerInput;
    private PlayerInput.OnCameraActions onCamera;

    // Player Class
    private PlayerClass motor;

    // Start is called before the first frame update
    void Awake() {
        playerInput = new PlayerInput();
        onCamera = playerInput.OnCamera;

        // Player Class
        motor = GetComponent<PlayerClass>();

    }

    // Update is called once per frame
    void LateUpdate() {
        // Push vector in event
        motor.Look(onCamera.Look.ReadValue<Vector2>());
    }
    // Enable Input
    private void OnEnable() {
        onCamera.Enable();
    }
    // Disable Input
    private void OnDisable() {
        onCamera.Disable();
    }

    // Look Screen
}

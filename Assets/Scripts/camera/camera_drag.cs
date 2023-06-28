using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class camera_drag : MonoBehaviour {
    
    private Camera main_camera;

    private Vector3 origin;
    private Vector3 difference;

    private bool is_dragging;

    private void Awake() {
        main_camera = Camera.main;
    }

    public void on_drag(InputAction.CallbackContext ctx) {
        if (ctx.started) origin = get_mouse_position();
        is_dragging = ctx.started || ctx.performed;
    }

    private void LateUpdate() {
        // Move the camera based on the dragging difference
        if (is_dragging) {
            difference = get_mouse_position() - transform.position;
            transform.position = origin - difference;
        }
    }

    // Return the mouse position
    private Vector3 get_mouse_position() {
        return main_camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }
}

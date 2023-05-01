using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class camera_drag : MonoBehaviour
{
    
    private Vector3 origin;
    private Vector3 difference;

    private Camera main_camera;

    private bool is_dragging;

    private Vector3 get_mouse_position() {
        return main_camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }

    private void Awake() {
        main_camera = Camera.main;
    }

    public void on_drag(InputAction.CallbackContext ctx) {
        if (ctx.started) origin = get_mouse_position();
        is_dragging = ctx.started || ctx.performed;
    }

    private void LateUpdate() {
        if (is_dragging) {
            difference = get_mouse_position() - transform.position;
            transform.position = origin - difference;
        }
    }


}

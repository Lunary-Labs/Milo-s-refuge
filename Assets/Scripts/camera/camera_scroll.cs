using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_scroll : MonoBehaviour
{
    private Camera main_camera;

    private float min_zoom = 1f;
    private float max_zoom = 5f;

    private float zoom_speed = 0.1f;

    private void Awake() {
        main_camera = Camera.main;
    }

    private void Update() {
        main_camera.orthographicSize -= Input.mouseScrollDelta.y * zoom_speed;

    }

    
}

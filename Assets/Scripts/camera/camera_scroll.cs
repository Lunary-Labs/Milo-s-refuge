using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_scroll : MonoBehaviour {
    private Camera main_camera;

    // Zoom limitations
    private float min_size = 3f;
    private float max_size = 16f;

    private float zoom_speed = 0.5f;

    private void Awake() {
        main_camera = Camera.main;
    }

    private void Update() {
        // Increase / decrease zoom based on mouse inputs
        main_camera.orthographicSize -= Input.mouseScrollDelta.y * zoom_speed;
        main_camera.orthographicSize = Mathf.Clamp(main_camera.orthographicSize, min_size, max_size);
    }
}

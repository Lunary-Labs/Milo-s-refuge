using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour {
  private Camera _mainCamera;
  private float _zoomSpeed = 0.5f;
  private float _minSize = 3f;
  private float _maxSize = 30f;

  private void Awake() {
    _mainCamera = Camera.main;
  }

  private void Update() {
    _mainCamera.orthographicSize -= Input.mouseScrollDelta.y * _zoomSpeed;
    _mainCamera.orthographicSize = Mathf.Clamp(_mainCamera.orthographicSize, _minSize, _maxSize);
  }
}

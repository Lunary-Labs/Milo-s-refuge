using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
  private Vector3 _offset = new Vector3(0f, 0f, -10f);
  private float _smoothSpeed = 0.4f;
  private Vector3 _velocity = Vector3.zero;

  private Transform target;

  void Start() {
    target = GameObject.Find("Character").transform;
  }

  void Update() {
    Vector3 targetPosition = target.position + _offset;
    transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothSpeed);
  }
}

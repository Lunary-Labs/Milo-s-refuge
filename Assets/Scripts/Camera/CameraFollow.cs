using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
  [SerializeField] public Transform Target;
  private Vector3 _offset = new Vector3(0f, 0f, -10f);
  private float _smoothSpeed = 0.4f;
  private Vector3 _velocity = Vector3.zero;

  void Start() {
    Target = GameObject.Find("Character").transform;
  }

  void Update() {
    Vector3 targetPosition = Target.position + _offset;
    transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothSpeed);
  }

  public void SetFocus(Transform newTarget) {
    Target = newTarget;
  }
}

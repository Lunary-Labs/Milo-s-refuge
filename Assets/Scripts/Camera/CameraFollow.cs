using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
  private Vector3 _offset = new Vector3(0f, 0f, -10f);
  private float _smoothSpeed = 0.4f;
  private Vector3 _velocity = Vector3.zero;

  [SerializeField] public Transform target;
  private Transform oldTarget;

  void Start() {
    target = GameObject.Find("Character").transform;
  }

  void Update() {
    Vector3 targetPosition = target.position + _offset;
    transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothSpeed);
  }

  public void SetFocus(Transform newTarget, float duration) {
    oldTarget = target;
    target = newTarget;
    StartCoroutine(ResetTargetAfterDuration(duration));
  }

  private IEnumerator ResetTargetAfterDuration(float duration) {
    yield return new WaitForSeconds(duration);
    target = oldTarget;
  }
}
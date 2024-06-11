using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigTreeAnimation : MonoBehaviour {
  private Animator _animator;
  private float _timeToNextAnimation = 0f;

  void Start() {
    _animator = GetComponent<Animator>();
    _timeToNextAnimation = Random.Range(15f, 40f);
  }

  void Update() {
    _timeToNextAnimation -= Time.deltaTime;
    if (_timeToNextAnimation <= 0) {
      string animationName = Random.Range(0, 2) == 0 ? "MediumTreeBump" : "MediumTreeJiggle";
      _animator.Play(animationName);
      _timeToNextAnimation = Random.Range(15f, 40f);
      StartCoroutine(WaitForAnimation());
    }
  }

  IEnumerator WaitForAnimation() {
    float animationLength = _animator.GetCurrentAnimatorStateInfo(0).length;
    yield return new WaitForSeconds(animationLength);
    _animator.Play("MediumTreeIdle");
  }
}

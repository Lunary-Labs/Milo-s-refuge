using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSleep : MonoBehaviour {
  private Animator _animator;

  void Start() {
    _animator = GetComponent<Animator>();
  }

  void Update() {
    _animator.SetFloat("sleep_time", _animator.GetFloat("sleep_time") + Time.deltaTime);

    if (_animator.GetFloat("sleep_time") > 5) {
      _animator.SetBool("angry", false);
      _animator.SetBool("glasses", false);
      _animator.SetBool("cheer", false);
      _animator.SetBool("love", false);
    }
  }
}

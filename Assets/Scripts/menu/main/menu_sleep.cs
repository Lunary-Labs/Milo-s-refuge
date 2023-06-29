using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_sleep : MonoBehaviour
{

    private Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        animator.SetFloat("sleep_time", animator.GetFloat("sleep_time") + Time.deltaTime);

        if (animator.GetFloat("sleep_time") > 5) {
            animator.SetBool("angry", false);
            animator.SetBool("glasses", false);
            animator.SetBool("cheer", false);
            animator.SetBool("love", false);
        }
    }
}

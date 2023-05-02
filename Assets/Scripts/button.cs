using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Animator animator;
    public float time = 0f;
    public float time_to_sleep = 5f;

    private void Awake() {
        animator = GameObject.Find("milo").GetComponent<Animator>();
    }

    private void Update() {
        time += Time.deltaTime;
        if (time > time_to_sleep) {
            animator.SetBool("sleep", true);
        } else {
            animator.SetBool("sleep", false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        time = 0;
        switch (transform.parent.name) {
            case "play":
                int rand = Random.Range(0, 2);
                switch (rand) {
                    case 0:
                        animator.SetBool("love", true);
                        break;
                    case 1:
                        animator.SetBool("cheer", true);
                        break;
                    default:
                        break;
                }
                break;
            case "options":
                animator.SetBool("glasses", true);
                break;
            case "quit":
                animator.SetBool("angry", true);
                break;
            default:
                break;
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        disable_all_anims();
    }

    void disable_all_anims() {
        animator.SetBool("love", false);
        animator.SetBool("angry", false);
        animator.SetBool("glasses", false);
        animator.SetBool("sleep", false);
        animator.SetBool("cheer", false);
    }
}

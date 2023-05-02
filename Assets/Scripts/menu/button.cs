using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Animator animator;
    private GameObject menu_controller;

    private void Awake() {
        animator = GameObject.Find("milo").GetComponent<Animator>();
        menu_controller = GameObject.Find("menu_controller");
    }

    public void OnPointerEnter(PointerEventData eventData) {
        disable_all_anims();
        // trigger cursor change
        menu_controller.GetComponent<menu_controller>().pointing_cursor();
        switch (transform.parent.name) {
            case "play":
                switch (Random.Range(0, 2)) {
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
        // trigger cursor change
        menu_controller.GetComponent<menu_controller>().standard_cursor();
        disable_all_anims();
    }

    void disable_all_anims() {
        animator.SetBool("love", false);
        animator.SetBool("angry", false);
        animator.SetBool("glasses", false);
        animator.SetBool("cheer", false);
        animator.SetFloat("sleep_time", 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
  public Animator Animator;
  private GameObject _menuController;

  private void Awake() {
    Animator = GameObject.Find("milo").GetComponent<Animator>();
    _menuController = GameObject.Find("menu_controller");
  }

  public void OnPointerEnter(PointerEventData eventData) {
    DisableAllAnims();
    // Trigger cursor change
    _menuController.GetComponent<MenuController>().PointingCursor();
    switch (transform.parent.name) {
      case "play":
        switch (Random.Range(0, 2)) {
          case 0:
            Animator.SetBool("love", true);
            break;
          case 1:
            Animator.SetBool("cheer", true);
            break;
          default:
            break;
        }
        break;
      case "options":
        Animator.SetBool("glasses", true);
        break;
      case "quit":
        Animator.SetBool("angry", true);
        break;
      default:
        break;
    }
  }

  public void OnPointerExit(PointerEventData eventData) {
    // Trigger cursor change
    _menuController.GetComponent<MenuController>().StandardCursor();
    DisableAllAnims();
  }

  void DisableAllAnims() {
    Animator.SetBool("love", false);
    Animator.SetBool("angry", false);
    Animator.SetBool("glasses", false);
    Animator.SetBool("cheer", false);
    Animator.SetFloat("sleep_time", 0);
  }
}

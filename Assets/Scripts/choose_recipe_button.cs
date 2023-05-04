using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class choose_recipe_button : MonoBehaviour
{
    public string recipe_name;
    public string cooker_name;
    public GameObject game_controller;
    public GameObject close;

    void Start () {
        recipe_name = transform.name;
        cooker_name = transform.parent.name;
        game_controller = GameObject.Find("game_manager");
        close = GameObject.Find("close");
    }

    public void on_click() {
        switch (cooker_name)
        {
            case "cooker_1_change":
                game_controller.GetComponent<cooker>().change_recipe_cooker_1(recipe_name);
                break;
            case "cooker_2_change":
                game_controller.GetComponent<cooker>().change_recipe_cooker_2(recipe_name);
                break;
            case "cooker_3_change":
                game_controller.GetComponent<cooker>().change_recipe_cooker_3(recipe_name);
                break;
            default:
                break;
        }
        close.GetComponent<Button>().onClick.Invoke();
    }
}

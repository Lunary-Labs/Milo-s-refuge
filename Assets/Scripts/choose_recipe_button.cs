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
    public GameObject displayer;
    public cooker_displayer displayer_script;

    void Start () {
        recipe_name = transform.name;
        cooker_name = transform.parent.name;
        game_controller = GameObject.Find("game_manager");
        close = GameObject.Find("close");
        displayer = transform.parent.parent.parent.parent.Find("cooker_ui").Find("Viewport").Find("Content").gameObject;
    }

    public void on_click() {
        switch (cooker_name)
        {
            case "cooker_1_change":
                game_controller.GetComponent<cooker>().change_recipe(recipe_name, 0);
                break;
            case "cooker_2_change":
                game_controller.GetComponent<cooker>().change_recipe(recipe_name, 1);
                break;
            case "cooker_3_change":
                game_controller.GetComponent<cooker>().change_recipe(recipe_name, 2);
                break;
            default:
                break;
        }
        
        displayer_script = displayer.GetComponent<cooker_displayer>();
        displayer_script.display_cooker();

        close.GetComponent<Button>().onClick.Invoke();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class choose_recipe_button : MonoBehaviour
{
    public GameObject menu_manager;
    public menu_cooker script_menu_cooker;

    public string recipe_name;
    public string cooker_name;
    public GameObject game_controller;
    public GameObject displayer;

    void Start () {
        recipe_name = transform.name;
        cooker_name = transform.parent.name;
        game_controller = GameObject.Find("game_manager");
        menu_manager = GameObject.Find("menu_manager");
    }
 
    public void on_click() {
        script_menu_cooker = menu_manager.GetComponent<menu_cooker>();
        script_menu_cooker.delete_recipe_list();
        script_menu_cooker.change_recipe_cooker(recipe_name,script_menu_cooker.current_cooker);
        script_menu_cooker.display_cooker();
        script_menu_cooker.state_change_recipe_ui(false);
        script_menu_cooker.state_cooker_ui(true);
    }
}
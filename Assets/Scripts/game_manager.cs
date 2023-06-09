using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_manager : MonoBehaviour
{
    
    private GameObject island_manager;
    private GameObject menu_manager;

    void Start() {
        // Call script in the correct order to prevent errors.
        island_manager = GameObject.Find("game_manager");
        menu_manager = GameObject.Find("menu_manager");

        island_manager.GetComponent<island_manager>().instatiate_islands();
        menu_manager.GetComponent<unlock_button_manager>().generate_unlock_buttons();
    }
}

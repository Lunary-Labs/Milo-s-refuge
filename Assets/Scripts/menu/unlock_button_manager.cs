using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class unlock_button_manager : MonoBehaviour
{

    GameObject unlock_buttons;
    GameObject game_manager;
    GameObject world;

    public void generate_unlock_buttons() {
        unlock_buttons = GameObject.Find("unlock_buttons");
        game_manager = GameObject.Find("game_manager");
        world = GameObject.Find("world");

        foreach (Transform island in world.transform.Find("islands")) {
            // instantiate unlock button if island is level 0
            if (game_manager.GetComponent<island_manager>().island_levels[island.name].level == 0) {
                GameObject unlock_button_prefab = Resources.Load<GameObject>("Prefabs/menu/unlock_button");
                GameObject unlock_button_instance = Instantiate(unlock_button_prefab, unlock_buttons.transform);
                unlock_button_instance.name = island.name + "_unlock";

                Vector3 position = island.transform.Find("unlock_button_position").position;
                Vector3 position_canvas = Camera.main.WorldToScreenPoint(position);
                Vector3 position_world = Camera.main.ScreenToWorldPoint(position_canvas);
                position_world.z = 0;
                unlock_button_instance.transform.position = position_world;

                // Set the text to display the correct price
                int cost = game_manager.GetComponent<island_manager>().island_data[island.name].unlock_cost;
                unlock_button_instance.transform.Find("text").GetComponent<TMPro.TextMeshProUGUI>().text = cost.ToString();
            }
        }
    }
}

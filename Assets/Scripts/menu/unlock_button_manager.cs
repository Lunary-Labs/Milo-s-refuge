using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlock_button_manager : MonoBehaviour
{

    GameObject unlock_buttons;
    GameObject character;
    GameObject world;

    public void generate_unlock_buttons() {
        unlock_buttons = GameObject.Find("unlock_buttons");
        character = GameObject.Find("game_manager");
        world = GameObject.Find("world");

        foreach (Transform island in world.transform.Find("islands")) {
            // instantiate unlock button if island is level 0
            if (character.GetComponent<island_manager>().island_levels[island.name] == 0) {
                GameObject unlock_button_prefab = Resources.Load<GameObject>("Prefabs/menu/unlock_button");
                GameObject unlock_button_instance = Instantiate(unlock_button_prefab, unlock_buttons.transform);
                unlock_button_instance.name = island.name + "_unlock";

                Vector3 position = island.transform.Find("unlock_button_position").position;
                Vector3 position_canvas = Camera.main.WorldToScreenPoint(position);
                Vector3 position_world = Camera.main.ScreenToWorldPoint(position_canvas);
                position_world.z = 0;
                unlock_button_instance.transform.position = position_world;
            }
        }
    }

    void Update() {
        
    }
}

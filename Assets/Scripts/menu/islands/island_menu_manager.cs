using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class island_menu_manager : MonoBehaviour {
    
    private GameObject menu;
    private GameObject game_manager;

    /* Menu elements */
    public GameObject title;
    public GameObject island_cost_1;
    public GameObject island_cost_2;
    public Slider island_level_slider;

    public GameObject boat_cost;

    public GameObject growth_cost;

    public GameObject harvest_cost;

    public string current_island;

    void Start() {
        menu = FindInactiveObjectByName("island_menu");
        game_manager = GameObject.Find("game_manager");
        title = menu.transform.Find("title").gameObject;

    }

    public void open_menu(string island_name) {
        current_island = island_name;
        menu.SetActive(true);
    }

    public void close_menu() {
        current_island = "";
        menu.SetActive(false);
    }

    public void main_upgrade() {
        game_manager.GetComponent<island_manager>().upgrade_island(current_island);
    }

    public void boat_upgrade() {
        game_manager.GetComponent<island_manager>().upgrade_boat(current_island);
    }

    public void harvest_upgrade() {
        game_manager.GetComponent<island_manager>().upgrade_harvest(current_island);
    }

    public void growth_upgrade() {
        game_manager.GetComponent<island_manager>().upgrade_growth(current_island);
    }


    // Used to find the memu that is inactive by default
    GameObject FindInactiveObjectByName(string name) {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++) {
            if (objs[i].hideFlags == HideFlags.None) {
                if (objs[i].name == name) {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class island_menu_manager : MonoBehaviour {
    
    private GameObject menu;
    private GameObject game_manager;

    /* Menu elements */
    public GameObject title;
    public GameObject island_wood_cost;
    public GameObject island_stone_cost;

    public GameObject boat_cost;

    public GameObject growth_cost;

    public GameObject harvest_cost;

    public string current_island;

    void Start() {
        menu = FindInactiveObjectByName("island_menu");
        game_manager = GameObject.Find("game_manager");
        title = menu.transform.Find("main").transform.Find("title").gameObject;
        island_wood_cost = menu.transform.Find("main").transform.Find("wood_cost").gameObject;
        island_stone_cost = menu.transform.Find("main").transform.Find("stone_cost").gameObject;
        boat_cost = menu.transform.Find("boat").transform.Find("cost").gameObject;
        growth_cost = menu.transform.Find("growth").transform.Find("cost").gameObject;
        harvest_cost = menu.transform.Find("harvest").transform.Find("cost").gameObject;
    }

    public void open_menu(string island_name) {
        current_island = island_name;
        refresh_values();
        menu.SetActive(true);
    }

    public void refresh_values() {
        title.GetComponent<TextMeshProUGUI>().text = current_island;
        island_wood_cost.GetComponent<TextMeshProUGUI>().text = game_manager.GetComponent<island_manager>().island_data[current_island].wood_cost.ToString();
        island_stone_cost.GetComponent<TextMeshProUGUI>().text = game_manager.GetComponent<island_manager>().island_data[current_island].wood_cost.ToString();
        boat_cost.GetComponent<TextMeshProUGUI>().text = game_manager.GetComponent<island_manager>().island_data[current_island].boat_cost.ToString();
        growth_cost.GetComponent<TextMeshProUGUI>().text = game_manager.GetComponent<island_manager>().island_data[current_island].growing_cost.ToString();
        harvest_cost.GetComponent<TextMeshProUGUI>().text = game_manager.GetComponent<island_manager>().island_data[current_island].harvest_cost.ToString();
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

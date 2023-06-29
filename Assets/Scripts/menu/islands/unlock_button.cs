using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlock_button : MonoBehaviour {

    public GameObject game_manager;

    void Start() {
        game_manager = GameObject.Find("game_manager");
    }

    public void on_click() {
        string island_name = transform.name.Substring(0, transform.name.IndexOf("_unlock"));
        game_manager.GetComponent<island_manager>().upgrade_island(island_name);
        Destroy(transform.gameObject);
    }
}

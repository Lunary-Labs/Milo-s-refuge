using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class island : MonoBehaviour {

    public List<GameObject> fields = new List<GameObject>();
    public TilemapCollider2D[] child_tilemap_colliders;
    public Transform workbench;

    // Ressource stock
    public Dictionary<string, int> ressources = new Dictionary<string, int>();
    public int total_island_ressources;

    void Start() {
        // Fill the ressources dictionary with all the ressources
        ressources.Add("wheat", 0);
        ressources.Add("carrot", 0);
        ressources.Add("tomato", 0);
        ressources.Add("corn", 0);
        ressources.Add("eggplant", 0);
        ressources.Add("cabbage", 0);
        ressources.Add("salad", 0);
        ressources.Add("pumpkin", 0);
        ressources.Add("pickle", 0);
        ressources.Add("radish", 0);
        ressources.Add("sugar_cane", 0);
        ressources.Add("milk", 0);
        ressources.Add("eggs", 0);
        ressources.Add("wool", 0);
        ressources.Add("honey", 0);
        ressources.Add("wood", 0);
        ressources.Add("stone", 0);
        ressources.Add("iron", 0);
    
        // Get all fields GameObject
        foreach (Transform child in transform) {
            if (child.name == "field") {
                fields.Add(child.gameObject);
            }
        }

        child_tilemap_colliders = GetComponentsInChildren<TilemapCollider2D>();
        workbench = transform.Find("workbench");
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // check if the mouse is over a field tilemap collider
            foreach (TilemapCollider2D tilemap_collider in child_tilemap_colliders) {
                if (tilemap_collider.OverlapPoint(mouse_position) && tilemap_collider.gameObject.name == "field") {
                    tilemap_collider.gameObject.GetComponent<field>().harvest();
                }
            }
            // check if the mouse is over the workbench box collider
            if (workbench != null) {
                if (workbench.GetComponent<BoxCollider2D>().OverlapPoint(mouse_position)) {
                    GameObject.Find("menu_manager").GetComponent<island_menu_manager>().open_menu(transform.name);
                }
            }
        }
        total_island_ressources = 0;
        foreach (var pair in ressources) {
            total_island_ressources += pair.Value;
        }
    }

    // Harvest all the fields of the island and add ressources to stock.
    public void harvest () {
        foreach (GameObject field in fields) {
            field.GetComponent<field>().harvest();
        }
    }
}

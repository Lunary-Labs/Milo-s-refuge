using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class island : MonoBehaviour
{
    public List<GameObject> fields = new List<GameObject>();
    public List<GameObject> cats = new List<GameObject>();
    public TilemapCollider2D[] child_tilemap_colliders;

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
    
        foreach (Transform child in transform) {
            if (child.name == "field") {
                fields.Add(child.gameObject);
            } else if (child.name == "cat") {
                cats.Add(child.gameObject);
            }
        }
        child_tilemap_colliders = GetComponentsInChildren<TilemapCollider2D>();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            // get mouse position
            Vector3 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            foreach (TilemapCollider2D tilemap_collider in child_tilemap_colliders) {
                // check if the mouse is over a field tilemap collider
                if (tilemap_collider.OverlapPoint(mouse_position) && tilemap_collider.gameObject.name == "field") {
                    harvest();
                }
                // check if the mouse is over the workbench tilemap collider
                else if (tilemap_collider.OverlapPoint(mouse_position) && tilemap_collider.gameObject.name == "workbench") {
                    GameObject.Find("game_manager").GetComponent<island_manager>().upgrade_island(transform.gameObject.name);
                }
            }

            
        }
        total_island_ressources = 0;
        foreach (var pair in ressources) {
            total_island_ressources += pair.Value;
        }
    }

    public void harvest () {
        foreach (GameObject field in fields) {
            List<GameObject> field_tiles = field.GetComponent<field>().field_tiles;
            foreach (GameObject tile in field_tiles) {
                if (tile.GetComponent<field_tile>().harvestable) {
                    ressources[tile.name] += 1;
                    tile.GetComponent<field_tile>().harvest();
                }
            }
        }
    }
}

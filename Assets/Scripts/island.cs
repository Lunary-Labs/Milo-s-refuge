using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class island : MonoBehaviour
{
    public List<GameObject> fields = new List<GameObject>();
    public List<GameObject> cats = new List<GameObject>();
    private TilemapCollider2D[] child_tilemap_colliders;

    public int weath = 0;
    public int milk = 0;

    void Start() {
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

            // check if the mouse is over a tilemap collider
            foreach (TilemapCollider2D tilemap_collider in child_tilemap_colliders) {
                if (tilemap_collider.OverlapPoint(mouse_position)) {
                    harvest();
                }
            }
        }
    }

    void harvest () {
        foreach (GameObject field in fields) {
            List<GameObject> field_tiles = field.GetComponent<field>().field_tiles;
            foreach (GameObject tile in field_tiles) {
                if (tile.GetComponent<field_tile>().harvestable) {
                    if (tile.name == "wheat") {
                        weath += 1;
                    } else if (tile.name == "milk") {
                        milk += 1;
                    }
                    tile.GetComponent<field_tile>().harvest();
                }
            }
        }
    }
}

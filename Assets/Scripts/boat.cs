using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boat : MonoBehaviour
{
    private GameObject character;

    private GameObject main_island_dock;
    private GameObject island_dock;

    private int stock_size = 10;
    private int stock = 0;

    public int milk = 0;
    public int wheat = 0;

    private float dest_x;
    private float dest_y;

    private float speed = 2;

    void Start() {
        main_island_dock = GameObject.Find("main_island_dock");
        island_dock = transform.parent.gameObject.transform.Find("dock").gameObject;
        dest_x = main_island_dock.transform.position.x;
        dest_y = main_island_dock.transform.position.y;
        character = GameObject.Find("character");
    }

    void Update() {
        move();
    }

    public void set_path(float destination_x, float destination_y) {
        dest_x = destination_x;
        dest_y = destination_y;
    }

    public void move() {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(dest_x, dest_y, 0), step);
        if (transform.position.x == dest_x && transform.position.y == dest_y) {
            if (dest_x == main_island_dock.transform.position.x && dest_y == main_island_dock.transform.position.y) {
                dest_x = island_dock.transform.position.x;
                dest_y = island_dock.transform.position.y;
                unload();
            } else if (dest_x == island_dock.transform.position.x && dest_y == island_dock.transform.position.y) {
                dest_x = main_island_dock.transform.position.x;
                dest_y = main_island_dock.transform.position.y;
                load();
            }
        }
    }

    private void load() {

    }

    private void unload() {
    }
}

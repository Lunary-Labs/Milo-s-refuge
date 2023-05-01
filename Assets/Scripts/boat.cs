using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boat : MonoBehaviour
{
    private GameObject character;

    public GameObject island;
    private GameObject main_island_dock;
    private GameObject island_dock;

    private int max_stock = 10;
    private int stock = 0;

    public int milk = 0;
    public int wheat = 0;

    private float dest_x;
    private float dest_y;

    private float speed = 10;

    public bool loading = false;
    public bool unloading = false;
    private float charge_time = 0f;
    private float charge_timer = 2f;

    void Start() {
        main_island_dock = GameObject.Find("main_island_dock");
        island_dock = transform.parent.gameObject.transform.Find("dock").gameObject;
        dest_x = main_island_dock.transform.position.x;
        dest_y = main_island_dock.transform.position.y;
        character = GameObject.Find("character");
        island = transform.parent.gameObject;
    }

    void Update() {
        move();
        if (loading || unloading) {
            charge_time += Time.deltaTime;
            if (charge_time >= charge_timer) {
                loading = false;
                unloading = false;
                charge_time = 0f;
            }
        }
    }

    public void set_path(float destination_x, float destination_y) {
        dest_x = destination_x;
        dest_y = destination_y;
    }

    public void move() {
        if (!loading && !unloading) {
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
    }

    // not well written, need to remove all GetComponent<island>()(island) and replace it with a reference so we don't recompute it every time
    // need to handle every type of ressources and not only wheat and milk
    // so probably going to use a dictionnary
    private void load() {
        int total_island_ressources = island.GetComponent<island>().milk + island.GetComponent<island>().weath;

        while (stock < max_stock && total_island_ressources > 0) {
            if (island.GetComponent<island>().weath > 0) {
                wheat += 1;
                island.GetComponent<island>().weath -= 1;
                total_island_ressources -= 1;
                stock += 1;
            }
            if (island.GetComponent<island>().milk > 0) {
                milk += 1;
                island.GetComponent<island>().milk -= 1;
                total_island_ressources -= 1;
                stock += 1;
            }
        }
        loading = true;
    }

    private void unload() {
        character.GetComponent<character>().add_milk(milk);
        character.GetComponent<character>().add_wheat(wheat);
        milk = 0;
        wheat = 0;
        stock = 0;
        unloading = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boat : MonoBehaviour
{
    private GameObject game_manager;
    public GameObject island;
    private GameObject main_island_dock;
    private GameObject island_dock;
    private Animator animator;

    public Dictionary<string, int> ressources = new Dictionary<string, int>();

    // Boat caracteristics
    public int max_stock = 10;
    public int stock = 0;
    private float speed = 10f;

    // next destination position
    public float dest_x;
    public float dest_y;

    // Loading/Unloading variables
    public bool loading = false;
    public bool unloading = false;
    public float charge_time = 0f;
    public float charge_timer = 2f;

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

        main_island_dock = GameObject.Find("main_island_dock");
        island_dock = transform.parent.gameObject.transform.Find("dock").gameObject;

        dest_x = main_island_dock.transform.position.x;
        dest_y = main_island_dock.transform.position.y;

        game_manager = GameObject.Find("game_manager");

        island = transform.parent.gameObject;
        animator = GetComponent<Animator>();
    }

    void Update() {
        move();
        if (loading || unloading) {
            charge_time += Time.deltaTime;
            if (charge_time >= charge_timer) {
                loading = false;
                unloading = false;
                charge_time = 0f;
                animator.SetBool("docked", false);
                animator.SetBool("moving", true);
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
            if (Mathf.Abs(transform.position.x - dest_x) < 0.1 && Mathf.Abs(transform.position.y - dest_y) < 0.1) {
                if (Mathf.Abs(dest_x - main_island_dock.transform.position.x) < 0.1 && Mathf.Abs(dest_y - main_island_dock.transform.position.y) < 0.1) {
                    dest_x = island_dock.transform.position.x;
                    dest_y = island_dock.transform.position.y;
                    unload();
                } else if (Mathf.Abs(dest_x - island_dock.transform.position.x) < 0.1 && Mathf.Abs(dest_y - island_dock.transform.position.y) < 0.1) {
                    dest_x = main_island_dock.transform.position.x;
                    dest_y = main_island_dock.transform.position.y;
                    load();
                }
            }
        }
    }

    // need to find a way to remove all the if statements, very bad way to do it actually
    // probably going to use a dictionary, but all scripts involving ressources will need to be changed
    private void load() {
        int total_island_ressources = island.GetComponent<island>().total_island_ressources;
        animator.SetBool("docked", true);
        animator.SetBool("moving", false);
        while (stock < max_stock && total_island_ressources > 0) {
            Dictionary<string, int> island_ressources = island.GetComponent<island>().ressources;
            List<string> keys = new List<string>(ressources.Keys);
            foreach (string key in keys) {
                if (island_ressources[key] > 0) {
                    ressources[key] += 1;
                    island_ressources[key] -= 1;
                    total_island_ressources -= 1;
                    stock += 1;
                    break;
                }
            }
        }
        loading = true;
        float boxes = 0;
        if (stock != 0) {
            boxes = (int)((float)stock / max_stock * 2) + 1;
        }
        animator.SetInteger("boxes", (int)boxes);
    }

    private void unload() {
        animator.SetBool("docked", true);
        animator.SetBool("moving", false);
        animator.SetInteger("boxes", 0);
        stock = 0;
        List<string> keys = new List<string>(ressources.Keys);
        foreach (string key in keys) {
            game_manager.GetComponent<character>().change_ressource(key, ressources[key]);
            ressources[key] = 0;
        }
        unloading = true;
    }
}

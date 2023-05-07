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

    // Boat caracteristics
    public int max_stock = 10;
    public int stock = 0;
    private float speed = 10f;

    // ressources
    private int wheat = 0;
    private int carrot = 0;
    private int tomato = 0;
    private int corn = 0;
    private int eggplant = 0;
    private int cabbage = 0;
    private int salad = 0;
    private int pumpkin = 0;
    private int pickle = 0;
    private int radish = 0;
    private int sugar_cane = 0;

    // animals
    private int milk = 0;
    private int eggs = 0;
    private int wool = 0;
    private int honey = 0;

    // materials
    private int wood = 0;
    private int stone = 0;
    private int iron = 0;

    // next destination position
    public float dest_x;
    public float dest_y;

    // Loading/Unloading variables
    public bool loading = false;
    public bool unloading = false;
    public float charge_time = 0f;
    public float charge_timer = 2f;

    void Start() {
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
            if (island.GetComponent<island>().wheat > 0) {
                wheat += 1;
                island.GetComponent<island>().wheat -= 1;
                total_island_ressources -= 1;
                stock += 1;
            }
            if (island.GetComponent<island>().carrot > 0) {
                carrot += 1;
                island.GetComponent<island>().carrot -= 1;
                total_island_ressources -= 1;
                stock += 1;
            }
            if (island.GetComponent<island>().tomato > 0) {
                tomato += 1;
                island.GetComponent<island>().tomato -= 1;
                total_island_ressources -= 1;
                stock += 1;
            }
            if (island.GetComponent<island>().corn > 0) {
                corn += 1;
                island.GetComponent<island>().corn -= 1;
                total_island_ressources -= 1;
                stock += 1;
            }
            if (island.GetComponent<island>().eggplant > 0) {
                eggplant += 1;
                island.GetComponent<island>().eggplant -= 1;
                total_island_ressources -= 1;
                stock += 1;
            }
            if (island.GetComponent<island>().cabbage > 0) {
                cabbage += 1;
                island.GetComponent<island>().cabbage -= 1;
                total_island_ressources -= 1;
                stock += 1;
            }
            if (island.GetComponent<island>().salad > 0) {
                salad += 1;
                island.GetComponent<island>().salad -= 1;
                total_island_ressources -= 1;
                stock += 1;
            }
            if (island.GetComponent<island>().pumpkin > 0) {
                pumpkin += 1;
                island.GetComponent<island>().pumpkin -= 1;
                total_island_ressources -= 1;
                stock += 1;
            }
            if (island.GetComponent<island>().pickle > 0) {
                pickle += 1;
                island.GetComponent<island>().pickle -= 1;
                total_island_ressources -= 1;
                stock += 1;
            }
            if (island.GetComponent<island>().radish > 0) {
                radish += 1;
                island.GetComponent<island>().radish -= 1;
                total_island_ressources -= 1;
                stock += 1;
            }
            if (island.GetComponent<island>().sugar_cane > 0) {
                sugar_cane += 1;
                island.GetComponent<island>().sugar_cane -= 1;
                total_island_ressources -= 1;
                stock += 1;
            }
            if (island.GetComponent<island>().milk > 0) {
                milk += 1;
                island.GetComponent<island>().milk -= 1;
                total_island_ressources -= 1;
                stock += 1;
            }
            if (island.GetComponent<island>().honey > 0) {
                honey += 1;
                island.GetComponent<island>().honey -= 1;
                total_island_ressources -= 1;
                stock += 1;
            }
            if (island.GetComponent<island>().wool > 0) {
                wool += 1;
                island.GetComponent<island>().wool -= 1;
                total_island_ressources -= 1;
                stock += 1;
            }
            if (island.GetComponent<island>().eggs > 0) {
                eggs += 1;
                island.GetComponent<island>().eggs -= 1;
                total_island_ressources -= 1;
                stock += 1;
            }
            if (island.GetComponent<island>().wood > 0) {
                wood += 1;
                island.GetComponent<island>().wood -= 1;
                total_island_ressources -= 1;
                stock += 1;
            }
            if (island.GetComponent<island>().stone > 0) {
                stone += 1;
                island.GetComponent<island>().stone -= 1;
                total_island_ressources -= 1;
                stock += 1;
            } 
            if (island.GetComponent<island>().iron > 0) {
                iron += 1;
                island.GetComponent<island>().iron -= 1;
                total_island_ressources -= 1;
                stock += 1;
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
        game_manager.GetComponent<character>().change_ressource("wheat", wheat);
        game_manager.GetComponent<character>().change_ressource("carrot", carrot);
        game_manager.GetComponent<character>().change_ressource("tomato", tomato);
        game_manager.GetComponent<character>().change_ressource("corn", corn);
        game_manager.GetComponent<character>().change_ressource("eggplant", eggplant);
        game_manager.GetComponent<character>().change_ressource("cabbage", cabbage);
        game_manager.GetComponent<character>().change_ressource("salad", salad);
        game_manager.GetComponent<character>().change_ressource("pumpkin", pumpkin);
        game_manager.GetComponent<character>().change_ressource("pickle", pickle);
        game_manager.GetComponent<character>().change_ressource("radish", radish);
        game_manager.GetComponent<character>().change_ressource("sugar_cane", sugar_cane);
        game_manager.GetComponent<character>().change_ressource("milk", milk);
        game_manager.GetComponent<character>().change_ressource("honey", honey);
        game_manager.GetComponent<character>().change_ressource("wool", wool);
        game_manager.GetComponent<character>().change_ressource("eggs", eggs);
        game_manager.GetComponent<character>().change_ressource("wood", wood);
        game_manager.GetComponent<character>().change_ressource("stone", stone);
        game_manager.GetComponent<character>().change_ressource("iron", iron);
        wheat = 0;
        carrot = 0;
        tomato = 0;
        corn = 0;
        eggplant = 0;
        cabbage = 0;
        salad = 0;
        pumpkin = 0;
        pickle = 0;
        radish = 0;
        sugar_cane = 0;
        milk = 0;
        honey = 0;
        wool = 0;   
        eggs = 0;
        wood = 0;
        stone = 0;
        iron = 0;
        stock = 0;
        unloading = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class field : MonoBehaviour
{
    public GameObject ressource;
    public List<GameObject> field_tiles = new List<GameObject>();

    // Basic growth and gather speed
    private float base_growth_speed = 0.1f;
    private float base_gather_speed = 1f;

    private float growth_speed;
    private float gather_speed;

    // Temporary buffs
    private float fertilizer_mutliplier = 2f;
    private bool is_fertilized = false;
    private float fertilized_time_remaining = 0f;

    private float fed_multiplier = 2f;
    private bool is_fed = false;
    private float fed_time_remaining = 0f;

    void Start() {
        foreach (Transform child in transform)
        {
            if (child.name == "wheat" || child.name == "milk")
                field_tiles.Add(child.gameObject);
        }

        growth_speed = base_growth_speed;
        gather_speed = base_gather_speed;
    }

    void Update() {

        // Grow random ressources
        foreach (GameObject child in field_tiles) {
            child.GetComponent<field_tile>().grow(growth_speed * Time.deltaTime);
        }

        // If field is fertilized, grow faster
        if (is_fertilized) {
            growth_speed = base_growth_speed * fertilizer_mutliplier;
            fertilized_time_remaining -= Time.deltaTime;
            if (fertilized_time_remaining <= 0) {
                is_fertilized = false;
                growth_speed = base_growth_speed;
            }
        }

        // If cats are fed, gather faster
        if (is_fed) {
            gather_speed = base_gather_speed * fed_multiplier;
            fed_time_remaining -= Time.deltaTime;
            if (fed_time_remaining <= 0) {
                is_fed = false;
                gather_speed = base_gather_speed;
            }
        }
    }

    void harvest() {
        foreach (GameObject child in field_tiles) {
            child.GetComponent<field_tile>().harvest();
        }
    }

    void fertilize () {
        is_fertilized = true;
        fertilized_time_remaining = 10f;
    }

    void feed () {
        is_fed = true;
        fed_time_remaining = 10f;
    }
}
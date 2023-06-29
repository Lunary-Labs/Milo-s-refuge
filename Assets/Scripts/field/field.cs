using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class field : MonoBehaviour {
    
    public List<GameObject> field_tiles = new List<GameObject>();

    // Basic growth and gather speed
    private float base_growth_speed = 1f;
    private float base_gather_speed = 2f;

    private float growth_speed;
    private float gather_speed;

    // Auto harvest
    private bool auto_harvest = true;
    private float next_harvest_timer = 0f;
    private float harvest_timer = 0f;

    // Temporary buffs
    private float fertilizer_mutliplier = 2f;
    private bool is_fertilized = false;
    private float fertilized_time_remaining = 0f;

    private float fed_multiplier = 2f;
    private bool is_fed = false;
    private float fed_time_remaining = 0f;

    void Start() {
        foreach (Transform child in transform) {
            field_tiles.Add(child.gameObject);
        }
        growth_speed = base_growth_speed;
        gather_speed = base_gather_speed;
    }

    void Update() {
        // Auto harvest handling
        if (auto_harvest) {
            harvest_timer += Time.deltaTime;
            if (harvest_timer >= next_harvest_timer) {
                random_harvest();
                harvest_timer = 0f;
                next_harvest_timer = 3 / gather_speed;
            }
        }

        // Grow ressources
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

    // Harvest all child tiles of the field.
    void harvest() {
        foreach (GameObject child in field_tiles) {
            child.GetComponent<field_tile>().harvest();
        }
    }

    // Randomly harvest a tile on the field.
    void random_harvest() {
        List<GameObject> harvestable_tiles = new List<GameObject>();
        foreach (GameObject child in field_tiles) {
            if (child.GetComponent<field_tile>().harvestable)
                harvestable_tiles.Add(child);
        }
        if (harvestable_tiles.Count > 0) {
            int random_index = Random.Range(0, harvestable_tiles.Count);
            harvestable_tiles[random_index].GetComponent<field_tile>().harvest();
        }
    }

    // Activate fertilization for the given time
    void fertilize (float time) {
        is_fertilized = true;
        fertilized_time_remaining = time;
    }

    // Activate cat powerup for the given time
    void feed (float time) {
        is_fed = true;
        fed_time_remaining = time;
    }
}
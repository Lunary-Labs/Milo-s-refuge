using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class field : MonoBehaviour
{
    private GameObject ressource;
    public List<GameObject> childs = new List<GameObject>();

    public float base_growth_speed = 1f;
    public float base_gather_speed = 1f;

    private float growth_speed;
    private float gather_speed;

    private float fertilizer_mutliplier = 2f;
    private bool is_fertilized = false;
    public float fertilized_time_remaining = 0f;

    private float fed_multiplier = 2f;
    private bool is_fed = false;
    public float fed_time_remaining = 0f;

    void Start()
    {
        foreach (Transform child in transform)
        {
            childs.Add(child.gameObject);
        }

        growth_speed = base_growth_speed;
        gather_speed = base_gather_speed;
    }

    void Update() {

        // Grow random ressources
        foreach (GameObject child in childs) {
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

        // Left click
        if (Input.GetMouseButtonDown(0)) {
            harvest();
        }
    }

    void harvest() {
        foreach (GameObject child in childs) {
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


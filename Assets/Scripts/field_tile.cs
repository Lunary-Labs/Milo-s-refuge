using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class field_tile : MonoBehaviour
{
    public float growth_state = 0f;
    private float next_growth_timer = 0f;
    private float growth_timer = 0f;

    private float max_growth = 10f;
    public bool harvestable = false;

    void start() {
        next_growth_timer = Random.Range(0f, 1f);
    }

    public void grow(float time) {
        if (!harvestable) {
            growth_timer += time;
            if (growth_timer >= next_growth_timer) {
                growth_state += 1f;
                growth_timer = 0f;
                next_growth_timer = Random.Range(0f, 1f);
                if (growth_state >= max_growth) {
                    harvestable = true;
                    growth_state = max_growth;
                }
            }
        }
    }

    public void harvest() {
        growth_state = 0f;
        harvestable = false;
        next_growth_timer = Random.Range(0f, 1f);
    }
}

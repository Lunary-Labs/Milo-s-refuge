using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class field_tile : MonoBehaviour {

    // Timer const
    public float timer_min = 1f;
    public float timer_max = 2f;

    // Growth / Harvest states
    public int growth_state = 0;
    private float next_growth_timer = 0f;
    private float growth_timer = 0f;
    private int max_growth = 3;
    public bool harvestable = false;

    // Prefab sprites
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
        // Put the correct sprite according to growth state.
        spriteRenderer.sprite = sprites[growth_state];
    }

    // Grow ressources by increasing timer.
    public void grow(float time) {
        if (!harvestable) {
            growth_timer += time;
            if (growth_timer >= next_growth_timer) {
                growth_state += 1;
                growth_timer = 0f;
                next_growth_timer = Random.Range(timer_min, timer_max);
                if (growth_state >= max_growth) {
                    harvestable = true;
                    growth_state = max_growth;
                }
            }
        }
    }

    // Harvest tile and reset states.
    public void harvest() {
        growth_state = 0;
        harvestable = false;
        next_growth_timer = Random.Range(timer_min, timer_max);
    }

}

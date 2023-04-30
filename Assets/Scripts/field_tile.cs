using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class field_tile : MonoBehaviour
{
    public int growth_state = 0;
    private float next_growth_timer = 0f;
    private float growth_timer = 0f;

    private int max_growth = 3;
    public bool harvestable = false;

    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;

    void Start() {
        next_growth_timer = Random.Range(0f, 1f);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
        spriteRenderer.sprite = sprites[growth_state];
    }

    public void grow(float time) {
        if (!harvestable) {
            growth_timer += time;
            if (growth_timer >= next_growth_timer) {
                growth_state += 1;
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
        growth_state = 0;
        harvestable = false;
        next_growth_timer = Random.Range(0f, 1f);
    }
}

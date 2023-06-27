using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class benchmark_box : MonoBehaviour
{

    private float timer;
    private float duration = 0.35f;
    public int dir = 1;
    private float moving_speed = 0.5f;

    void Update() {
        if (timer < duration) {
            timer += Time.deltaTime;
        } else {
            dir *= -1;
            timer = 0;    
        }
        Vector3 new_pos = this.gameObject.transform.position;
        new_pos.y += dir * moving_speed * Time.deltaTime;
        this.gameObject.transform.position = new_pos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat : MonoBehaviour
{
    
    public bool is_moving = false;
    public bool is_gathering = false;

    private float dest_x;
    private float dest_y;

    private float speed = 2f;

    void Update() {
        if (is_moving)
            move();
    }

    void move() {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(dest_x, dest_y, 0), step);
        if (transform.position == new Vector3(dest_x, dest_y, 0))
            is_moving = false;
    }
}

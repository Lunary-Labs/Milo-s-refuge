using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boat : MonoBehaviour
{
    private float x;
    private float y;

    private int stock_size = 10;
    private int stock = 0;

    public int milk = 0;
    public int wheat = 0;

    private bool is_moving = false;

    // will be used when computing bezier curve for smooth path
    private float start_x;
    private float start_y;

    private float dest_x;
    private float dest_y;

    private float speed = 1f;

    public void set_path(float starting_x, float starting_y, float destination_x, float destination_y) {
        start_x = starting_x;
        start_y = starting_y;
        dest_x = destination_x;
        dest_y = destination_y;
    }

    public void move() {
        if (is_moving) {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(dest_x, dest_y, 0), step);
            if (transform.position.x == dest_x && transform.position.y == dest_y) {
                is_moving = false;
            }
        }
    }
}

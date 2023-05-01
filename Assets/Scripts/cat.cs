using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat : MonoBehaviour
{
    
    private Animator animator;

    public bool field_cat;

    private bool is_moving = false;
    public bool is_gathering = false;
    public bool is_watering = false;
    public bool is_choping = false;

    public List<string> actions = new List<string>();

    private float action_timer;
    private float action_time;

    private bool front = true;
    private bool back = false;
    private bool left = false;
    private bool right = false;

    private float dest_x;
    private float dest_y;

    private float speed = 2f;

    void Start() {
        animator = GetComponent<Animator>();

        // check if cat is a field worker or just and island cat
        if (transform.parent.gameObject.name == "field") {
            field_cat = true;
            actions.Add("gather");
            actions.Add("water");
        } else {
            field_cat = false;
        }
    }

    void Update() {
        if (is_moving) {
            animator.SetFloat("speed", speed);
            animator.SetBool("front", front);
            animator.SetBool("back", back);
            animator.SetBool("left", left);
            animator.SetBool("right", right);
            move();
        } else {
            animator.SetFloat("speed", 0);}
    }

    void move() {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(dest_x, dest_y, 0), step);
        if (transform.position == new Vector3(dest_x, dest_y, 0)) {
            is_moving = false;
            if (field_cat) {
                set_action();
            }
        }
    }

    public void set_destination(float x, float y) {
        dest_x = x;
        dest_y = y;
        is_moving = true;
        float angle = Mathf.Atan2(dest_y - transform.position.y, dest_x - transform.position.x) * Mathf.Rad2Deg;
        if (angle < 0) angle += 360;
        front = false;
        back = false;
        left = false;
        right = false;
        if (angle >= 45 && angle < 135) {
            back = true;
        } else if (angle >= 135 && angle < 225) {
            left = true;
        } else if (angle >= 225 && angle < 315) {
            front = true;
        } else {
            right = true;
        }
    }

    private void set_action() {
        string action = actions[Random.Range(0, actions.Count)];
        action_timer = Random.Range(8, 15);
        action_time = 0;
        switch (action) {
            case "gather":
                is_gathering = true;
                break;
            case "water":
                is_watering = true;
                break;
            case "chop":
                is_choping = true;
                break;
            default:
                break;
        }
    }
}

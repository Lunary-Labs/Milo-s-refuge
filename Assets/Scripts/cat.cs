using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class cat : MonoBehaviour
{
    
    private Animator animator;
    private GameObject moving_zone;

    private bool field_cat;
    private bool static_cat;

    private bool is_moving = false;
    private bool is_gathering = false;
    private bool is_watering = false;

    public float action_time;
    public float action_timer;

    private bool front = true;
    private bool back = false;
    private bool left = false;
    private bool right = false;

    private float dest_x;
    private float dest_y;

    private float speed = 2f;

    void Start() {
        animator = GetComponent<Animator>();

        // check if cat is a field worker or just a chilling cat
        moving_zone = transform.parent.gameObject;
        field_cat = (moving_zone.name == "field_zone");
        static_cat = (moving_zone.name == "static_zone");
        if (static_cat) { is_gathering = true; }
    }

    void Update() {
        if (static_cat) { return; }
        if (is_moving) {
            animator.SetFloat("speed", speed);
            animator.SetBool("front", front);
            animator.SetBool("back", back);
            animator.SetBool("left", left);
            animator.SetBool("right", right);
            move();
        } else {
            animator.SetFloat("speed", 0);
            action_time += Time.deltaTime;
            if (action_time >= action_timer) {
                action_time = 0;
                Vector2 new_dest = random_pos(moving_zone.GetComponent<TilemapCollider2D>());
                set_destination(new_dest.x, new_dest.y);
            }
        }
    }

    void move() {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(dest_x, dest_y, 0), step);
        if (transform.position == new Vector3(dest_x, dest_y, 0)) {
            is_moving = false;
            action_timer = Random.Range(5, 15);
            if (field_cat) {
                switch (Random.Range(1, 4)) {
                    case 1:
                        is_gathering = true;
                        break;
                    case 2:
                        is_watering = true;
                        break;
                    default:
                        break;
                }
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

    Vector2 random_pos(TilemapCollider2D coll) {
        Bounds bounds = coll.bounds;
        float random_x = Random.Range(bounds.min.x, bounds.max.x);
        float random_y = Random.Range(bounds.min.y, bounds.max.y);
        Vector2 random_pos = new Vector2(random_x, random_y);
        return random_pos;
    }
}

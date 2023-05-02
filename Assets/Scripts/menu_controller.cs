using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_controller : MonoBehaviour
{

    private GameObject world;

    void Start() {
        world = GameObject.Find("world");
    }

    void Update() {
        if (world.transform.position.x < 20) {
            world.transform.Translate(Vector3.right * Time.deltaTime);
        } else {
            world.transform.position = new Vector3(-20, 0, 0);
        }
    }
}

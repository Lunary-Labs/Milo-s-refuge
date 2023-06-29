using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_controller : MonoBehaviour
{

    private GameObject world;
    public Texture2D cursor_texture;
    public Texture2D pointing_texture;
    public Texture2D clicking_texture;

    void Start() {
        world = GameObject.Find("world");
        standard_cursor();
    }

    void Update() {
        if (world.transform.position.x < 20) {
            world.transform.Translate(Vector3.right * Time.deltaTime);
        } else {
            world.transform.position = new Vector3(-20, 0, 0);
        }

        if (Input.GetMouseButtonDown(0)) {
            click_cursor();
        } else if (Input.GetMouseButtonUp(0)) {
            standard_cursor();
        }
    }

    public void standard_cursor() {
        Cursor.SetCursor(cursor_texture, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void pointing_cursor() {
        Cursor.SetCursor(pointing_texture, Vector2.zero, CursorMode.ForceSoftware);
    }
    
    public void click_cursor() {
        Cursor.SetCursor(clicking_texture, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void play() {
        SceneManager.LoadScene("world");
    }

    public void options() {
        //TODO
    }

    public void quit() {
        Application.Quit();
    }
}

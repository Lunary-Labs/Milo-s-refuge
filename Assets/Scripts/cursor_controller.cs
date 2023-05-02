using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cursor_controller : MonoBehaviour
{

    public Texture2D cursor_texture;
    public Texture2D pointing_texture;
    public Texture2D clicking_texture;

    void Start() {
        standard_cursor();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            click_cursor();
        } else if (Input.GetMouseButtonUp(0)) {
            standard_cursor();
        }

        if (Input.GetMouseButtonDown(1)) {
            click_cursor();
        } else if (Input.GetMouseButtonUp(1)) {
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorController : MonoBehaviour {

  public Texture2D CursorTexture;
  public Texture2D PointingTexture;
  public Texture2D ClickingTexture;

  void Start() {
    StandardCursor();
  }

  void Update() {
    if (Input.GetMouseButtonDown(0)) {
      ClickCursor();
    } else if (Input.GetMouseButtonUp(0)) {
      StandardCursor();
    }

    if (Input.GetMouseButtonDown(1)) {
      ClickCursor();
    } else if (Input.GetMouseButtonUp(1)) {
      StandardCursor();
    }
  }

  public void StandardCursor() {
    Cursor.SetCursor(CursorTexture, Vector2.zero, CursorMode.ForceSoftware);
  }

  public void PointingCursor() {
    Cursor.SetCursor(PointingTexture, Vector2.zero, CursorMode.ForceSoftware);
  }

  public void ClickCursor() {
    Cursor.SetCursor(ClickingTexture, Vector2.zero, CursorMode.ForceSoftware);
  }
}

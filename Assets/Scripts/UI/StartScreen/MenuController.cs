using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
  public Texture2D CursorTexture;
  public Texture2D PointingTexture;
  public Texture2D ClickingTexture;

  private GameObject _world;

  void Start() {
    _world = GameObject.Find("world");
    StandardCursor();
  }

  void Update() {
    if (_world.transform.position.x < 20) {
      _world.transform.Translate(Vector3.right * Time.deltaTime);
    } else {
      _world.transform.position = new Vector3(-20, 0, 0);
    }

    if (Input.GetMouseButtonDown(0)) {
      ClickCursor();
    } else if (Input.GetMouseButtonUp(0)) {
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

  public void Play() {
    SceneManager.LoadScene("world");
  }

  public void Options() {
    //TODO
  }

  public void Quit() {
    Application.Quit();
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class Island : MonoBehaviour {
  // TODO: Determine if this script is still necessary
  public List<GameObject> Fields = new List<GameObject>();
  public TilemapCollider2D[] ChildTilemapColliders;
  public Transform Workbench;

  void Start() {
    foreach (Transform child in transform) {
      if (child.name == "Field") {
        Fields.Add(child.gameObject);
      }
    }

    ChildTilemapColliders = GetComponentsInChildren<TilemapCollider2D>();
    Workbench = transform.Find("workbench");
  }
}

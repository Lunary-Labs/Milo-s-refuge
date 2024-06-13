using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour {
  public List<GameObject> FieldTiles = new List<GameObject>();

  private float _growthSpeed = 1.0f;

  void Start() {
    foreach (Transform child in transform) {
      FieldTiles.Add(child.gameObject);
    }
  }

  void Update() {
    foreach (GameObject child in FieldTiles) {
      child.GetComponent<FieldTile>().Grow(_growthSpeed * Time.deltaTime);
    }
  }
}

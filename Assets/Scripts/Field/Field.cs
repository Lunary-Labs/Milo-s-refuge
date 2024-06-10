using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour {
  public List<GameObject> FieldTiles = new List<GameObject>();

  // Basic growth and gather speed
  private float _baseGrowthSpeed = 1f;
  private float _growthSpeed;

  void Start() {
    foreach (Transform child in transform) {
      FieldTiles.Add(child.gameObject);
    }
    _growthSpeed = _baseGrowthSpeed;
  }

  void Update() {
    foreach (GameObject child in FieldTiles) {
      child.GetComponent<FieldTile>().Grow(_growthSpeed * Time.deltaTime);
    }
  }
}

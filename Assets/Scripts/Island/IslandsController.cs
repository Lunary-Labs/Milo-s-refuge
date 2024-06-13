using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandsController : MonoBehaviour {
  public string CurrentWorld = "Overworld";

  [System.Serializable]
  public class IslandData {
    public string world;
    public Position position;
    public string prefabPath;
    public int islandLevel;
    public int islandMaxLevel;
    [System.Serializable]
    public class Position {
      public float x;
      public float y;
    }
  }
  [System.Serializable]
  public class IslandList {
    public List<IslandData> islands;
  }
  private TextAsset _islandJson;
  private IslandList _islandList;

  [SerializeField]
  private List<GameObject> islands;

  void Start() {
    // TODO: Should either load the base islands.json file or load a save file
    _islandJson = Resources.Load<TextAsset>("Data/islands");
    _islandList = JsonUtility.FromJson<IslandList>(_islandJson.text);
    InstantiateIslands();
  }

  private void InstantiateIslands() {
    foreach(IslandData island in _islandList.islands) {
      if(island.world == CurrentWorld) {
        GameObject prefab = Resources.Load<GameObject>(island.prefabPath + "_" + island.islandLevel);
        if(prefab != null) {
          Vector3 position = new Vector3(island.position.x, island.position.y, 0);
          GameObject newIsland = Instantiate(prefab, position, Quaternion.identity);
          islands.Add(newIsland);
        } else {
          Debug.LogError("Prefab not found at path: " + island.prefabPath);
        }
      }
    }
  }

}

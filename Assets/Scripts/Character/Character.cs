using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
  public int Prestige = 0;
  public Dictionary<string, int> Resources = new Dictionary<string, int>();

  void Start() {
    // TODO: use save to initialize the resources
    Resources.Add("Wheat", 0);
    Resources.Add("Carrot", 0);
    Resources.Add("Tomato", 0);
    Resources.Add("Corn", 0);
    Resources.Add("Eggplant", 0);
    Resources.Add("Cabbage", 0);
    Resources.Add("Salad", 0);
    Resources.Add("Pumpkin", 0);
    Resources.Add("Pickle", 0);
    Resources.Add("Radish", 0);
    Resources.Add("Sugar Cane", 0);
    Resources.Add("Milk", 0);
    Resources.Add("Eggs", 0);
    Resources.Add("Wool", 0);
    Resources.Add("Honey", 0);
    Resources.Add("Wood", 0);
    Resources.Add("Stone", 0);
    Resources.Add("Iron", 0);
    Resources.Add("Gold", 10000); // TODO: remove this debug value
    Resources.Add("Flour", 0);
  }

  public void ChangeResource(string resourceName, int amount) {
    Resources[resourceName] += amount;
  }

  public int GetResource(string resourceName) {
    return Resources[resourceName];
  }
}

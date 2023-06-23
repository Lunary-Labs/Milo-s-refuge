using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{

    public int prestige = 0;

    // ressources
    public Dictionary<string, int> ressources = new Dictionary<string, int>();

    // Debug display in inspector
    public int wheat = 0;
    public int carrot = 0;
    public int tomato = 0;
    public int corn = 0;
    public int eggplant = 0;
    public int cabbage = 0;
    public int salad = 0;
    public int pumpkin = 0;
    public int pickle = 0;
    public int radish = 0;
    public int sugar_cane = 0;
    public int milk = 0;
    public int eggs = 0;
    public int wool = 0;
    public int honey = 0;
    public int wood = 0;
    public int stone = 0;
    public int iron = 0;
    public int gold = 0;
    public int flour = 0;

     // Finished products values
    enum finished_product {
        bread = 10,
        cake = 20,
        cheese = 30,
        pumpkin_soup = 40,
        radish_salad = 50,
    }

    void Start() {
        // Fill the ressources dictionary with all the ressources
        ressources.Add("wheat", 0);
        ressources.Add("carrot", 0);
        ressources.Add("tomato", 0);
        ressources.Add("corn", 0);
        ressources.Add("eggplant", 0);
        ressources.Add("cabbage", 0);
        ressources.Add("salad", 0);
        ressources.Add("pumpkin", 0);
        ressources.Add("pickle", 0);
        ressources.Add("radish", 0);
        ressources.Add("sugar_cane", 0);
        ressources.Add("milk", 0);
        ressources.Add("eggs", 0);
        ressources.Add("wool", 0);
        ressources.Add("honey", 0);
        ressources.Add("wood", 0);
        ressources.Add("stone", 0);
        ressources.Add("iron", 0);
        ressources.Add("gold", 0);
        ressources.Add("flour", 0);
    }

    void Update () {
        // Debug display in inspector
        wheat = ressources["wheat"];
        flour = ressources["flour"];
        carrot = ressources["carrot"];
        tomato = ressources["tomato"];
        corn = ressources["corn"];
        eggplant = ressources["eggplant"];
        cabbage = ressources["cabbage"];
        salad = ressources["salad"];
        pumpkin = ressources["pumpkin"];
        pickle = ressources["pickle"];
        radish = ressources["radish"];
        sugar_cane = ressources["sugar_cane"];
        milk = ressources["milk"];
        eggs = ressources["eggs"];
        wool = ressources["wool"];
        honey = ressources["honey"];
        wood = ressources["wood"];
        stone = ressources["stone"];
        iron = ressources["iron"];
        gold = ressources["gold"];
    }

    public void change_ressource (string ressource_name, int amount) {    
        ressources[ressource_name] += amount;
    }

    public int get_ressource (string ressource_name) {
        return ressources[ressource_name];
    }

    public void choose_add(string product, string reward) {
        if (reward == "gold") {
            gold += (int)System.Enum.Parse(typeof(finished_product), product);
        } else {
            change_ressource(product, 1);
        }
    }
}


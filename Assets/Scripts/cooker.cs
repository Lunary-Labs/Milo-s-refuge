using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[System.Serializable]

public class Recipe
{
    public string name;
    public string ressource1;
    public int amount1;
    public string ressource2;
    public int amount2;
    public string ressource3;
    public int amount3;
    public float duration;
    public int price;
}

public class RecipeList {
    public List<Recipe> recipe_list;
}

public class cooker : MonoBehaviour
{

    // Cookers recipes
    public string recipe_cooker_1 = "";

    // Cookers states
    public bool cooker_1_started = false;

    // Cookers timers
    public float timer_cooker_1;

    // Json recipe part
    public RecipeList recipe_array;
    Dictionary<string, Recipe> recipe_dict = new Dictionary<string, Recipe>();

    void Start() {
        string json = File.ReadAllText(Application.dataPath + "/Scripts/recipe.json");
        recipe_array = JsonUtility.FromJson<RecipeList>(json); 
        foreach (Recipe recipe_data in recipe_array.recipe_list) {
            recipe_dict.Add(recipe_data.name, recipe_data);
        }
    }

    void Update() {
        if (recipe_cooker_1 != "" && cooker_1_started) {
            timer_cooker_1 += Time.deltaTime;
            if (timer_cooker_1 >= recipe_dict[recipe_cooker_1].duration) {
                timer_cooker_1 = 0;
                cooker_1_started = false;
                // TODO: give ressources to player
            }
        } else if (recipe_cooker_1 != "" && !cooker_1_started) {
            Recipe r_cooker_1 = recipe_dict[recipe_cooker_1];
            // we check if the player have enough ressources
            bool enough_ressources = true;
            if (r_cooker_1.amount1 > transform.GetComponent<character>().get_ressource(r_cooker_1.ressource1)) {
                Debug.Log("quantité demandée : " + r_cooker_1.ressource1);
                Debug.Log("quantitée du joueur : " + transform.GetComponent<character>().get_ressource(r_cooker_1.ressource1));
                enough_ressources = false;
            }
            if (r_cooker_1.amount2 > transform.GetComponent<character>().get_ressource(r_cooker_1.ressource2)) {
                enough_ressources = false;
            }
            if (r_cooker_1.amount3 > transform.GetComponent<character>().get_ressource(r_cooker_1.ressource3)) {                
                enough_ressources = false;
            }
            if (enough_ressources) {
                transform.GetComponent<character>().remove_ressource(r_cooker_1.ressource1, r_cooker_1.amount1);
                transform.GetComponent<character>().remove_ressource(r_cooker_1.ressource2, r_cooker_1.amount2);
                transform.GetComponent<character>().remove_ressource(r_cooker_1.ressource3, r_cooker_1.amount3);
                cooker_1_started = true;
            }
        }
        if (Input.GetMouseButtonDown(0)) {
                change_recipe_cooker_1("flour");
            }
    }

    void change_recipe_cooker_1(string recipe) {
        if (recipe_dict.ContainsKey(recipe)) {
            recipe_cooker_1 = recipe;
        }
    }

    void cancel_recipe_cooker_1() {
        recipe_cooker_1 = "";
        cooker_1_started = false;
        timer_cooker_1 = 0;
        //TODO : give back ressources
    }
}


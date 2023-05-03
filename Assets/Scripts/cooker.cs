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
    public string recipe_cooker_2 = "";
    public string recipe_cooker_3 = "";

    // Cookers states
    public bool cooker_1_started = false;
    public bool cooker_2_started = false;
    public bool cooker_3_started = false;

    // Cookers timers
    public float timer_cooker_1;
    public float timer_cooker_2;
    public float timer_cooker_3;

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
        // Cooker 1
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
                enough_ressources = false;
            }
            if (r_cooker_1.amount2 > transform.GetComponent<character>().get_ressource(r_cooker_1.ressource2)) {
                enough_ressources = false;
            }
            if (r_cooker_1.amount3 > transform.GetComponent<character>().get_ressource(r_cooker_1.ressource3)) {                
                enough_ressources = false;
            }
            if (enough_ressources) {
                transform.GetComponent<character>().change_ressource(r_cooker_1.ressource1, -r_cooker_1.amount1);
                transform.GetComponent<character>().change_ressource(r_cooker_1.ressource2, -r_cooker_1.amount2);
                transform.GetComponent<character>().change_ressource(r_cooker_1.ressource3, -r_cooker_1.amount3);
                cooker_1_started = true;
            }
        }

        // Cooker 2
        if (recipe_cooker_2 != "" && cooker_2_started) {
            timer_cooker_2 += Time.deltaTime;
            if (timer_cooker_2 >= recipe_dict[recipe_cooker_2].duration) {
                timer_cooker_2 = 0;
                cooker_2_started = false;
                // TODO: give ressources to player
            }
        } else if (recipe_cooker_2 != "" && !cooker_2_started) {
            Recipe r_cooker_2 = recipe_dict[recipe_cooker_2];
            // we check if the player have enough ressources
            bool enough_ressources = true;
            if (r_cooker_2.amount1 > transform.GetComponent<character>().get_ressource(r_cooker_2.ressource1)) {
                enough_ressources = false;
            }
            if (r_cooker_2.amount2 > transform.GetComponent<character>().get_ressource(r_cooker_2.ressource2)) {
                enough_ressources = false;
            }
            if (r_cooker_2.amount3 > transform.GetComponent<character>().get_ressource(r_cooker_2.ressource3)) {                
                enough_ressources = false;
            }
            if (enough_ressources) {
                transform.GetComponent<character>().change_ressource(r_cooker_2.ressource1, -r_cooker_2.amount1);
                transform.GetComponent<character>().change_ressource(r_cooker_2.ressource2, -r_cooker_2.amount2);
                transform.GetComponent<character>().change_ressource(r_cooker_2.ressource3, -r_cooker_2.amount3);
                cooker_2_started = true;
            }
        }

        // Cooker 3
        if (recipe_cooker_3 != "" && cooker_3_started) {
            timer_cooker_3 += Time.deltaTime;
            if (timer_cooker_3 >= recipe_dict[recipe_cooker_3].duration) {
                timer_cooker_3 = 0;
                cooker_3_started = false;
                // TODO: give ressources to player
            }
        } else if (recipe_cooker_3 != "" && !cooker_3_started) {
            Recipe r_cooker_3 = recipe_dict[recipe_cooker_3];
            // we check if the player have enough ressources
            bool enough_ressources = true;
            if (r_cooker_3.amount1 > transform.GetComponent<character>().get_ressource(r_cooker_3.ressource1)) {
                enough_ressources = false;
            }
            if (r_cooker_3.amount2 > transform.GetComponent<character>().get_ressource(r_cooker_3.ressource2)) {
                enough_ressources = false;
            }
            if (r_cooker_3.amount3 > transform.GetComponent<character>().get_ressource(r_cooker_3.ressource3)) {                
                enough_ressources = false;
            }
            if (enough_ressources) {
                transform.GetComponent<character>().change_ressource(r_cooker_3.ressource1, -r_cooker_3.amount1);
                transform.GetComponent<character>().change_ressource(r_cooker_3.ressource2, -r_cooker_3.amount2);
                transform.GetComponent<character>().change_ressource(r_cooker_3.ressource3, -r_cooker_3.amount3);
                cooker_3_started = true;
            }
        }

        // test clicks
        if (Input.GetMouseButtonDown(0)) {
            change_recipe_cooker_1("flour");
        }

        if (Input.GetMouseButtonDown(1)) {
            cancel_recipe_cooker_1();
        }
    }

    void change_recipe_cooker_1(string recipe) {
        if (recipe_dict.ContainsKey(recipe)) {
            recipe_cooker_1 = recipe;
        }
    }

    void change_recipe_cooker_2(string recipe) {
        if (recipe_dict.ContainsKey(recipe)) {
            recipe_cooker_2 = recipe;
        }
    }

    void change_recipe_cooker_3(string recipe) {
        if (recipe_dict.ContainsKey(recipe)) {
            recipe_cooker_2 = recipe;
        }
    }

    void cancel_recipe_cooker_1() {
        //TODO : give back ressources
        Recipe r_cooker_1 = recipe_dict[recipe_cooker_1];
        if (cooker_1_started) {
            transform.GetComponent<character>().change_ressource(r_cooker_1.ressource1, r_cooker_1.amount1);
            transform.GetComponent<character>().change_ressource(r_cooker_1.ressource2, r_cooker_1.amount2);
            transform.GetComponent<character>().change_ressource(r_cooker_1.ressource3, r_cooker_1.amount3);
        }
        recipe_cooker_1 = "";
        cooker_1_started = false;
        timer_cooker_1 = 0;
    }

    void cancel_recipe_cooker_2() {
        Recipe r_cooker_2 = recipe_dict[recipe_cooker_2];
        if (cooker_2_started) {
            transform.GetComponent<character>().change_ressource(r_cooker_2.ressource1, r_cooker_2.amount1);
            transform.GetComponent<character>().change_ressource(r_cooker_2.ressource2, r_cooker_2.amount2);
            transform.GetComponent<character>().change_ressource(r_cooker_2.ressource3, r_cooker_2.amount3);
        }
        recipe_cooker_2 = "";
        cooker_2_started = false;
        timer_cooker_2 = 0;
    }

    void cancel_recipe_cooker_3() {
        Recipe r_cooker_3 = recipe_dict[recipe_cooker_3];
        if (cooker_3_started) {
            transform.GetComponent<character>().change_ressource(r_cooker_3.ressource1, r_cooker_3.amount1);
            transform.GetComponent<character>().change_ressource(r_cooker_3.ressource2, r_cooker_3.amount2);
            transform.GetComponent<character>().change_ressource(r_cooker_3.ressource3, r_cooker_3.amount3);
        }
        recipe_cooker_3 = "";
        cooker_2_started = false;
        timer_cooker_3 = 0;
    }
}


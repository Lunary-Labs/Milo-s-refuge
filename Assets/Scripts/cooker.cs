using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class Recipe {
    public string name;
    public string reward;
    public string ressource1;
    public int amount1;
    public string ressource2;
    public int amount2;
    public string ressource3;
    public int amount3;
    public float duration;
    public int price;
    public string path_sprite;
    public string r_path_sprite_1;
    public string r_path_sprite_2;
    public string r_path_sprite_3;
}

public class RecipeList {
    public List<Recipe> recipe_list;
}

// Class that will be savec in cookers.json for every save
public class Cooker {
    public string recipe;
    public float timer;
    public bool started;
}

public class cooker : MonoBehaviour {
    
    public character character_script;

    public List<Cooker> cookers = new List<Cooker>();
    public int cooker_amount = 3;

    // Debug display in inspector
    public string recipe_cooker_1 = "";
    public bool cooker_1_started = false;
    public float timer_cooker_1;

    // Json recipe part
    public RecipeList recipe_array;
    public Dictionary<string, Recipe> recipe_dict = new Dictionary<string, Recipe>();

    void Start() {
        // Add each cooker to cookers list
        for (int i = 0; i < cooker_amount; i++) {
            Cooker cooker = new Cooker();
            cooker.recipe = "";
            cooker.timer = 0;
            cooker.started = false;
            cookers.Add(cooker);
        }

        string json = File.ReadAllText(Application.dataPath + "/Json/recipe.json");
        recipe_array = JsonUtility.FromJson<RecipeList>(json); 
        foreach (Recipe recipe_data in recipe_array.recipe_list) {
            recipe_dict.Add(recipe_data.name, recipe_data);
        }
        character_script = transform.GetComponent<character>();
    }

    void Update() {
        // Debug display in inspector
        recipe_cooker_1 = cookers[0].recipe;
        cooker_1_started = cookers[0].started;
        timer_cooker_1 = cookers[0].timer;

        foreach (Cooker cooker in cookers) {
            if (!cooker.started && cooker.recipe != "") {
                Recipe r = recipe_dict[cooker.recipe];
                // we check if the player have enough ressources
                bool enough_ressources = true;
                if (r.ressource1 != "none") {
                    if (r.amount1 > character_script.get_ressource(r.ressource1)) {
                        enough_ressources = false;
                    }
                }
                if (r.ressource2 != "none") {
                    if (r.amount2 > character_script.get_ressource(r.ressource2)) {
                        enough_ressources = false;
                    }
                }
                if (r.ressource3 != "none") {
                    if (r.amount3 > character_script.get_ressource(r.ressource3)) {                
                        enough_ressources = false;
                    }
                }
                if (enough_ressources) {
                    if (r.ressource1 != "none")
                        character_script.change_ressource(r.ressource1, -r.amount1);
                    if (r.ressource2 != "none")
                        character_script.change_ressource(r.ressource2, -r.amount2);
                    if (r.ressource3 != "none")
                        character_script.change_ressource(r.ressource3, -r.amount3);
                    cooker.started = true;
                }
            }

            // If the cooker is started, we increment the timer and craft the recipe if the timer is finished
            if (cooker.started) {
                cooker.timer += Time.deltaTime;
                if (cooker.timer >= recipe_dict[cooker.recipe].duration) {
                    cooker.timer = 0;
                    cooker.started = false;
                    if (recipe_dict[cooker.recipe].reward == "gold") {
                        character_script.change_ressource("gold", recipe_dict[cooker.recipe].price);
                    } else {
                        character_script.change_ressource(recipe_dict[cooker.recipe].reward, 1);
                    }
                }
            } 
        }
    }

    // Change the recipe of a cooker and refund the player
    public void change_recipe(string recipe, int cooker_index) {
        if (recipe_dict.ContainsKey(recipe)) {
            cancel_recipe(cooker_index);
            cookers[cooker_index].recipe = recipe;
        }
    }

    // Refund the player and remove the recipe
    public void cancel_recipe(int cooker_index) {
        Recipe r = recipe_dict[cookers[cooker_index].recipe];
        if (cookers[cooker_index].started) {
            character_script.change_ressource(r.ressource1, r.amount1);
            character_script.change_ressource(r.ressource2, r.amount2);
            character_script.change_ressource(r.ressource3, r.amount3);
            cookers[cooker_index].started = false;
        }
        cookers[cooker_index].recipe = "";
    }
}


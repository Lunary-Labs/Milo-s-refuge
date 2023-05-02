using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[System.Serializable]

public class Recipe
{
    public string name;
    public string resource1;
    public int amount1;
    public string resource2;
    public int amount2;
    public string resource3;
    public int amount3;
    public float duration;
    public int price;
}

public class RecipeList {
    public List<Recipe> recipe_list;
}

public class cooker : MonoBehaviour
{
    //recipe cooker
    public string recipe_cooker_1;
    // public string recipe_cooker_2;
    // public string recipe_cooker_3;
    

    //timer cooker
    private float timer_cooker_1;
    private bool finish_cooker_1 = true;
    private bool error_cooker_1 = false;

    // private float current_timer_duration_cooker_2;
    // private float current_timer_cooker_2;
    // private bool finish_cooker_2 = true;
    // private float current_timer_duration_cooker_3;
    // private float current_timer_cooker_3;
    // private bool finish_cooker_2 = true;




    //recipe json
    private string recipe_file = "recipe.json";
    public RecipeList recipeDataArray;
    Dictionary<string, Recipe> recipeDataDict = new Dictionary<string, Recipe>();


    // Start is called before the first frame update
    void Start()
    {
        string json = File.ReadAllText(Application.dataPath + "/Scripts/" + recipe_file);
        recipeDataArray = JsonUtility.FromJson<RecipeList>(json); 
        foreach(Recipe recipeData in recipeDataArray.recipe_list)
        {
            recipeDataDict.Add(recipeData.name, recipeData);
        }
        Recipe test = recipeDataDict["bread"];


        
    }

    // Update is called once per frame
    void Update()
    {
        if(recipe_cooker_1 != "" && finish_cooker_1)
        {
            //Current needed ressources
            List<string> recipe_ressources = get_recipe_ressources(recipe_cooker_1);


            //Check if the player have enough ressources
            Recipe r_cooker_1 = recipeDataDict[recipe_cooker_1];
            if(r_cooker_1.amount1 > transform.GetComponent<character>().get_ressources(recipe_ressources[0])){
                error_cooker_1 = true;
            }
            if(recipe_ressources.Count > 1){
                if(r_cooker_1.amount2 < transform.GetComponent<character>().get_ressources(recipe_ressources[1]))
                {
                    error_cooker_1 = true;
                }
            }
            if(recipe_ressources.Count > 2){
                if(r_cooker_1.amount3 > transform.GetComponent<character>().get_ressources(recipe_ressources[2]))
                {
                    error_cooker_1 = true;
                }
            }


            //current_timer_duration_cooker_1 = r_cooker_1.duration;
            // if(current_timer_cooker_1 >= current_timer_duration_cooker_1){
            //     current_timer_cooker_1 += time.deltaTime;
            // }
        }
    }


    //Get ressources from recipe 
    //return List of ressources (string)
    private List<string> get_recipe_ressources(Recipe _recipe){
        List<string> ressources = new List<string>();
        ressources.Add(_recipe.resource1);
        if(_recipe.resource2 != "none")
        {
            ressources.Add(_recipe.resource2);
        }
        if(_recipe.resource3 != "none")
        {
            ressources.Add(_recipe.resource3);
        }
        
        return ressources;
    }
    
}


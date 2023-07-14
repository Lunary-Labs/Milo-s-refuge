using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine;

public class menu_cooker : MonoBehaviour
{
    //game manager
    public GameObject game_manager; 

    //Cooker
    public GameObject cooker_prefab;
    public GameObject cooker_ui;
    public GameObject cooker_list;
    private Image cooker_current_image;
    private Sprite cooker_current_sprite;
    private TMPro.TextMeshProUGUI cooker_current_text;
    private cooker cooker_script;
    public int current_cooker; 

    //Recipe
    public GameObject recipe_prefab;
    public GameObject change_recipe_ui;
    public GameObject recipe_list;
    private Image recipe_current_image;
    private Sprite recipe_current_sprite;
    private TMPro.TextMeshProUGUI recipe_current_text;

    //button
    public Button cooker_button; 

    //Recipe dictionary 
    public Dictionary<string, Recipe> recipe_dict = new Dictionary<string, Recipe>();
    // Start is called before the first frame update
    void Start()
    {
        string json = File.ReadAllText(Application.dataPath + "/Json/recipe.json");
        RecipeList recipe_array = JsonUtility.FromJson<RecipeList>(json); 
        foreach (Recipe recipe_data in recipe_array.recipe_list) {
            recipe_dict.Add(recipe_data.name, recipe_data);
            Debug.Log(recipe_data.name);
        }   
    }

    // Update is called once per frame
    void Update()
    {

    }
    //Instantiate cooker
    public void display_cooker(){
        cooker_script = game_manager.GetComponent<cooker>();
        int index = 0;
        foreach(Cooker cooker_data in cooker_script.cookers){
            GameObject new_cooker = Instantiate(cooker_prefab, cooker_list.transform);
            new_cooker.transform.name = index.ToString();
            GameObject current_recipe_cooker = new_cooker.transform.GetChild(0).gameObject;
            if(cooker_script.cookers[index].recipe == ""){
                current_recipe_cooker.SetActive(false);
            }
            else{
                current_recipe_cooker.SetActive(true);
                Recipe recipe_data = recipe_dict[cooker_script.cookers[index].recipe];
                current_recipe_cooker.transform.Find("recipe_name").GetComponent<TMPro.TextMeshProUGUI>().text = recipe_data.name;
                cooker_current_image = current_recipe_cooker.transform.Find("display_recipe_image").GetComponent<Image>();
                cooker_current_sprite = LoadSprite(Application.dataPath + recipe_data.path_sprite);
                cooker_current_image.sprite = cooker_current_sprite;
                cooker_current_image = current_recipe_cooker.transform.Find("ressource1_image").GetComponent<Image>();
                cooker_current_sprite = LoadSprite(Application.dataPath + recipe_data.r_path_sprite_1);
                cooker_current_image.sprite = cooker_current_sprite;
                cooker_current_text = current_recipe_cooker.transform.Find("ressource1_text").GetComponent<TMPro.TextMeshProUGUI>();
                cooker_current_text.text = recipe_data.amount1.ToString();
                if(recipe_data.amount2 != 0){
                    cooker_current_image = current_recipe_cooker.transform.Find("ressource2_image").GetComponent<Image>();
                    cooker_current_sprite = LoadSprite(Application.dataPath + recipe_data.r_path_sprite_2);
                    cooker_current_image.sprite = cooker_current_sprite;

                    cooker_current_text = current_recipe_cooker.transform.Find("ressource2_text").GetComponent<TMPro.TextMeshProUGUI>();
                    cooker_current_text.text = recipe_data.amount2.ToString();
                }
                else{
                    Destroy(current_recipe_cooker.transform.Find("ressource2_image").GetComponent<Image>());
                    Destroy(current_recipe_cooker.transform.Find("ressource2_text").GetComponent<TMPro.TextMeshProUGUI>());
                }

                if(recipe_data.amount3 != 0){
                    cooker_current_image = current_recipe_cooker.transform.Find("ressource3_image").GetComponent<Image>();
                    cooker_current_sprite = LoadSprite(Application.dataPath + recipe_data.r_path_sprite_3);
                    cooker_current_image.sprite = cooker_current_sprite;

                    cooker_current_text = current_recipe_cooker.transform.Find("ressource3_text").GetComponent<TMPro.TextMeshProUGUI>();
                    cooker_current_text.text = recipe_data.amount3.ToString();
                }
                else{
                    Destroy(current_recipe_cooker.transform.Find("ressource3_image").GetComponent<Image>());
                    Destroy(current_recipe_cooker.transform.Find("ressource3_text").GetComponent<TMPro.TextMeshProUGUI>());
                }
            }
            index++;
        }
       
    }
    //Instantiate recipe list 
    public void create_recipe_list_ui(GameObject cooker_button) {  
        string json = File.ReadAllText(Application.dataPath + "/Json/recipe.json");
        RecipeList recipe_array = JsonUtility.FromJson<RecipeList>(json); 
        foreach (Recipe recipe_data in recipe_array.recipe_list) {

            GameObject new_recipe = Instantiate(recipe_prefab, recipe_list.transform);    
            new_recipe.name = recipe_data.name;
            // Recipe name
            new_recipe.transform.Find("recipe_name").GetComponent<TMPro.TextMeshProUGUI>().text = recipe_data.name;
            // Recipe image
            recipe_current_image = new_recipe.transform.Find("display_recipe_image").GetComponent<Image>();
            recipe_current_sprite = LoadSprite(Application.dataPath + recipe_data.path_sprite);
            recipe_current_image.sprite = recipe_current_sprite;
            // Ressource1 
            recipe_current_image = new_recipe.transform.Find("ressource1_image").GetComponent<Image>();
            recipe_current_sprite = LoadSprite(Application.dataPath + recipe_data.r_path_sprite_1);
            recipe_current_image.sprite = recipe_current_sprite;
            recipe_current_text = new_recipe.transform.Find("ressource1_text").GetComponent<TMPro.TextMeshProUGUI>();
            recipe_current_text.text = recipe_data.amount1.ToString();
            if(recipe_data.amount2 != 0){
                recipe_current_image = new_recipe.transform.Find("ressource2_image").GetComponent<Image>();
                recipe_current_sprite = LoadSprite(Application.dataPath + recipe_data.r_path_sprite_2);
                recipe_current_image.sprite = recipe_current_sprite;

                recipe_current_text = new_recipe.transform.Find("ressource2_text").GetComponent<TMPro.TextMeshProUGUI>();
                recipe_current_text.text = recipe_data.amount2.ToString();
            }
            else{
                Destroy(new_recipe.transform.Find("ressource2_image").GetComponent<Image>());
                Destroy(new_recipe.transform.Find("ressource2_text").GetComponent<TMPro.TextMeshProUGUI>());
            }
            if(recipe_data.amount3 != 0){
                recipe_current_image = new_recipe.transform.Find("ressource3_image").GetComponent<Image>();
                recipe_current_sprite = LoadSprite(Application.dataPath + recipe_data.r_path_sprite_3);
                recipe_current_image.sprite = recipe_current_sprite;

                recipe_current_text = new_recipe.transform.Find("ressource3_text").GetComponent<TMPro.TextMeshProUGUI>();
                recipe_current_text.text = recipe_data.amount3.ToString();
            }
            else{
                Destroy(new_recipe.transform.Find("ressource3_image").GetComponent<Image>());
                Destroy(new_recipe.transform.Find("ressource3_text").GetComponent<TMPro.TextMeshProUGUI>());
            }
        }  
    }

    public void delete_recipe_list(){
        foreach (Transform child in recipe_list.transform) {
            Destroy(child.gameObject);
        }
    }

    public void delete_cooker_list(){
        foreach (Transform child in cooker_list.transform) {
            Destroy(child.gameObject);
        }
    }

    public void state_change_recipe_ui(bool state){
        change_recipe_ui.SetActive(state);
    }

    public void state_cooker_ui(bool state){
        cooker_ui.SetActive(state);
    }

    public void save_current_cooker(string cooker_name){
        current_cooker = int.Parse(cooker_name);
    }

    public void change_recipe_cooker(string recipe_name, int cooker_index){
        Debug.Log(recipe_name);
        cooker_script.change_recipe(recipe_name, cooker_index);
    }

    public void interactable_button_cooker(bool state){
        cooker_button.interactable = state;
    }

    //loading sprite function
    private Sprite LoadSprite(string path) {
        if (string.IsNullOrEmpty(path)) return null;
        if (System.IO.File.Exists(path)) {
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            Texture2D texture = new Texture2D(1, 1);
            texture.LoadImage(bytes);
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            return sprite;
        }
        return null;
    }
}
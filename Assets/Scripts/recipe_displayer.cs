using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine;

public class recipe_displayer : MonoBehaviour
{
    public GameObject recipe_prefab;
    private Image current_image;
    private Sprite current_sprite;
    private TMPro.TextMeshProUGUI current_text;

    public void create_recipe_list_ui(GameObject cooker_button) {
        string json = File.ReadAllText(Application.dataPath + "/Scripts/recipe.json");
        RecipeList recipe_array = JsonUtility.FromJson<RecipeList>(json); 
        transform.name = cooker_button.transform.name; 
        foreach (Recipe recipe_data in recipe_array.recipe_list) {
            GameObject new_recipe = Instantiate(recipe_prefab, transform);    
            new_recipe.name = recipe_data.name;

            // Recipe name
            new_recipe.transform.Find("recipe_name").GetComponent<TMPro.TextMeshProUGUI>().text = recipe_data.name;

            // Recipe image
            current_image = new_recipe.transform.Find("display_recipe_image").GetComponent<Image>();
            current_sprite = LoadSprite(Application.dataPath + recipe_data.path_sprite);
            current_image.sprite = current_sprite;

            // Ressource1 
            current_image = new_recipe.transform.Find("ressource1_image").GetComponent<Image>();
            current_sprite = LoadSprite(Application.dataPath + recipe_data.r_path_sprite_1);
            current_image.sprite = current_sprite;

            current_text = new_recipe.transform.Find("ressource1_text").GetComponent<TMPro.TextMeshProUGUI>();
            current_text.text = recipe_data.amount1.ToString();

            if(recipe_data.amount2 != 0){
                current_image = new_recipe.transform.Find("ressource2_image").GetComponent<Image>();
                current_sprite = LoadSprite(Application.dataPath + recipe_data.r_path_sprite_2);
                current_image.sprite = current_sprite;

                current_text = new_recipe.transform.Find("ressource2_text").GetComponent<TMPro.TextMeshProUGUI>();
                current_text.text = recipe_data.amount2.ToString();
            }
            else{
                Destroy(new_recipe.transform.Find("ressource2_image").GetComponent<Image>());
                Destroy(new_recipe.transform.Find("ressource2_text").GetComponent<TMPro.TextMeshProUGUI>());
            }

            if(recipe_data.amount3 != 0){
                current_image = new_recipe.transform.Find("ressource3_image").GetComponent<Image>();
                current_sprite = LoadSprite(Application.dataPath + recipe_data.r_path_sprite_3);
                current_image.sprite = current_sprite;

                current_text = new_recipe.transform.Find("ressource3_text").GetComponent<TMPro.TextMeshProUGUI>();
                current_text.text = recipe_data.amount3.ToString();
            }
            else{
                Destroy(new_recipe.transform.Find("ressource3_image").GetComponent<Image>());
                Destroy(new_recipe.transform.Find("ressource3_text").GetComponent<TMPro.TextMeshProUGUI>());
            }
        }   
    }

    public void delete_recipe_list_ui() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
    }

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

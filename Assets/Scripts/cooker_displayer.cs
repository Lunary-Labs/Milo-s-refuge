using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine;

public class cooker_displayer : MonoBehaviour
{
    public GameObject cooker_prefab;
    private Image current_image;
    private Sprite current_sprite;
    private TMPro.TextMeshProUGUI current_text;
    private cooker cooker_script;
    private Dictionary<string, Recipe> recipe_dict = new Dictionary<string, Recipe>();
    // Start is called before the first frame update
    void Start()
    {
        string json = File.ReadAllText(Application.dataPath + "/Scripts/recipe.json");
        RecipeList recipe_array = JsonUtility.FromJson<RecipeList>(json); 
        foreach (Recipe recipe_data in recipe_array.recipe_list) {
            recipe_dict.Add(recipe_data.name, recipe_data);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void display_cooker(){
        Debug.Log("working");
        cooker_script = GameObject.Find("game_manager").GetComponent<cooker>();
        GameObject new_cooker = Instantiate(cooker_prefab, transform);
        GameObject current_recipe_cooker = new_cooker.transform.GetChild(0).gameObject;
        if(cooker_script.recipe_cooker_1 == ""){
            current_recipe_cooker.SetActive(false);
        }   
        else{
            current_recipe_cooker.SetActive(true);
            Recipe recipe_data = recipe_dict[cooker_script.recipe_cooker_1];

            current_recipe_cooker.transform.Find("recipe_name").GetComponent<TMPro.TextMeshProUGUI>().text = recipe_data.name;

            current_image = current_recipe_cooker.transform.Find("display_recipe_image").GetComponent<Image>();
            current_sprite = LoadSprite(Application.dataPath + recipe_data.path_sprite);
            current_image.sprite = current_sprite;

            current_image = current_recipe_cooker.transform.Find("ressource1_image").GetComponent<Image>();
            current_sprite = LoadSprite(Application.dataPath + recipe_data.r_path_sprite_1);
            current_image.sprite = current_sprite;

            current_text = current_recipe_cooker.transform.Find("ressource1_text").GetComponent<TMPro.TextMeshProUGUI>();
            current_text.text = recipe_data.amount1.ToString();

            if(recipe_data.amount2 != 0){
                current_image = current_recipe_cooker.transform.Find("ressource2_image").GetComponent<Image>();
                current_sprite = LoadSprite(Application.dataPath + recipe_data.r_path_sprite_2);
                current_image.sprite = current_sprite;

                current_text = current_recipe_cooker.transform.Find("ressource2_text").GetComponent<TMPro.TextMeshProUGUI>();
                current_text.text = recipe_data.amount2.ToString();
            }
            else{
                Destroy(current_recipe_cooker.transform.Find("ressource2_image").GetComponent<Image>());
                Destroy(current_recipe_cooker.transform.Find("ressource2_text").GetComponent<TMPro.TextMeshProUGUI>());
            }

            if(recipe_data.amount3 != 0){
                current_image = current_recipe_cooker.transform.Find("ressource3_image").GetComponent<Image>();
                current_sprite = LoadSprite(Application.dataPath + recipe_data.r_path_sprite_3);
                current_image.sprite = current_sprite;

                current_text = current_recipe_cooker.transform.Find("ressource3_text").GetComponent<TMPro.TextMeshProUGUI>();
                current_text.text = recipe_data.amount3.ToString();
            }
            else{
                Destroy(current_recipe_cooker.transform.Find("ressource3_image").GetComponent<Image>());
                Destroy(current_recipe_cooker.transform.Find("ressource3_text").GetComponent<TMPro.TextMeshProUGUI>());
            }

        }

    }

    public void delete_cooker(){
        foreach(Transform child in transform){
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

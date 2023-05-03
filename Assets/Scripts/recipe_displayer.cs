using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine;

public class recipe_displayer : MonoBehaviour
{
    public GameObject recipe_prefab;
    public Image display_recipe_image;
    // Start is called before the first frame update
    void Start()
    {
        string json = File.ReadAllText(Application.dataPath + "/Scripts/recipe.json");
        RecipeList recipe_array = JsonUtility.FromJson<RecipeList>(json); 
        foreach (Recipe recipe_data in recipe_array.recipe_list) {
            GameObject new_recipe = Instantiate(recipe_prefab, transform);    
            display_recipe_image = new_recipe.transform.Find("display_recipe_image").GetComponent<Image>();
            display_recipe_image.sprite = Resources.Load<Sprite>(Application.dataPath + recipe_data.path_sprite);
            Debug.Log("Nique ta mère avec t'es POH ");

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

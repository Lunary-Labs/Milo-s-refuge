using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progress_bar_cooker : MonoBehaviour
{
    public GameObject image_component;
    public GameObject game_manager;
    public cooker cooker_script;
    public Image progress_bar;
    private int current_cooker;
    // Start is called before the first frame update
    void Start()
    {
        progress_bar = image_component.GetComponent<Image>();
        game_manager = GameObject.Find("game_manager");
        cooker_script = game_manager.GetComponent<cooker>();
        current_cooker = int.Parse(transform.parent.parent.name);
    }

    // Update is called once per frame
    void Update()
    {
        if(cooker_script.cookers[current_cooker].started){
            float timer = (float)cooker_script.recipe_dict[cooker_script.cookers[current_cooker].recipe].duration;
            progress_bar.fillAmount = cooker_script.cookers[current_cooker].timer/timer;
        }
        else{
            progress_bar.fillAmount = 0;
        }
    }
}

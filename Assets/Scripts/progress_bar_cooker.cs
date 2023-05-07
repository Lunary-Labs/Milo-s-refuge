using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progress_bar_cooker : MonoBehaviour
{
    public GameObject image_component;
    public GameObject game_manager;
    public cooker cooker_object;
    public Image progress_bar;
    // Start is called before the first frame update
    void Start()
    {
        progress_bar = image_component.GetComponent<Image>();
        game_manager = GameObject.Find("game_manager");
        cooker_object = game_manager.GetComponent<cooker>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cooker_object.cooker_1_started){
            float timer = (float)cooker_object.recipe_dict[cooker_object.recipe_cooker_1].duration;
            progress_bar.fillAmount = cooker_object.timer_cooker_1/timer;
        }
        else{
            progress_bar.fillAmount = 0;
        }
    }
}

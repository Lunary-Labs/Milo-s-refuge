using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button_change_recipe : MonoBehaviour
{

    public GameObject change_recipe_ui;
    public GameObject cooker_ui;
    public recipe_displayer recipe_displayer_script;
    public GameObject close;
    void Start()
    {
        change_recipe_ui = transform.parent.parent.parent.parent.parent.Find("change_recipe_ui").gameObject;
        recipe_displayer_script = change_recipe_ui.transform.Find("Viewport").transform.Find("cooker_1_change").GetComponent<recipe_displayer>();
        cooker_ui = transform.parent.parent.parent.parent.gameObject;
        close = GameObject.Find("close");
    }
    public void on_click(GameObject button){
        change_recipe_ui.SetActive(true);
        cooker_ui.SetActive(false);
        recipe_displayer_script.create_recipe_list_ui(button);
        close.GetComponent<Button>().onClick.Invoke();
    }
}

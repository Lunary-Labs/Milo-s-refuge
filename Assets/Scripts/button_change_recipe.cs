using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button_change_recipe : MonoBehaviour
{
    private GameObject menu_manager_gameobject;
    private menu_cooker menu_cooker_script;
    private GameObject close;

    void Start()
    {
        menu_manager_gameobject = GameObject.Find("menu_manager");
        menu_cooker_script = menu_manager_gameobject.GetComponent<menu_cooker>();
        close = GameObject.Find("close");
    }
    public void on_click(GameObject button){
        Debug.Log("yeaah");
        menu_cooker_script.delete_cooker_list();
        menu_cooker_script.create_recipe_list_ui(button);  
        close.GetComponent<Button>().onClick.Invoke();
        menu_cooker_script.save_current_cooker(transform.parent.name);
        menu_cooker_script.state_change_recipe_ui(true);
        menu_cooker_script.state_cooker_ui(false);
    }
}

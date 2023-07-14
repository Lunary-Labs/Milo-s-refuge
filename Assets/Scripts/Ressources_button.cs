using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ressources_button : MonoBehaviour
{
    public Menu_ressources menu_ressources_script;
    public bool dragging;

    void Start(){
        this.dragging = false; 
    }

    public void end_drag(){
        Debug.Log("end drag");
        menu_ressources_script.set_is_dragging(false);
    }

    public void begin_drag(){
        Debug.Log("begin drag");
        menu_ressources_script.set_is_dragging(true);
    }
}

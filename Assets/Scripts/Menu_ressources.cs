using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine;

public class Menu_ressources : MonoBehaviour
{


    public GameObject back;
    public Button slider_button; 
    public bool is_dragging; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(is_dragging){
            move_menu();
        }
        
    }

    public void set_is_dragging(bool boolean){
        this.is_dragging = boolean;
    }

    public void move_menu(Button slider){
        Debug.Log(slider.transform.position);
    }

    public void move_menu(){
        float offset = 728f;
        Vector3 new_position = new Vector3(Input.GetAxis("Mouse X") + offset, back.transform.position.y, back.transform.position.z);
        back.transform.position = new_position;    
        }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{

    public int gold = 0;

    public int wheat = 0;
    public int milk = 0;

    public int prestige = 0;
    
    public void remove_ressource(string ressource_name, int amount){
        switch (ressource_name)
        {
            case "gold":
                gold -= amount;
                break;
            case "wheat":
                wheat -= amount;
                break;
            case "milk":
                milk -= amount;
                break;
            default:
                break;
        }
    }

    public int get_ressource(string ressource_name){
        switch (ressource_name)
        {
            case "gold":
                return gold;
            case "wheat":
                return wheat;
            case "milk":
                return milk;
            default:
                return 0;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{

    public int prestige = 0;
    public int gold = 0;

    // ressources
    public int wheat = 0;
    public int carrot = 0;
    public int tomato = 0;
    public int corn = 0;
    public int eggplant = 0;
    public int cabbage = 0;
    public int salad = 0;
    public int pumpkin = 0;
    public int pickle = 0;
    public int radish = 0;
    public int sugar_cane = 0;

    // animals
    public int milk = 0;
    public int eggs = 0;
    public int wool = 0;
    public int honey = 0;

    // materials
    public int wood = 0;
    public int stone = 0;
    public int iron = 0;

    // mid products
    public int flour = 0;
    public int sugar = 0;

    // Finished products values
    enum finished_product {
        bread = 10,
        cake = 20,
        cheese = 30,
        pumpkin_soup = 40,
        radish_salad = 50,
    }

    public void change_ressource (string ressource_name, int amount) {    
        switch (ressource_name) {
            case "gold":
                gold += amount;
                break;
            case "wheat":
                wheat += amount;
                break;
            case "carrot":
                carrot += amount;
                break;
            case "tomato":
                tomato += amount;
                break;
            case "corn":
                corn += amount;
                break;
            case "eggplant":
                eggplant += amount;
                break;
            case "cabbage":
                cabbage += amount;
                break;
            case "salad":   
                salad += amount;
                break;
            case "pumpkin":
                pumpkin += amount;
                break;
            case "pickle":  
                pickle += amount;
                break;
            case "radish":  
                radish += amount;
                break;
            case "sugar_cane":
                sugar_cane += amount;
                break;
            case "milk":
                milk += amount;
                break;
            case "eggs":   
                eggs += amount;
                break;
            case "wool":
                wool += amount;
                break;
            case "honey":
                honey += amount;
                break;
            case "wood":
                wood += amount;
                break;
            case "stone":  
                stone += amount;
                break;
            case "iron":
                iron += amount;
                break;
            case "flour":
                flour += amount;
                break;
            case "sugar":
                sugar += amount;
                break;
            default:
                break;
        }
    }

    public int get_ressource (string ressource_name) {
        switch (ressource_name)
        {
            case "gold":
                return gold;
            case "wheat":
                return wheat;
            case "carrot":
                return carrot;
            case "tomato":
                return tomato;
            case "corn":
                return corn;
            case "eggplant":
                return eggplant;
            case "cabbage":
                return cabbage;
            case "salad":   
                return salad;
            case "pumpkin":
                return pumpkin;
            case "pickle":  
                return pickle;
            case "radish":  
                return radish;
            case "sugar_cane":
                return sugar_cane;
            case "milk":
                return milk;    
            case "eggs":   
                return eggs;
            case "wool":
                return wool;
            case "honey":
                return honey;
            case "wood":
                return wood;
            case "stone":  
                return stone;
            case "iron":
                return iron;
            case "flour":
                return flour;
            case "sugar":
                return sugar;
            default:
                return 0;
        }
    }

    public void add_finished_product (string product) {
        // get value from enum with product string
        gold += (int)System.Enum.Parse(typeof(finished_product), product);
    }
}


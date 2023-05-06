using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class island : MonoBehaviour
{
    public List<GameObject> fields = new List<GameObject>();
    public List<GameObject> cats = new List<GameObject>();
    private TilemapCollider2D[] child_tilemap_colliders;

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

    public int total_island_ressources;

    void Start() {
        foreach (Transform child in transform) {
            if (child.name == "field") {
                fields.Add(child.gameObject);
            } else if (child.name == "cat") {
                cats.Add(child.gameObject);
            }
        }
        child_tilemap_colliders = GetComponentsInChildren<TilemapCollider2D>();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            // get mouse position
            Vector3 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // check if the mouse is over a tilemap collider
            foreach (TilemapCollider2D tilemap_collider in child_tilemap_colliders) {
                if (tilemap_collider.OverlapPoint(mouse_position)) {
                    harvest();
                }
            }
        }
        total_island_ressources = wheat + carrot + tomato + corn + eggplant + cabbage + salad + pumpkin + pickle + radish + sugar_cane + milk + eggs + wool + honey + wood + stone + iron;
    }

    void harvest () {
        foreach (GameObject field in fields) {
            List<GameObject> field_tiles = field.GetComponent<field>().field_tiles;
            foreach (GameObject tile in field_tiles) {
                if (tile.GetComponent<field_tile>().harvestable) {
                    switch (tile.name)
                    {
                        case "wheat":
                            wheat += 1;
                            break;
                        case "carrot":
                            carrot += 1;
                            break;
                        case "tomato": 
                            tomato += 1;
                            break;
                        case "corn":
                            corn += 1;
                            break;
                        case "eggplant":   
                            eggplant += 1;
                            break;
                        case "cabbage":    
                            cabbage += 1;
                            break;
                        case "salad":  
                            salad += 1;
                            break;
                        case "pumpkin":    
                            pumpkin += 1;
                            break;
                        case "pickle": 
                            pickle += 1;
                            break;
                        case "radish":  
                            radish += 1;
                            break;
                        case "sugar_cane": 
                            sugar_cane += 1;
                            break;
                        case "milk":   
                            milk += 1;
                            break;
                        case "eggs":   
                            eggs += 1;
                            break;
                        case "wool":   
                            wool += 1;
                            break;
                        case "honey":  
                            honey += 1;
                            break;
                        case "wood":   
                            wood += 1;
                            break;  
                        case "stone":  
                            stone += 1;
                            break;
                        case "iron":   
                            iron += 1;
                            break;
                        default:
                            break;
                    }
                    tile.GetComponent<field_tile>().harvest();
                }
            }
        }
    }
}

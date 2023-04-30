using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{

    public int gold = 0;

    public int weath = 0;
    public int milk = 0;

    public int prestige = 0;
    
    public void add_gold(int amount) {
        gold += amount;
    }

    public void remove_gold(int amount) {
        gold -= amount;
    }
}


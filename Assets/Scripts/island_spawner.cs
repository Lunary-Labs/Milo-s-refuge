using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class island_spawner : MonoBehaviour
{
    public int current_lvl = 0 ;
    public int lvl_up = 0;
    private int max_lvl = 1 ;

    public GameObject[] prefabs;
    private GameObject current_prefab;

    // Start is called before the first frame update
    void Start()
    {
        GameObject current_prefab = Instantiate(prefabs[current_lvl], transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(lvl_up > 0 && current_lvl != max_lvl){
            Destroy(current_prefab);
            current_lvl++;
            current_prefab = Instantiate(prefabs[current_lvl],transform.position, Quaternion.identity);
            lvl_up = 0;
        }
    }
}

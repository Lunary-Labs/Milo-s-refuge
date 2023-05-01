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
        this.current_prefab = Instantiate(prefabs[current_lvl], transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        island_lvl_up();
    }

    private void island_lvl_up(){
        if(lvl_up > 0 && current_lvl != max_lvl){
            Destroy(current_prefab);
            current_lvl++;
            this.current_prefab = Instantiate(prefabs[current_lvl],transform.position, Quaternion.identity);
            lvl_up = 0;
        }
    }
}

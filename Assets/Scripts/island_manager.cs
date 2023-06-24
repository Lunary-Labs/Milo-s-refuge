using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class island_manager : MonoBehaviour
{
    public Dictionary<string, int> island_levels = new Dictionary<string, int>();
    public Dictionary<string, int> island_max_levels = new Dictionary<string, int>();

    public GameObject character;
    public GameObject world;

    void Start() {
        world = GameObject.Find("world");
        character = GameObject.Find("game_manager");

        // Add all island levels to island_levels dictionary
        island_levels.Add("main_island", 1);
        island_levels.Add("island_1", 1);
        island_levels.Add("island_2", 0);
        island_levels.Add("island_3", 0);
        island_levels.Add("island_4", 0);
        island_max_levels.Add("main_island", 1);
        island_max_levels.Add("island_1", 2);
        island_max_levels.Add("island_2", 3);
        island_max_levels.Add("island_3", 3);
        island_max_levels.Add("island_4", 3);

        // Instantiate all islands on their spawner position
        foreach (KeyValuePair<string, int> island in island_levels) {
            GameObject spawner = GameObject.Find(island.Key + "_spawner");
            string path = "Prefabs/islands/" + island.Key + "/" + island.Key + "_lvl_" + island.Value.ToString();
            GameObject island_prefab = Resources.Load<GameObject>(path);
            GameObject island_instance = Instantiate(island_prefab, world.transform);
            island_instance.transform.localPosition = spawner.transform.localPosition;
            island_instance.name = island.Key;
        }
    }

    void Update() {
        // test for island 1 upgrade
        if (Input.GetKeyDown(KeyCode.Space)) {
            upgrade_island("island_1");
        }
    }

    public void upgrade_island(string island_name) {
        int next_level = island_levels[island_name] + 1;
        if (next_level > island_max_levels[island_name]) { return; }

        island_levels[island_name] = next_level;

        // Put island ressources in character inventory
        GameObject island = GameObject.Find(island_name);
        island.GetComponent<island>().harvest();
        foreach (KeyValuePair<string, int> ressource in island.GetComponent<island>().ressources) {
            character.GetComponent<character>().change_ressource(ressource.Key, ressource.Value);
        }
        island.transform.Find("boat").GetComponent<boat>().unload();
        
        Destroy(island);

        // Instantiate new island
        GameObject spawner = GameObject.Find(island_name + "_spawner");
        string path = "Prefabs/islands/" + island_name + "/" + island_name + "_lvl_" + next_level.ToString();
        GameObject island_prefab = Resources.Load<GameObject>(path);
        GameObject island_instance = Instantiate(island_prefab, world.transform);
        island_instance.transform.localPosition = spawner.transform.localPosition;
        island_instance.name = island_name;
    }
}

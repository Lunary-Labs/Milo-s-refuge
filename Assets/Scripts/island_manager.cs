using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class IslandData {
    public string name;
    public int level;
    public int max_level;
    public int unlock_cost;
    public int harvest_cost;
    public int growing_cost;
    public int boat_cost;
}

public class IslandList {
    public List<IslandData> islands_data;
}

// Part that will be saved in island_levels.json for every save the player do
public class IslandLevel {
    public int level;
    public int growth_level;
    public int harvest_level;
    public int boat_level;
}

public class island_manager : MonoBehaviour {

    public Dictionary<string, IslandData> island_data;
    public Dictionary<string, IslandLevel> island_levels = new Dictionary<string, IslandLevel>();

    public GameObject character;
    public GameObject world;

    // Initialize island Dicts, GameObject references and instantiate islands.
    public void instatiate_islands() {
        world = GameObject.Find("world");
        character = GameObject.Find("game_manager");

        // Fill dictionnaries with islands.json
        string json = File.ReadAllText(Application.dataPath + "/Json/islands.json");
        IslandList list = JsonUtility.FromJson<IslandList>(json);
        island_data = new Dictionary<string, IslandData>();
        foreach (IslandData data in list.islands_data) {
            island_data.Add(data.name, data);
            IslandLevel temp = new IslandLevel { level = data.level, growth_level = 0, harvest_level = 0, boat_level = 0 };
            island_levels.Add(data.name, temp);
        }

        // Instantiate all islands on their spawner position.
        foreach (KeyValuePair<string, IslandLevel> island in island_levels) {
            instantiate_island(island.Key);
        }
    }

    // Upgrade island level if the player have enought money. 
    // Not used for the first upgrade. see menu/unlock_button.
    // TODO: Money handling.
    public void upgrade_island(string island_name) {
        int next_level = island_levels[island_name].level + 1;
        if (next_level > island_data[island_name].max_level) { return; }

        island_levels[island_name].level = next_level;
        GameObject island = GameObject.Find(island_name);

        // If the island level is superior to 1, put island ressources in character inventory
        if (next_level > 1) {
            island.GetComponent<island>().harvest();
            foreach (KeyValuePair<string, int> ressource in island.GetComponent<island>().ressources) {
                character.GetComponent<character>().change_ressource(ressource.Key, ressource.Value);
            }
            island.transform.Find("boat").GetComponent<boat>().unload();
        }
        
        Destroy(island);
        instantiate_island(island_name);
    }

    // Increase the growth level of the provided island if the player can pay
    public void upgrade_growth(string island_name) {
        if (island_levels[island_name].growth_level < 10) {
            island_levels[island_name].growth_level++;
        }
    }

    // Increase the harvest level of the provided island if the player can pay
    public void upgrade_harvest(string island_name) {
        if (island_levels[island_name].harvest_level < 10) {
            island_levels[island_name].harvest_level++;
        }
    }

    // Increase the boat level of the provided island if the player can pay
    public void upgrade_boat(string island_name) {
        if (island_levels[island_name].boat_level < 10) {
            island_levels[island_name].boat_level++;
        }
    }

    // Instantiate the provided island on its respective spawner
    public void instantiate_island(string island_name) {
        GameObject spawner = GameObject.Find(island_name + "_spawner");
        string path = "Prefabs/islands/" + island_name + "/" + island_name + "_lvl_" + island_levels[island_name].level.ToString();
        GameObject island_prefab = Resources.Load<GameObject>(path);
        GameObject island_instance = Instantiate(island_prefab, world.transform.Find("islands"));
        island_instance.transform.localPosition = spawner.transform.localPosition;
        island_instance.name = island_name;
    }
}

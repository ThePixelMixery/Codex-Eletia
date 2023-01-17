using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    public string mapSaveLocation;

    public string mapFolderLocation;

    public GameObject worldMapPanel;

    public GameObject localMapPanel;

    public GameObject stateInstance;

    public List<string> stateNames = new List<string>();

    public TileClass tile;

    public StateClass tempState;

    public void Start()
    {
        mapFolderLocation = (Application.persistentDataPath + "/Saves/Map");

        if (!Directory.Exists(mapFolderLocation))
        {
            Debug.LogError("Map Directory not found");
            Directory.CreateDirectory (mapFolderLocation);
        }
        mapSaveLocation =
            Application.persistentDataPath + "/Saves/MapData.json";
        mapFolderLocation = Application.persistentDataPath + "/Saves/Map/";
        if (System.IO.File.Exists(mapSaveLocation))
        {
            string json = File.ReadAllText(mapSaveLocation);
            stateNames = json.Split(',').ToList();
            Debug.Log("Map Loaded");
        }
        else
        {
            Debug.LogError("Map not found at " + mapSaveLocation);
            Directory
                .CreateDirectory(Application.persistentDataPath + "/Saves/Map");
        }
        foreach (string name in stateNames)
        {
            string json = File.ReadAllText(mapFolderLocation + name + ".json");
            tempState = JsonUtility.FromJson<StateClass>(json);

            ObjectGenerator (tempState);
        }
    }

    public void SaveMapFile()
    {
    }

    public void DeleteFiles()
    {
        if (System.IO.File.Exists(mapSaveLocation))
        {
            File.Delete (mapSaveLocation);
            Directory.Delete(mapFolderLocation, true);
            stateNames.Clear();
            Debug.Log("Map Deleted");
        }
        else
        {
            Debug.LogError("Map not found at " + mapSaveLocation);
        }
        AssetDatabase.Refresh();
    }

    public void MapLoader()
    {
    }

    public void MapCreator()
    {
        HashSet<int> stateTypeNumbers = new HashSet<int>();
        while (stateTypeNumbers.Count < 14)
        {
            stateTypeNumbers.Add(Random.Range(0, 14));
        }
        foreach (int type in stateTypeNumbers)
        {
            StateClass newState = new StateClass(type);

            stateNames.Add(newState.stateName);
            string stateList = string.Join(",", stateNames);

            System.IO.File.WriteAllText (mapSaveLocation, stateList);
            Debug.Log("State Created: " + newState.stateName);
            string state = JsonUtility.ToJson(newState);
            System
                .IO
                .File
                .WriteAllText(mapFolderLocation + newState.stateName + ".json",
                state);
            Directory
                .CreateDirectory(Application.persistentDataPath +
                "/Saves/Map/" +
                newState.stateName);
        }
    }

    public void ObjectGenerator(StateClass tempState)
    {
        GameObject statePrefab;
        statePrefab = Instantiate(stateInstance, worldMapPanel.transform);
        StateScript prefabScript =
            statePrefab.GetComponentInChildren<StateScript>();
        prefabScript.state = tempState;
        prefabScript.stateTitle.text = prefabScript.state.stateName;
        prefabScript.stateSpec =
            prefabScript.SpecFancy(prefabScript.state.specialisation);
    }
}

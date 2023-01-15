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

    public GameObject MapObjectParent;

    public GameObject LocalMapPanel;

    public List<string> stateNames = new List<string>();

    public TileClass tile;

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
        MapLoader();
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
    }

    public void mapSizer(int size)
    {
        switch (size)
        {
            case 0:
                SmallMapCreator();
                break;
            case 1:
                break;
            case 2:
                break;
            default:
                break;
        }
    }

    public void SmallMapCreator()
    {
        StateClass newState = new StateClass("Wawoo'in", 7);
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
        if (stateNames.Contains(newState.stateName))
        {
            Debug.LogError("State already exists: " + newState.stateName);
        }
        else
        {
            stateNames.Add(newState.stateName);
            string stateList = string.Join(",", stateNames);
            System.IO.File.WriteAllText (mapSaveLocation, stateList);
            Debug.Log("State Created: " + newState.stateName);
        }
    }
}

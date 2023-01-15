using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;


public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    private MapData _MapData = new MapData();

    public string mapSaveLocation;

    public string mapFolderLocation;

    public GameObject MapObjectParent;

    public GameObject LocalMapPanel;

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

        MapLoader();
    }

    public void SaveMapFile()
    {
        string map = JsonUtility.ToJson(_MapData);
        System.IO.File.WriteAllText (mapSaveLocation, map);
        Debug.Log("Map saved");
    }

    public void DeleteFiles()
    {
        if (System.IO.File.Exists(mapSaveLocation))
        {
            File.Delete(mapSaveLocation);
            Directory.Delete (mapFolderLocation,true);
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
            _MapData = JsonUtility.FromJson<MapData>(json);
            Debug.Log("Map Loaded");
        }
        else
        {
            Debug.LogError("Map not found at " + mapSaveLocation);
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
    StateClass newState = new StateClass("Bajoo",4);
    newState.StateSaver();
    }
}

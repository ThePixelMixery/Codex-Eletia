using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField]
    public MapData _MapData = new MapData();

    [SerializeField]
    private KeeperData _KeeperData = new KeeperData();

    private string keeperSaveLocation;

    private string mapSaveLocation;

    void Start()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/Saves"))
        {
            Debug.LogError("Save Directory not found");
            Directory
                .CreateDirectory(Application.persistentDataPath + "/Saves");
        }
        keeperSaveLocation =
            Application.persistentDataPath + "/Saves/KeeperData.json";
        mapSaveLocation = Application.persistentDataPath + "/Saves/MapData.json";
        LoadFiles();
    }

    public void SaveFiles()
    {
        string keeper = JsonUtility.ToJson(_KeeperData);
        System.IO.File.WriteAllText (keeperSaveLocation, keeper);
        string map = JsonUtility.ToJson(_MapData);
        System.IO.File.WriteAllText (mapSaveLocation, map);
        Debug.Log("Keeper and map saved");
    }

    public void LoadFiles()
    {
        if (System.IO.File.Exists(keeperSaveLocation))
        {
            string json = File.ReadAllText(keeperSaveLocation);
            _KeeperData = JsonUtility.FromJson<KeeperData>(json);
            Debug.Log("Keeper Loaded");
        }
        else
        {
            Debug.LogError("Keeper not found at " + keeperSaveLocation);
        }
        if (System.IO.File.Exists(mapSaveLocation))
        {
            string json = File.ReadAllText(mapSaveLocation);
        }
        else
        {
            Debug.LogError("Map not found at " + mapSaveLocation);
        }
    }

    public void DeleteFiles()
    {
        if (System.IO.File.Exists(keeperSaveLocation))
        {
            File.Delete (keeperSaveLocation);
            Debug.Log("Keeper Deleted");
        }
        else
        {
            Debug.LogError("Keeper not found at " + keeperSaveLocation);
        }
        if (System.IO.File.Exists(mapSaveLocation))
        {
            File.Delete (mapSaveLocation);
            Debug.Log("Map Deleted");
        }
        else
        {
            Debug.LogError("Map not found at " + mapSaveLocation);
        }
        AssetDatabase.Refresh();
    }
}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField]
    private MapData _MapData = new MapData();

    void Start()
    {
        LoadMapFile();
        LoadKeeperFile();
    }

    public void SaveMapFile()
    {
        string destination =
            Path.Combine(Application.persistentDataPath, "/MapData.json");
        FileStream file;

        if (File.Exists(destination))
            file = File.OpenWrite(destination);
        else
        {
            file = File.Create(destination);
        }
        string map = JsonUtility.ToJson(_MapData);
        System
            .IO
            .File
            .WriteAllText(Application.persistentDataPath + "/MapData.json",
            map);
        Debug.Log("Map Saved!");
    }

    public void LoadMapFile()
    {
        string destination =
            Path.Combine(Application.persistentDataPath, "/MapData.json");
        FileStream file;

        if (File.Exists(destination))
        {
            Debug.Log("Loaded Map");
            file = File.OpenRead(destination);
        }
        else
        {
            Debug.Log("File not found");
            _MapData.mapTiles = GameObject.FindGameObjectsWithTag("Maptile");
            return;
        }

        string json = File.ReadAllText(destination);
        _MapData = JsonUtility.FromJson<MapData>(json);
        file.Close();
    }

    [SerializeField]
    private KeeperData _KeeperData = new KeeperData();

    public void SaveKeeperFile()
    {
        string destination =
            Path.Combine(Application.persistentDataPath, "/KeeperData.json");
        FileStream file;

        if (File.Exists(destination))
            file = File.OpenWrite(destination);
        else
            file = File.Create(destination);

        string map = JsonUtility.ToJson(_KeeperData);
        System
            .IO
            .File
            .WriteAllText(Application.persistentDataPath + "/KeeperData.json",
            map);
        Debug.Log("Keeper Saved!");
    }

    public void LoadKeeperFile()
    {
        string destination =
            Path.Combine(Application.persistentDataPath, "/KeeperData.json");
        FileStream file;

        if (File.Exists(destination))
        {
            file = File.OpenRead(destination);
            Debug.Log("Loaded Keeper");
        }
        else
        {
            Debug.LogError("File not found");
            return;
        }

        string json = File.ReadAllText(destination);
        _KeeperData = JsonUtility.FromJson<KeeperData>(json);
        file.Close();
    }
}

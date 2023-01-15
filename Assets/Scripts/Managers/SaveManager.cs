using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class SaveManager : MonoBehaviour
{

    [SerializeField]
    private KeeperData _KeeperData = new KeeperData();

    private string keeperSaveLocation;


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
        LoadFiles();
    }

    public void SaveFiles()
    {
        string keeper = JsonUtility.ToJson(_KeeperData);
        System.IO.File.WriteAllText (keeperSaveLocation, keeper);
        Debug.Log("Keeper saved");
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
        AssetDatabase.Refresh();
    }

    public void Refesh()
    {
        AssetDatabase.Refresh();
    }
}

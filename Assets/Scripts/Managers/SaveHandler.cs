using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SaveHandler : MonoBehaviour
{
    string saveLocation;

    public GameData _GameData = new GameData();

    public GameObject MenuManager;

    MenuManager menus;

    public GameObject mapCreator;

    string saveJson;

    void Start()
    {
        menus = MenuManager.GetComponentInChildren<MenuManager>();
        saveLocation = Application.persistentDataPath + "/Saves/GameData.json";
        _GameData.stateCoords = new StateClass[16];
        if (System.IO.File.Exists(saveLocation))
        {
            Loader();
        }
        else
        {
            Debug.LogError("Savefile not found at " + saveLocation);
            Directory
                .CreateDirectory(Application.persistentDataPath + "/Saves");
        }
    }

    public void SaveFile()
    {
        _GameData.keeper.tileX = menus.keeperTileX;
        _GameData.keeper.tileY = menus.keeperTileY;
        _GameData.keeper.stateX = menus.keeperStateX;
        _GameData.keeper.stateY = menus.keeperStateY;

        saveJson = JsonUtility.ToJson(_GameData);
        System.IO.File.WriteAllText (saveLocation, saveJson);
        Debug.Log("Game Saved!");
    }

    public void DeleteFiles()
    {
        _GameData.keeper.tileX = 0;
        _GameData.keeper.tileY = 0;

        menus.keeperTileX = 0;
        menus.keeperTileY = 0;
        if (System.IO.File.Exists(saveLocation))
        {
            File.Delete (saveLocation);

            Debug.Log("Save Deleted");
        }
        else
        {
            Debug.LogError("Save not found at " + saveLocation);
        }

        foreach (Transform child in menus.worldMapList.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in menus.worldMapPanel.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in menus.localMapPanel.transform)
        {
            Destroy(child.gameObject);
        }

        AssetDatabase.Refresh();
    }

    public void RefreshAssets()
    {
        AssetDatabase.Refresh();
    }

    public void Loader()
    {
        saveJson = File.ReadAllText(saveLocation);
        _GameData = JsonUtility.FromJson<GameData>(saveJson);
        menus.LoadUI();
    }

    public void MapChecker()
    {
        if (System.IO.File.Exists(saveLocation))
        {
            Debug.LogError("Map Already exists. Denied");
        }
        else
            mapCreator.GetComponentInChildren<MapCreator>().MapBase();
    }

    public void KeeperLocationUpdate(int tileX, int tileY, int stateX, int stateY)
    {
    _GameData.keeper.tileX = tileX;
    _GameData.keeper.tileX = tileY;
    _GameData.keeper.stateX = stateX;
    _GameData.keeper.stateX = stateY;
    Debug.Log("Keeper dropped onto state: "+stateX+", "+stateY+ " at tile "+ tileX+", "+tileY);
    }
}

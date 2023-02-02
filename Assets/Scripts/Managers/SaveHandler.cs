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

    public GameObject MapManager;

    MapManager maps;

    public GameObject clockObject;

    TimeScript clock;

    public GameObject mapCreator;

    string saveJson;

    void Start()
    {
        maps = MapManager.GetComponentInChildren<MapManager>();
        clock = clockObject.GetComponentInChildren<TimeScript>();
        saveLocation = Application.persistentDataPath + "/Saves/GameData.json";
        _GameData.stateCoords = new State[16];

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
        _GameData.keeper.tileX = maps.keeperTileX;
        _GameData.keeper.tileY = maps.keeperTileY;
        _GameData.keeper.stateX = maps.keeperStateX;
        _GameData.keeper.stateY = maps.keeperStateY;
        _GameData.keeper.state = maps.keeperCurrentState;
        _GameData.keeper.time = clock.time;

        int index = 0;
        foreach (Tile tile in maps.saveCurrentTiles)
        {
            _GameData.stateCoords[_GameData.keeper.state].tiles[index] =
                maps.saveCurrentTiles[index];
            index++;
        }

        saveJson = JsonUtility.ToJson(_GameData);
        System.IO.File.WriteAllText (saveLocation, saveJson);
        Debug.Log("Game Saved!");
    }

    public void DeleteFiles()
    {
        _GameData.keeper.time = 7;

        _GameData.keeper.tileX = 0;
        _GameData.keeper.tileY = 0;

        maps.keeperTileX = 0;
        maps.keeperTileY = 0;
        if (System.IO.File.Exists(saveLocation))
        {
            File.Delete (saveLocation);

            Debug.Log("Save Deleted");
        }
        else
        {
            Debug.LogError("Save not found at " + saveLocation);
        }

        foreach (Transform child in maps.worldMapList.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in maps.worldMapPanel.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in maps.localMapPanel.transform)
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
        maps.LoadUI();
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

    public void KeeperLocationUpdate(
        int tileX,
        int tileY,
        int stateX,
        int stateY,
        int stateId
    )
    {
        _GameData.keeper.state = stateId;
        _GameData.keeper.stateX = stateX;
        _GameData.keeper.stateX = stateY;
        _GameData.keeper.tileX = tileX;
        _GameData.keeper.tileX = tileY;
        Debug
            .Log("Keeper dropped onto state: (ID: " +
            stateId +
            ")" +
            stateX +
            ", " +
            stateY +
            " at tile " +
            tileX +
            ", " +
            tileY);
    }
}

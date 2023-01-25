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

    public UIController _UIControl = new UIController();

    string saveJson;

    StateClass currentState;

    int keeperCurrentState;

    int keeperStateX;

    int keeperStateY;

    int keeperTileX;

    int keeperTileY;

    public GameObject[] testCurrentTiles = new GameObject[104];

    GameObject[,] currentTiles = new GameObject[13, 8];

    GameObject[] miniMapTiles = new GameObject[9];

    void Start()
    {
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
        _GameData.keeper.tileX = keeperTileX;
        _GameData.keeper.tileY = keeperTileY;
        _GameData.keeper.stateX = keeperStateX;
        _GameData.keeper.stateY = keeperStateY;
        

        saveJson = JsonUtility.ToJson(_GameData);
        System.IO.File.WriteAllText (saveLocation, saveJson);
    }

    public void DeleteFiles()
    {
        _GameData.keeper.tileX = 0;
        _GameData.keeper.tileY = 0;
        keeperTileX = 0;
        keeperTileY = 0;
        if (System.IO.File.Exists(saveLocation))
        {
            File.Delete (saveLocation);
            foreach (Transform child in _UIControl.worldMapList.transform)
            {
                Destroy(child.gameObject);
            }
            foreach (Transform child in _UIControl.worldMapPanel.transform)
            {
                Destroy(child.gameObject);
            }
            foreach (Transform child in _UIControl.localMapPanel.transform)
            {
                Destroy(child.gameObject);
            }

            Debug.Log("Save Deleted");
        }
        else
        {
            Debug.LogError("Save not found at " + saveLocation);
        }
        AssetDatabase.Refresh();
    }

    public void RefreshAssets()
    {
        AssetDatabase.Refresh();
    }

    public void Loader()
    {
        foreach (Transform child in _UIControl.worldMapList.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in _UIControl.worldMapPanel.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in _UIControl.localMapPanel.transform)
        {
            Destroy(child.gameObject);
        }

        saveJson = File.ReadAllText(saveLocation);
        _GameData = JsonUtility.FromJson<GameData>(saveJson);
        keeperStateX = _GameData.keeper.stateX;
        keeperStateY = _GameData.keeper.stateY;
        foreach (StateClass state in _GameData.stateCoords)
        {
            if (
                _GameData.keeper.stateX == state.x &&
                _GameData.keeper.stateY == state.y
            ) currentState = state;
        }

        keeperTileX = _GameData.keeper.tileX;
        keeperTileY = _GameData.keeper.tileY;
        WorldMapUI();
        LocalMapUI(currentState.tiles);
        MiniMapUI();
    }

    public void MapMade(int tileX, int tileY, int stateX, int stateY, StateClass state)
    {
        EventTracker
            .NewEvent(0,
            "You have discovered a giant egg in your home nation of " +
            state.stateName);
        currentState = state;
        WorldMapUI();
        LocalMapUI(currentState.tiles);
        MiniMapUI();
        SaveFile();
    }

    void WorldMapUI()
    {
        foreach (StateClass state in _GameData.stateCoords)
        {
            GameObject statePrefab =
                Instantiate(_UIControl.stateInstance,
                _UIControl.worldMapList.transform);
            StateScript prefabScript =
                statePrefab.GetComponentInChildren<StateScript>();
            StateClass createState = state;

            Sprite tempSprite = _UIControl.stateSprites[state.type];
            prefabScript
                .StateCreate(createState, _UIControl.worldMapPanel, tempSprite);
            statePrefab.SetActive(prefabScript.state.discovered);
        }
    }

    void LocalMapUI(TileClass[] tiles)
    {
        int index = 0;
        foreach (TileClass tile in tiles)
        {
            GameObject tilePrefab =
                Instantiate(_UIControl.tileInstance,
                _UIControl.localMapPanel.transform);
            Sprite tempSprite = _UIControl.tile;
            TileScript tileScript =
                tilePrefab.GetComponentInChildren<TileScript>();
            if (tile.x == keeperTileX && tile.y == keeperTileY)
            {
                _UIControl.TilePosition = tilePrefab;
                tempSprite = _UIControl.keeper;
            }
            tileScript.TileCreate (tile, tempSprite);
            UpdateCurrentTiles(tilePrefab,
            tileScript.tile.x,
            tileScript.tile.y,
            index);
            index++;
        }
    }

    void UpdateCurrentTiles(GameObject tile, int x, int y, int index)
    {
        testCurrentTiles[index] = tile;
        currentTiles[x, y] = tile;
    }

    void MiniMapUI()
    {
        foreach (Transform child in _UIControl.miniMapPanel.transform)
        Destroy(child.gameObject);
        Array.Clear(miniMapTiles, 0, 9);
        for (int j = 0; j < 8; j++)
        {
            for (int k = 0; k < 13; k++)
            {
                if (keeperTileX - 1 == k && keeperTileY - 1 == j)
                {
                    miniMapTiles[0] = currentTiles[k, j];
                }
                else if (keeperTileX == k && keeperTileY - 1 == j)
                {
                    miniMapTiles[1] = currentTiles[k, j];
                }
                else if (keeperTileX + 1 == k && keeperTileY - 1 == j)
                {
                    miniMapTiles[2] = currentTiles[k, j];
                }
                else if (keeperTileX - 1 == k && keeperTileY == j)
                {
                    miniMapTiles[3] = currentTiles[k, j];
                }
                else if (keeperTileX == k && keeperTileY == j)
                {
                    miniMapTiles[4] = currentTiles[k, j];
                }
                else if (keeperTileX + 1 == k && keeperTileY == j)
                {
                    miniMapTiles[5] = currentTiles[k, j];
                }
                else if (keeperTileX - 1 == k && keeperTileY + 1 == j)
                {
                    miniMapTiles[6] = currentTiles[k, j];
                }
                else if (keeperTileX == k && keeperTileY + 1 == j)
                {
                    miniMapTiles[7] = currentTiles[k, j];
                }
                else if (keeperTileX + 1 == k && keeperTileY + 1 == j)
                {
                    miniMapTiles[8] = currentTiles[k, j];
                }
            }
        }
        for (int i = 0; i < miniMapTiles.Length; i++)
        {
            //int illegalTile =
            int illegalTile = 0;
            if (miniMapTiles[i] != null)
            {
                illegalTile =
                    miniMapTiles[i]
                        .GetComponentInChildren<TileScript>()
                        .tile
                        .type;

                miniMapTiles[i]
                    .GetComponentInChildren<TileScript>()
                    .Discovery();
                if (i == 4)
                    miniMapTiles[i]
                        .GetComponentInChildren<TileScript>()
                        .UpdateTile(_UIControl.keeper);
                else
                    miniMapTiles[i]
                        .GetComponentInChildren<TileScript>()
                        .UpdateTile(_UIControl.tile);

                Instantiate(miniMapTiles[i], _UIControl.miniMapPanel.transform);
                _UIControl
                    .navButtons[i]
                    .GetComponentInChildren<Button>()
                    .interactable = true;
            }
            else
            {
                _UIControl
                    .navButtons[i]
                    .GetComponentInChildren<Button>()
                    .interactable = false;
                Instantiate(_UIControl.blockedTile,
                _UIControl.miniMapPanel.transform);
            }

            if (illegalTile == 15 || illegalTile == 14)
                _UIControl
                    .navButtons[i]
                    .GetComponentInChildren<Button>()
                    .interactable = false;
        }
    }

    public void UpdateKeeperLocationX(int x)
    {
        if (keeperTileX + x <= 12 && keeperTileX + x >= 0)
        {
            keeperTileX += x;
        }
    }

    public void UpdateKeeperLocationY(int y)
    {
        if (keeperTileY + y <= 7 && keeperTileY + y >= 0)
        {
            keeperTileY += y;
        }
    }

    void updateLocalMap()
    {
        foreach (GameObject tile in currentTiles)
        {
            TileScript script = tile.GetComponentInChildren<TileScript>();
            if (script.tile.x == keeperTileX && script.tile.y == keeperTileY)
                script.UpdateTile(_UIControl.keeper);
            else
                script.UpdateTile(_UIControl.tile);
        }
    }

    public void MapChecker()
    {
        if (System.IO.File.Exists(saveLocation))
        {
            Debug.LogError("Map Already exists. Denied");
        }
        else
        _UIControl.mapCreator.GetComponentInChildren<MapCreator>().MapBase();
    }
}

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

    public Sprite[] tileSprites;

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
            MapCreator();
        }
    }

    public void SaveFile()
    {
        saveJson = JsonUtility.ToJson(_GameData);
        System.IO.File.WriteAllText (saveLocation, saveJson);
    }

    public void DeleteFiles()
    {
        _GameData.keeper.tileX = 0;
        _GameData.keeper.tileY = 0;

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
        keeperTileX = _GameData.keeper.tileX;
        keeperTileY = _GameData.keeper.tileY;
        WorldMapUI();
        LocalMapUI(currentState.tiles);
        MiniMapUI();
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
            bool current;
            if (state.x == keeperStateX && state.y == keeperStateY)
            {
                current = true;
                currentState = state;
                _UIControl.StatePosition = statePrefab;
            }
            else
                current = false;
            StateClass createState = state;

            //state set to disovered
            createState.discovered = true;
            Sprite tempSprite = _UIControl.stateSprites[state.specialisation];
            prefabScript
                .StateCreate(current,
                createState,
                _UIControl.worldMapPanel,
                tempSprite);
            statePrefab.SetActive(prefabScript.state.discovered);
        }
    }

    void LocalMapUI(TileClass[] tiles)
    {
        int index =0;
        foreach (TileClass tile in tiles)
        {
            GameObject tilePrefab =
                Instantiate(_UIControl.tileInstance,
                _UIControl.localMapPanel.transform);
            Sprite tempSprite = _UIControl.tile;
            Debug.Log(tempSprite);
            TileScript tileScript =
                tilePrefab.GetComponentInChildren<TileScript>();
            if (tile.x == keeperTileX && tile.y == keeperTileY)
            {
                _UIControl.TilePosition = tilePrefab;
            }
            else
                tileScript.TileCreate(tile, tempSprite);
            UpdateCurrentTiles(tilePrefab,
            tileScript.tile.x,
            tileScript.tile.y, index);
            index++;
        }
    }

    void UpdateCurrentTiles(GameObject tile, int x, int y, int index)
    {
        testCurrentTiles[index] =tile;
        currentTiles[x, y] = tile;
    }

    public void MiniMapUI()
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
            if (miniMapTiles[i] != null)
            {
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
        }
    }

    public void UpdateKeeperLocationX(int x)
    {
        if (keeperTileX + x <= 12 && keeperTileX + x >= 0)
        {
            keeperTileX += x;
            _GameData.keeper.tileX = keeperTileX;
        }
    }

    public void UpdateKeeperLocationY(int y)
    {
        if (keeperTileY + y <= 7 && keeperTileY + y >= 0)
        {
            keeperTileY += y;
            _GameData.keeper.tileY = keeperTileY;
        }
    }

    public void updateLocalMap()
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

    public void MapCreator()
    {
        if (System.IO.File.Exists(saveLocation))
        {
            Debug.LogError("Map Already exists. Denied");
        }
        else
        {
            HashSet<int> stateTypeNumbers = new HashSet<int>();
            while (stateTypeNumbers.Count < 16)
            {
                stateTypeNumbers.Add(UnityEngine.Random.Range(0, 16));
            }
            int[] stateTypeArray = new int[stateTypeNumbers.Count()];
            stateTypeNumbers.CopyTo (stateTypeArray);
            int index = 0;
            for (int j = 0; j < 4; j++)
            {
                for (int k = 0; k < 4; k++)
                {
                    StateClass newState =
                        new StateClass(stateTypeArray[index],
                            k,
                            j,
                            GenerateTiles(index));

                    _GameData.stateCoords[index] = newState;
                    index++;
                }
            }
            Debug
                .Log("Line 81 of MapGen makes states discovered, marked as breakpoint");
            SaveFile();
            WorldMapUI();
            LocalMapUI(currentState.tiles);
            MiniMapUI();
        }
    }

    TileClass[] GenerateTiles(int type)
    {
        TileClass[] tiles = new TileClass[104];

        //creates tiles
        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i] = new TileClass();
        }

        //Assigns tile x and y
        int index = 0;
        for (int j = 0; j <= 7; j++)
        {
            for (int k = 0; k <= 12; k++)
            {
                tiles[index].x = k;
                tiles[index].y = j;

                index++;
            }
        }

        int[] tileTypes =
        { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 13, 13, 14, 15, -1 };

        /* Type tile list
                0  = fire
                1  = water
                2  = earth
                3  = air
                4  = arcane
                5  = mystic
                6  = time
                7  = ghost
                8  = hallow
                9  = summon
                10 = alchemy (now plant)
                11 = overseer
                12 = channel
                13 = plain
                14 = mountain
                15 = body of water
        */
        //Assigns type
        tileTypes[18] = type;

        for (int i = 0; i < tiles.Length; i++)
        {
            int assignedType = tileTypes[UnityEngine.Random.Range(0, 18)];
            tiles[i].type = assignedType;
            tiles[i].tileColor = _UIControl.tileColours[assignedType];
            if (assignedType == 14 || assignedType == 15)
            {
                tiles[i].access = 0;
            }
        }

        return tiles;
    }
}

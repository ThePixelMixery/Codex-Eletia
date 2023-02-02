using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    public GameObject saveObject;

    SaveHandler save;

    public GameObject miniMapper;

    MiniMapper minimap;

    public GameObject worldMapList;

    public GameObject worldMapPanel;

    public GameObject localMapPanel;

    public GameObject blockedTile;

    public Sprite tileSprite;

    public Sprite keeperSprite;

    public GameObject stateInstance;

    public GameObject tileInstance;

    public GameObject TilePosition;

    public GameObject StatePosition;

    public Color[] tileColours = new Color[16];

    /* colour ref
        new Color(1, 0.5f, 0.5f, 1); //fire
        new Color(0.5f, 1, 1, 1), //water
        new Color(0.75f, 0.5f, 0.25f, 1), //earth
        new Color(1, 1, 0.5f, 1), //air
        new Color(0, 0.5f, 0.75f, 1), //arcane
        new Color(0.5f, 1, 0.5f, 1), //plant
        new Color(0.5f, 0.25f, 0.75f, 1), //mystic
        new Color(1, 0.5f, 0.25f, 1), //time
        new Color(0.5f, 0.5f, 0.5f, 1), //ghost
        new Color(1, 0.5f, 1, 0.75), //hallow
        new Color(0.75f, 0.75f, 0.25f, 1), //summoner
        new Color(0.5f, 0.25f, 0.25f, 1), //overseer
        new Color(0.75f, 0.5f, 0.75, 1), //enchant
        new Color(1, 1, 1, 1), //plain
        new Color(0, 0.25f, 0.5f, 1), //ocean
        new Color(0.5f, 0.25f, 0, 1) //mountain
        */
    public Sprite[] stateSprites;

    public Sprite[] tileFeatures;

    public GameObject[] testCurrentTiles = new GameObject[104];

    GameObject[,] currentTiles = new GameObject[13, 8];

    GameObject[] panels;

    State currentState;

    Tile currentTile;

    int keeperCurrentState;

    public int keeperStateX;

    public int keeperStateY;

    public int keeperTileX;

    public int keeperTileY;

    void Start()
    {
        save = saveObject.GetComponentInChildren<SaveHandler>();
        minimap = miniMapper.GetComponentInChildren<MiniMapper>();
        keeperStateX = save._GameData.keeper.stateX;
        keeperStateY = save._GameData.keeper.stateY;
        keeperTileX = save._GameData.keeper.tileX;
        keeperTileY = save._GameData.keeper.tileY;
    }

    public void MapMade(
        int tileX,
        int tileY,
        int stateX,
        int stateY,
        State state
    )
    {
        EventTracker
            .NewEvent(0,
            "You have discovered a giant egg in your home nation of " +
            state.stateName);
        keeperTileX = tileX;
        keeperTileY = tileY;
        keeperStateX = stateX;
        keeperStateY = stateY;
        currentState = state;
        save.KeeperLocationUpdate (tileX, tileY, stateX, stateY);
        save.SaveFile();
        foreach (Tile tile in state.tiles)
        {
            if (tile.x == keeperTileX && tile.y == keeperTileY)
                currentTile = tile;
        }
        LoadUI();
    }

    public void Reset()
    {
        foreach (Transform child in worldMapList.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in worldMapPanel.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in localMapPanel.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void CloseMenus()
    {
        panels = GameObject.FindGameObjectsWithTag("MainPanel");
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }
    }

    public void LoadUI()
    {
        keeperStateX = save._GameData.keeper.stateX;
        keeperStateY = save._GameData.keeper.stateY;
        keeperTileX = save._GameData.keeper.tileX;
        keeperTileY = save._GameData.keeper.tileY;
        foreach (State state in save._GameData.stateCoords)
        {
            if (keeperStateX == state.x && keeperStateY == state.y)
            {
                foreach (Tile tile in state.tiles)
                {
                    if (keeperTileX == tile.x && keeperTileY == tile.y)
                        currentTile = tile;
                }
                currentState = state;
            }
        }
        WorldMapUI();
        LocalMapUI(currentState.tiles);
        minimap.MiniMapUI (keeperTileX, keeperTileY, currentTiles, currentTile);
    }

    public void ExploreButton()
    {
        minimap.MiniMapUI (keeperTileX, keeperTileY, currentTiles, currentTile);
    }

    void WorldMapUI()
    {
        foreach (State state in save._GameData.stateCoords)
        {
            GameObject statePrefab =
                Instantiate(stateInstance, worldMapList.transform);
            StateScript prefabScript =
                statePrefab.GetComponentInChildren<StateScript>();
            State createState = state;
            if (state.x == keeperStateX && state.y == keeperStateY)
            {
                currentState = state;
                StatePosition = statePrefab;
            }
            Sprite tempSprite = stateSprites[state.type];
            prefabScript.StateCreate (createState, worldMapPanel, tempSprite);
            statePrefab.SetActive(prefabScript.state.discovered);
        }
    }

    void LocalMapUI(Tile[] tiles)
    {
        int index = 0;
        foreach (Tile tile in tiles)
        {
            GameObject tilePrefab =
                Instantiate(tileInstance, localMapPanel.transform);
            Sprite tempSprite = tileSprite;
            TileScript tileScript =
                tilePrefab.GetComponentInChildren<TileScript>();
            if (tile.x == keeperTileX && tile.y == keeperTileY)
            {
                TilePosition = tilePrefab;
                tempSprite = keeperSprite;
            }
            int featureSelect = 0;
            featureSelect = tile.features[0].type;
            Sprite featureSprite1 = tileFeatures[featureSelect];
            featureSelect = tile.features[1].type;
            Sprite featureSprite2 = tileFeatures[featureSelect];
            featureSelect = tile.features[2].type;
            Sprite featureSprite3 = tileFeatures[featureSelect];
            featureSelect = tile.features[3].type;
            Sprite featureSprite4 = tileFeatures[featureSelect];

            tileScript.TileCreate (
                tile,
                tempSprite,
                featureSprite1,
                featureSprite2,
                featureSprite3,
                featureSprite4
            );
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
            {
                script.UpdateTile (keeperSprite);
            }
            else
                script.UpdateTile(tileSprite);
        }
        minimap.MiniMapUI (keeperTileX, keeperTileY, currentTiles, currentTile);
    }
}

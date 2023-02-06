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
    public Color[] tileColours = new Color[16];

    public Sprite[] stateSprites;

    public Sprite[] tileFeatures;

    public State[] tempMap;

    GameObject[] tiles1d = new GameObject[104];

    GameObject[,] tiles2d = new GameObject[13, 8];

    GameObject[] panels;

    public int keeperState;

    public int keeperStateX;

    public int keeperStateY;

    public int keeperTile;

    public int keeperTileX;

    public int keeperTileY;

    //shorthands
    void Start()
    {
        save = saveObject.GetComponentInChildren<SaveHandler>();
        minimap = miniMapper.GetComponentInChildren<MiniMapper>();
    }

    //load map from save to local
    public void LoadSavedMap(
        State[] loadSave,
        int keeperState,
        int keeperStateX,
        int keeperStateY,
        int keeperTile,
        int keeperTileX,
        int keeperTileY
    )
    {
        tempMap = loadSave;
        keeperState = keeperState;
        keeperStateX = keeperStateX;
        keeperStateY = keeperStateY;
        keeperTile = keeperTile;
        keeperTileX = keeperTileX;
        keeperTileY = keeperTileY;
        LoadUI();
    }

    //* move to Save File
    public void MapMade(
        int tileX,
        int tileY,
        Tile tile,
        int stateX,
        int stateY,
        State state
    )
    {
        //Send starter event to tracker
        EventTracker
            .NewEvent(0,
            "You have discovered a giant egg in your home nation of " +
            state.stateName);

        //update current class based on new map
        keeperTileX = tileX;
        keeperTileY = tileY;
        keeperTile = tile.id;
        keeperStateX = stateX;
        keeperStateY = stateY;
        keeperState = state.id;

        // update keeper location in save and save
        save
            .KeeperLocationUpdate(tileX,
            tileY,
            tile.id,
            stateX,
            stateY,
            state.id);
        save.SaveFile();

        //Loads UI
        LoadUI();
    }

    //Delete all map objects
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

    //Changes main area based on top nav buttons
    public void CloseMenus()
    {
        panels = GameObject.FindGameObjectsWithTag("MainPanel");
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }
    }

    //loads UI based on current information
    public void LoadUI()
    {
        WorldMapUI();
        LocalMapUI(tempMap[keeperState].tiles);
    }

    //updates minimap from explore action
    public void ExploreButton()
    {
        minimap.MiniMapUI (
            keeperTileX,
            keeperTileY,
            tiles2d,
            keeperTile,
            keeperState
        );
    }

    //Map > World Object generation
    void WorldMapUI()
    {
        //creates state in state list > creates state tile
        foreach (State state in tempMap)
        {
            GameObject statePrefab =
                Instantiate(stateInstance, worldMapList.transform);
            StateScript prefabScript =
                statePrefab.GetComponentInChildren<StateScript>();
            State createState = state;

            //sets current state
            if (state.x == keeperStateX && state.y == keeperStateY)
            {
                keeperState = state.id;
                StatePosition = statePrefab;
            }
            Sprite tempSprite = stateSprites[state.type];
            prefabScript.StateCreate (createState, worldMapPanel, tempSprite);
            statePrefab.SetActive(prefabScript.state.discovered);
        }
    }

    // 1d array generation
    void LocalMapUI(Tile[] tiles)
    {
        //Creates tile object for local map
        int index = 0;
        foreach (Tile tile in tiles)
        {
            GameObject tilePrefab =
                Instantiate(tileInstance, localMapPanel.transform);
            Sprite tempSprite = tileSprite;
            TileScript tileScript =
                tilePrefab.GetComponentInChildren<TileScript>();

            //differentiates and updates keeper location
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

            //* Updates 2d tiles based on generated objects
            Update2dTiles(tilePrefab, tileScript.tile.x, tileScript.tile.y);

            //* Updates 2d tiles based on generated objects
            Update1dTiles (tilePrefab, index);
            index++;
        }
    }

    // updates current tile array (2d)
    void Update2dTiles(GameObject tile, int x, int y)
    {
        tiles2d[x, y] = tile;
    }

    // updates current tile array (1d)
    void Update1dTiles(GameObject tile, int index)
    {
        tiles1d[index] = tile;
    }

    // Update keeperLocation Horizontal from nav buttons
    public void UpdateKeeperLocationX(int x)
    {
        if (keeperTileX + x <= 12 && keeperTileX + x >= 0)
        {
            keeperTileX += x;
        }
        UpdateLocalMap();
    }

    // Update keeperLocation Vertical from nav buttons
    public void UpdateKeeperLocationY(int y)
    {
        if (keeperTileY + y <= 7 && keeperTileY + y >= 0)
        {
            keeperTileY += y;
        }
        UpdateLocalMap();
    }

    // Update the tile the keeper is on
    public void UpdateCurrentTile(GameObject newTile)
    {
        Tile newTileTile = newTile.GetComponentInChildren<TileScript>().tile;
        if (newTileTile.x == keeperTileX && newTileTile.y == keeperTileY)
        {
            keeperTile = newTileTile.id;
            tempMap[keeperState].tiles[keeperTile] = newTileTile;
            tiles1d[keeperTile] = newTile;
            Update2dTiles(newTile, newTileTile.x, newTileTile.y);
            UpdateLocalMap();
        }
        else
            Debug.LogError("NewTile is not equal to current tile");
    }

    //change local map game objects
    void UpdateLocalMap()
    {
        int index = 0;

        //change differentiate keeper tile and update save tiles
        foreach (GameObject tile in tiles1d)
        {
            TileScript script = tile.GetComponentInChildren<TileScript>();
            if (script.tile.x == keeperTileX && script.tile.y == keeperTileY)
            {
                script.UpdateTile (keeperSprite);
                keeperTile = script.tile.id;
            }
            else
                script.UpdateTile(tileSprite);
            Update2dTiles(tile, script.tile.x, script.tile.y);
            index++;
        }
        minimap.MiniMapUI (
            keeperTileX,
            keeperTileY,
            tiles2d,
            keeperTile,
            keeperState
        );
    }
}

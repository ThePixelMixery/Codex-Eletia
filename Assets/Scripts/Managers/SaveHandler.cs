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

    int keeperStateX;

    int keeperStateY;

    int keeperTileX;

    int keeperTileY;

    public GameObject[] currentTiles = new GameObject[104];

    public Sprite[] stateSprites;

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

    public void Loader()
    {
        saveJson = File.ReadAllText(saveLocation);
        _GameData = JsonUtility.FromJson<GameData>(saveJson);
        _GameData.keeper.stateX = keeperStateX;
        _GameData.keeper.stateY = keeperStateY;
        _GameData.keeper.tileX = keeperTileX;
        _GameData.keeper.tileY = keeperTileY;
        WorldMapUI();
        LocalMapUI(currentState.tiles);
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
            Sprite tempSprite = stateSprites[state.specialisation];
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
        int index = 0;
        foreach (TileClass tile in tiles)
        {
            Sprite tempSprite = tileSprites[tile.type];
            GameObject tilePrefab =
                Instantiate(_UIControl.tileInstance,
                _UIControl.localMapPanel.transform);
            TileScript tileScript =
                tilePrefab.GetComponentInChildren<TileScript>();
            bool current;
            if (tile.x == keeperTileX && tile.y == keeperTileY)
            {
                current = true;
                _UIControl.TilePosition = tilePrefab;
            }
            else
                current = false;

            //tile set to discovered
            tile.discovered = true;
            tileScript.TileCreate (current, tile, tempSprite);
            currentTiles[index] = tilePrefab;
            index++;
        }
    }

    void MapCreator()
    {
        HashSet<int> stateTypeNumbers = new HashSet<int>();
        while (stateTypeNumbers.Count < 16)
        {
            stateTypeNumbers.Add(Random.Range(0, 16));
        }
        int[] stateTypeArray = new int[stateTypeNumbers.Count()];
        stateTypeNumbers.CopyTo (stateTypeArray);
        int j = 0;
        int index = 0;
        while (j < 4)
        {
            for (int k = 0; k < 4; k++)
            {
                StateClass newState =
                    new StateClass(stateTypeArray[index],
                        k,
                        j,
                        GenerateTiles());

                _GameData.stateCoords[index] = newState;
                index++;
            }
            j++;
            //Debug.Log("Tile created: " + k + ", " + j);
        }
        Debug
            .Log("Line 81 of MapGen makes states discovered, marked as breakpoint");
        SaveFile();
        WorldMapUI();
        LocalMapUI(currentState.tiles);
    }

    public void updateTile()
    {
    }

    /*
    public void updateLocalMap(){
    foreach (GameObject tile in currentTiles)
       {
            TileScript script = tile.GetComponentInChildren<TileScript>();
            bool current;
            if (script.tile.x == keeperTileX && script.tile.y == keeperTileY)
                current = true;
            else
                current = false;
            script.UpdateTile(current);
        }
    }
*/
    TileClass[] GenerateTiles()
    {
        TileClass[] tiles = new TileClass[104];

        //creates tiles
        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i] = new TileClass();
        }

        //Assigns tile x and y
        int index = 0;
        int j = 0;
        while (j < 8)
        {
            for (int k = 0; k < 13; k++)
            {
                tiles[index].x = k;
                tiles[index].y = j;

                //Debug.Log("Tile created: " + k + ", " + j);
                index++;
            }
            j++;
        }

        //        Debug.Log("Tiles created");
        return tiles;
    }
}

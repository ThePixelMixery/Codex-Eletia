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

    public Sprite[] stateSprites;

    public Sprite[] tileSprites;

    public void Start()
    {
        saveLocation = Application.persistentDataPath + "/Saves/GameData.json";
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
        _GameData.stateCoords = new StateClass[16];
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
        WorldMapUI();
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
            createState.discovered = true;
            Sprite tempSprite = stateSprites[state.specialisation];
            prefabScript
                .StateCreate(createState, _UIControl.worldMapPanel, tempSprite);
            statePrefab.SetActive(prefabScript.state.discovered);
        }
    }

    void LocalMapUI(StateClass state)
    {
        foreach (TileClass tile in state.tiles)
        {
            Sprite tempSprite = tileSprites[tile.type];
            GameObject tilePrefab =
                Instantiate(_UIControl.tileInstance,
                _UIControl.localMapPanel.transform);
        }
    }

    public void MapCreator()
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
    }

    public TileClass[] GenerateTiles()
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
        Debug.Log("Tiles created");
        return tiles;
    }
}

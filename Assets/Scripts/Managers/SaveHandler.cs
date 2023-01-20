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

    public Sprite[] sprites;

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
    }

    void MapUI()
    {
        foreach (StateClass state in _GameData.stateCoords)
        {
            GameObject statePrefab =
                Instantiate(_UIControl.stateInstance, _UIControl.worldMapList.transform);
            StateScript prefabScript =
                statePrefab.GetComponentInChildren<StateScript>();
            StateClass createState = state;
            createState.discovered = true;
            Sprite tempSprite = sprites[state.specialisation];
            prefabScript.StateCreate (createState, _UIControl.worldMapPanel, tempSprite);
            statePrefab.SetActive(prefabScript.state.discovered);
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
                    new StateClass(stateTypeArray[index], k, j);
                _GameData.stateCoords[index] = newState;
                index++;
            }
            j++;
            //Debug.Log("Tile created: " + k + ", " + j);
        }
        Debug
            .Log("Line 131 of MapGen makes states discovered, marked as breakpoint");
        SaveFile();
        MapUI();
    }
}

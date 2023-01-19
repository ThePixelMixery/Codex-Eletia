using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    public string mapSaveLocation;

    public string mapFolderLocation;

    public GameObject worldMapList;

    public GameObject worldMapPanel;

    public GameObject localMapPanel;

    public GameObject stateInstance;

    public List<string> stateNames = new List<string>();

    public TileClass tile;

    public StateClass tempState;

    public Sprite[] sprites;

    public void Start()
    {
        mapFolderLocation = (Application.persistentDataPath + "/Saves/Map");

        if (!Directory.Exists(mapFolderLocation))
        {
            Debug.LogError("Map Directory not found");
            Directory.CreateDirectory (mapFolderLocation);
        }
        mapSaveLocation =
            Application.persistentDataPath + "/Saves/MapData.json";
        mapFolderLocation = Application.persistentDataPath + "/Saves/Map/";
        if (System.IO.File.Exists(mapSaveLocation))
        {
            string json = File.ReadAllText(mapSaveLocation);
            stateNames = json.Split(',').ToList();
            Debug.Log("Map Loaded");
        }
        else
        {
            Debug.LogError("Map not found at " + mapSaveLocation);
            Directory
                .CreateDirectory(Application.persistentDataPath + "/Saves/Map");
        }
        foreach (string name in stateNames)
        {
            string json = File.ReadAllText(mapFolderLocation + name + ".json");
            tempState = JsonUtility.FromJson<StateClass>(json);

            ObjectGenerator (tempState);
        }
    }

    public void SaveMapFile()
    {
    }

    public void DeleteFiles()
    {
        if (System.IO.File.Exists(mapSaveLocation))
        {
            File.Delete (mapSaveLocation);
            Directory.Delete(mapFolderLocation, true);
            stateNames.Clear();
            foreach (Transform child in worldMapList.transform)
            {
                Destroy(child.gameObject);
            }
            Debug.Log("Map Deleted");
        }
        else
        {
            Debug.LogError("Map not found at " + mapSaveLocation);
        }
        AssetDatabase.Refresh();
    }

    public void MapLoader()
    {
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
                stateNames.Add(newState.stateName);

                /*
                Debug
                    .Log("State Created: " +
                    newState.stateName +
                    " at " +
                    k +
                    ", " +
                    j);
                */
                
                string state = JsonUtility.ToJson(newState);
                System
                    .IO
                    .File
                    .WriteAllText(mapFolderLocation +
                    newState.stateName +
                    ".json",
                    state);
                Directory
                    .CreateDirectory(Application.persistentDataPath +
                    "/Saves/Map/" +
                    newState.stateName);

                ObjectGenerator (newState);

                index++;
            }
            j++;
            //Debug.Log("Tile created: " + k + ", " + j);
        }
        Debug.Log("Line 152 makes states discovered");
        string stateList = string.Join(",", stateNames);
        System.IO.File.WriteAllText (mapSaveLocation, stateList);
    }

    public void ObjectGenerator(StateClass tempState)
    {
        GameObject statePrefab;
        statePrefab = Instantiate(stateInstance, worldMapList.transform);
        StateScript prefabScript =
            statePrefab.GetComponentInChildren<StateScript>();
        StateClass createState = tempState;
        createState.discovered=true;
        Sprite tempSprite = sprites[tempState.specialisation];
        prefabScript.StateCreate (createState, worldMapPanel, tempSprite);
        statePrefab.SetActive(prefabScript.state.discovered);
    }
}

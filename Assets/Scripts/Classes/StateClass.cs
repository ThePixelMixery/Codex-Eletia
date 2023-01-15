using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class StateClass
{
    public string stateInfoLocation;

    [System.Serializable]
    public class StateSerial
    {
        public string stateName;

        public int specialisation;

        public List<Civilisation> townList;

        public List<TileClass> tiles;

        public StateSerial(string name, int spec)
        {   
            this.stateName = name;
            this.specialisation = spec;
        }
    }
    [SerializeField]
    StateSerial state;
    public StateClass(string nameofState, int typeofState){
    
    this.state = new StateSerial(nameofState, typeofState);
    Debug.Log("StateSerial Made");
    }

    //from struct
    //from serialise
    public int explored;

    public int exploredOutput;

    public int influence;

    void Start()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/Saves/Map"))
        {
            Debug.LogError("Save Directory not found");
            Directory
                .CreateDirectory(Application.persistentDataPath + "/Saves/Map");
        }
        
        stateInfoLocation =
            Application.persistentDataPath +
            "/Saves/Map"; //+
//            state.stateName +
//            ".json";
        //LoadState();
    }

    public void StateSaver()
    {
        string stateData = JsonUtility.ToJson(state);

        System
            .IO
            .File
            .WriteAllText(stateInfoLocation+state.stateName+".json",
            stateData);
        Debug.Log("State saved: " + state.stateName +" at " + stateInfoLocation);
    }

}
//    public TileClass[] tiles;

/*    public void GenerateTiles(){
        this.tiles = new TileClass[104];

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
        Debug.Log("State created");
    }

}
*/

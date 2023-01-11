using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class StateClass
{
    public string stateName;

    public string specialisation;

    public string capital;

    public List<CivilTile> TownList;

    public int explored;

    public int exploredOutput;

    public int influence;

    public TileClass[] tiles;

    public StateClass(string name, string spec, string cap)
    {
        this.stateName = name;
        this.specialisation = spec;
        this.capital = cap;
        this.influence = 0;
        this.explored = 0;
        this.tiles = new TileClass[104];
        Debug.Log("State created");
    }
}

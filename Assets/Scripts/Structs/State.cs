using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct State
{
    public int x;

    public int y;

    public int type;

    public string stateName;

    public string stateFancy;
    
    public List<Civilisation> townList;

    public Tile[] tiles;

    public bool discovered;


    public State(
        int x,
        int y,
        int type,
        string stateName,
        string stateFancy,
        List<Civilisation> townList,
        Tile[] tiles,
        bool discovered
    )
    {
        this.x = x;
        this.y = y;
        this.type = type;
        this.stateName = stateName;
        this.stateFancy = stateFancy;
        this.townList = townList;
        this.tiles = tiles;
        this.discovered = discovered;
    }
}

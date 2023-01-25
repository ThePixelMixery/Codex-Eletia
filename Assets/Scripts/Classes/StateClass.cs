using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class StateClass
{
    public string stateName;

    public int type;

    public string stateFancy;

    public bool discovered;

    public int x;

    public int y;

    public List<CivClass> townList;

    public TileClass[] tiles;

    public StateClass(
        int x,
        int y,
        int type,
        string stateName,
        string stateFancy,
        TileClass[] tiles
    )
    {
        this.x = x;
        this.y = y;
        this.type = type;
        this.stateName = stateName;
        this.stateFancy = stateFancy;
        this.tiles = tiles;
    }
}

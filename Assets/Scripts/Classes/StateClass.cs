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
        int X,
        int Y,
        int Type,
        string StateName,
        string StateFancy,
        TileClass[] Tiles
    )
    {
        this.x = X;
        this.y = Y;
        this.type = Type;
        this.stateName = StateName;
        this.stateFancy = StateFancy;
        this.tiles = Tiles;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TileClass
{
    public string locationName;

    public int access;

    public int x;

    public int y;

    public int type;

    public bool discovered;

    public Color tileColor;

    public float explored;

    public TileFeature[] features = new TileFeature[4];

    public TileClass()
    {
        this.explored = 0.0f;
    }
}

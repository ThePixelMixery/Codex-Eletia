using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MapNavClass
{
    public string navigatorName;
    public string state;
    public int tileX;
    public int tileY;
    public MapNavClass(string navName)
    {
    this.navigatorName=navName;
    }
}

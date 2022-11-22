using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMapScript : MonoBehaviour
{
    public class GridUnit
    {
    string contents;
    }
    public static GridUnit[,] Map;
    public static void makeMapSmall(){
        Map = new GridUnit[20,20];
        int index=0;
        foreach(GridUnit thing in Map)
        {
        Debug.Log(index);
        index++;
        }
    }
}

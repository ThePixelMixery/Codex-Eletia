using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TileClass : MonoBehaviour
{
    public Sprite tileImage;

    public int X;

    public int Y;

    public enum access
    {
        foot,
        horse,
        caravan
    }

    public List<ActionScript> tileActions;

    public float explored;

    public List<ObjectClass> tileObjects;

    public enum tileType
    {
        camp,
        farm,
        town,
        forest,
        necro,
        water
    }
}
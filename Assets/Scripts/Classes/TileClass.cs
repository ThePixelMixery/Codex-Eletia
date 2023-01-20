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

    public float explored; /* Type enum
    public enum tileType
    {
        //civilisation
        camp,
        farm,
        town,
        forest,
        //elemental - common
        fire,
        water,
        earth,
        air,
        //utility - rare
        mystic,
        time,
        ghost,
        hallow,
        summoner,
        changer,
        overseer,
        channel,
        //immoral / perversion
        disease, //hallow
        illusion, //changer
        blood, //water
        hex, //mystic
        necromantic //summoner
    }
*/

    public List<ActionClass> tileActions;

    public List<ObjectClass> tileObjects;

    public TileClass()
    {
        //this.x = X;
        //this.y = Y;
        this.explored = 0.0f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TileClass
{
    public Sprite tileImage;

    public int X;

    public int Y;

    public float explored;

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

    public enum access
    {
        foot,
        horse,
        caravan
    }

    public List<ActionClass> tileActions;

    
    public List<ObjectClass> tileObjects;


}
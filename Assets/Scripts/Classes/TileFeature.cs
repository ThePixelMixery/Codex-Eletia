using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFeature
{
    public int type;

    /*
        Loot
        Civilisation
        Hut/Shack/Cabin
        Food
        Water
        Enemy
        Resource
        Point of Interest
    */
    public int subtype;

    public string featureName;

    public string requiredSkill;

    public List<ObjectClass> objects;

    public CivClass civ;

    //public TileFeature(int type, string name)

}

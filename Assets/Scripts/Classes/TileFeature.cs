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
    public string featureName;

    public List<NPCClass> occupants;

    public TileFeature(int type, string featureName)
    {
        this.type = type;
        this.featureName = featureName;
    }

    public TileFeature(
        int type,
        string featureName,
        List<NPCClass> occupants
    )
    {
        this.type = type;
        this.featureName = featureName;
        this.occupants = new List<NPCClass>();
        this.occupants = occupants;
    }
}

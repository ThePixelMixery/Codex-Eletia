using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FeatureClass
{
    public int type;

    public int subtype;

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
    public bool discovered;

    public List<NPCClass> occupants;

    public List<ActionClass> actions;


    public FeatureClass(int type, string featureName)
    {
        this.discovered = false;
        this.type = type;
        this.featureName = featureName;
    }

    public FeatureClass(
        int type,
        string featureName,
        List<NPCClass> occupants
    )
    {
        this.discovered = false;
        this.type = type;
        this.featureName = featureName;
        this.occupants = new List<NPCClass>();
        this.occupants = occupants;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Feature
{
    public int id;

    public int type;

    public string featureName;

    public bool discovered;

    public List<NPC> occupants;

    public List<Resource> resources;

    public Feature(
        int id,
        int type,
        string featureName,
        bool discovered,
        List<NPC> occupants,
        List<Resource> resources
    )
    {
        this.id = id;
        this.type = type;
        this.featureName = featureName;
        this.discovered = discovered;
        this.occupants = occupants;
        this.resources = resources;
    }
}

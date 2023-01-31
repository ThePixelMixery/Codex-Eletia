using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Feature
{
    public int type;

    public string featureName;

    public bool discovered;

    public List<NPC> occupants;

    public List<Resource> resources;

    public Feature(
        int type,
        string featureName,
        List<NPC> occupants,
        List<Resource> resources,
        bool discovered
    )
    {
        this.type = type;
        this.featureName = featureName;
        this.occupants = occupants;
        this.resources = resources;
        this.discovered = discovered;
    }
}

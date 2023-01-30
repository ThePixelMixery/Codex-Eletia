using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class FeatureClass
{
    public int type;

    public int subtype;

    public string featureName;

    public bool discovered;

    public List<NPCClass> occupants = new List<NPCClass>();

    public List<Resource> resources= new List<Resource>();

    public FeatureClass(int type, string featureName)
    {
        this.discovered = false;
        this.type = type;
        this.featureName = featureName;
    }

    public FeatureClass(int type, string featureName, List<NPCClass> occupants)
    {
        this.discovered = false;
        this.type = type;
        this.featureName = featureName;
        this.occupants = new List<NPCClass>();
        this.occupants = occupants;
    }

    public FeatureClass(int type, string featureName, List<Resource> resources)
    {
        this.discovered = false;
        this.type = type;
        this.featureName = featureName;
        this.resources = new List<Resource>();
        this.resources = resources;
    }
    public FeatureClass(int type, string featureName, List<NPCClass> occupants, List<Resource> resources)
    {
        this.discovered = false;
        this.type = type;
        this.featureName = featureName;
        this.occupants = new List<NPCClass>();
        this.occupants = occupants;
        this.resources = new List<Resource>();
        this.resources = resources;
    }
}

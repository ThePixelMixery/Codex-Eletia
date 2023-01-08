using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DragonClass
{
    public float age = 0;

    public float bond;

    public string dragonName;

    public string act;

    private enum ageStage
    {
        Hatchling,
        Wyrmling,
        Juvenile,
        Adult,
        Elder,
        Ancient,
        Wyrm,
        Greatwyrm,
        Death
    }
}

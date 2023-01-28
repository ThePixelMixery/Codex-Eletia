using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Resource
{
    public int id;

    public string resourceName;

    public string action;

    public string flavourText;

    public int minCount;

    public int maxCount;

    public Item item;

    public string skill;

    public string tool;

    public int duration;

    public bool day;

    public Resource(
        int id,
        string resourceName,
        string action,
        string flavourText,
        int minCount,
        int maxCount,
        Item item,
        string skill,
        string tool,
        int duration,
        bool day
    )
    {
        this.id = id;
        this.resourceName = resourceName;
        this.action = action;
        this.flavourText = flavourText;
        this.minCount = minCount;
        this.maxCount = maxCount;
        this.item = item;
        this.skill = skill;
        this.tool = tool;
        this.duration = duration;
        this.day = day;
    }

    Resource(Resource resource)
    {
        this.id = resource.id;
        this.resourceName = resource.resourceName;
        this.action = resource.action;
        this.flavourText = resource.flavourText;
        this.minCount = resource.minCount;
        this.maxCount = resource.maxCount;
        this.item = resource.item;
        this.skill = resource.skill;
        this.tool = resource.tool;
        this.duration = resource.duration;
        this.day = resource.day;
    }
}

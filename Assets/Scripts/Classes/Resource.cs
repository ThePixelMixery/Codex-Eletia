using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct require
{
    public Item item;

    public int count;
}

[System.Serializable]
public struct outcome
{
    public Item item;

    public int min;

    public int max;

    public double chance;
}

[System.Serializable]
public class Resource
{
    public int id;

    public string action;

    public string resourceName;
    public int duration;

    public string flavourText;

    public int staminaCost;

    public string skill;

    public string tool;

    public int time;

    public List<require> requires = new List<require>();

    public List<outcome> outcomes = new List<outcome>();

    public Resource(
        int id,
        string action,
        string resourceName,
        int duration,
        string flavourText,
        int staminaCost,
        string skill,
        string tool,
        int time,
        List<require> requires,
        List<outcome> outcomes
        
    )
    {
        this.id = id;
        this.action = action;
        this.resourceName = resourceName;
        this.duration = duration;
        this.flavourText = flavourText;
        this.staminaCost = staminaCost;
        this.skill = skill;
        this.tool = tool;
        this.time = time;
        this.requires = requires;
        this.outcomes = outcomes;
    }

    Resource(Resource resource)
    {
        this.id = resource.id;
        this.action = resource.action;
        this.resourceName = resource.resourceName;
        this.duration = resource.duration;
        this.flavourText = resource.flavourText;
        this.skill = resource.skill;
        this.tool = resource.tool;
        this.time = resource.time;
        this.staminaCost = resource.staminaCost;
        this.requires = resource.requires;
        this.outcomes = resource.outcomes;
    }
}

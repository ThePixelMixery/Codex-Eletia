using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource
{
    public int id;

    public string resourceName;

    public string flavourText;

    public int maxCount;

    public int minCount;

    public List<Item> items;

    public string skill;

    public Resource(
        int id,
        string resourceName,
        string flavourText,
        int maxCount,
        int minCount,
        List<Item> items,
        string skill
    )
    {
        this.id = id;
        this.resourceName = resourceName;
        this.flavourText = flavourText;
        this.maxCount = maxCount;
        this.minCount = minCount;
        this.items = items;
        this.skill = skill;
    }

        public Resource(
        int id,
        string resourceName,
        string flavourText,
        int maxCount,
        int minCount,
        List<Item> items
    )
    {
        this.id = id;
        this.resourceName = resourceName;
        this.flavourText = flavourText;
        this.maxCount = maxCount;
        this.minCount = minCount;
        this.items = items;
    }

    Resource(Resource resource)
    {
        this.id = resource.id;
        this.resourceName = resource.resourceName;
        this.flavourText = resource.flavourText;
        this.maxCount = resource.maxCount;
        this.minCount = resource.minCount;
        this.items = resource.items;
        this.skill = resource.skill;
    }
}

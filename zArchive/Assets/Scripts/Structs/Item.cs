using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Item
{
    public int id;

    public string itemName;

    public string flavourText;

    public string group;

    public float weight;

    public bool quest;

    public bool consumable;

    public Sprite icon;

    public Dictionary<string, int> stats;

    //public Effect effect;

    public Item(
        int id,
        string itemName,
        string flavourText,
        string group,
        float weight,
        bool quest,
        bool consumable,
        Sprite icon,
        Dictionary<string, int> stats
        //Effect effect
    )
    {
        this.id = id;
        this.itemName = itemName;
        this.flavourText = flavourText;
        this.group = group;
        this.weight = weight;
        this.quest = quest;
        this.consumable = consumable;
        this.icon = icon;
        this.stats = stats;
        //this.effect = effect;
    }

    public Item(Item item)
    {
        this.id = item.id;
        this.itemName = item.itemName;
        this.flavourText = item.flavourText;
        this.group = item.group;
        this.weight = item.weight;
        this.quest = item.quest;
        this.consumable = item.consumable;
        this.icon = item.icon;
        this.stats = item.stats;
        //this.effect = item.effect;
    }
}

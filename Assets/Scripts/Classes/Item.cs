using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public int id;

    public string itemName;

    public string flavourText;

    public float weight;

    public bool quest;

    public bool consumable;

    public Sprite icon;

    public Dictionary<string, int> stats = new Dictionary<string, int>();

    //public Effect effect;

    public Item(
        int id,
        string itemName,
        string flavourtext,
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
        this.weight = item.weight;
        this.quest = item.quest;
        this.consumable = item.consumable;
        this.icon = item.icon;
        this.stats = item.stats;
        //this.effect = item.effect;
    }
}

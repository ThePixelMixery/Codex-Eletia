using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    public Sprite defaultSprite;

    private void Awake()
    {
        BuildItemDatabase();
    }

    public Item GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    public Item GetItem(string itemName)
    {
        return items
            .Find(item => item.itemName == itemName);
    }

    //Ref: int id, name, flavour, weight, quest, consume, icon, stats, effect
    void BuildItemDatabase()
    {
        items =
            new List<Item> {
                new Item(0,
                    "Raw Meat",
                    "The tender flesh of a fallen beast, it must be taken to the flame",
                    0.5f,
                    false,
                    true,
                    defaultSprite,
                    new Dictionary<string, int> { { "Water", -5 } })
            };
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDatabase : MonoBehaviour
{
    public GameObject items;

    private ItemDatabase itemDatabase;

    public List<Resource> resources = new List<Resource>();

    public Sprite defaultSprite;

    private void Awake()
    {
        BuildResourceDatabase();
        itemDatabase = items.GetComponentInChildren<ItemDatabase>();
    }

    public Resource GetResource(int id)
    {
        return resources.Find(resource => resource.id == id);
    }

    public Resource GetResource(string resourceName)
    {
        return resources
            .Find(resource => resource.resourceName == resourceName);
    }

    //Ref: int id, name, flavour, min, max, lis <item>, skill
    void BuildResourceDatabase()
    {
        resources =
            new List<Resource> {
                new Resource(0,
                    "Deer",
                    "A gentle creature, a staple of the hunter's diet",
                    3,
                    5,
                    new List<Item> {itemDatabase.GetItem(0)},
                    "None")
            };
    }
}

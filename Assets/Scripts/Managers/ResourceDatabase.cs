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
        itemDatabase = items.GetComponentInChildren<ItemDatabase>();
        BuildResourceDatabase();
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
                    "Hunt",
                    "A gentle creature, a staple of the hunter's diet",
                    3,
                    5,
                    itemDatabase.GetItem(0),
                    "Tracking",
                    "Bow",
                    4,
                    true),
                new Resource(0,
                    "Hog",
                    "Hunt",
                    "Nighttime is safer to snuffle in the dirt for roots, most of the time",
                    1,
                    3,
                    itemDatabase.GetItem(0),
                    "Tracking",
                    "Bow",
                    4,
                    false),
                new Resource(1,
                    "Lizard",
                    "Trap",
                    "A small spiny thing, but better than starving",
                    1,
                    1,
                    itemDatabase.GetItem(0),
                    "Trapping",
                    "Hunting Knife",
                    1,
                    true),
                new Resource(2,
                    "Rabbit",
                    "Trap",
                    "It's a good thing they breed like, well, rabbits!",
                    1,
                    2,
                    itemDatabase.GetItem(0),
                    "Trapping",
                    "Hunting Knife",
                    1,
                    true),
                new Resource(4,
                    "Berry bushes",
                    "Forage",
                    "The provider of drops of juicy goodness!",
                    4,
                    10,
                    itemDatabase.GetItem(0),
                    "Foraging",
                    null,
                    1,
                    true),
                new Resource(4,
                    "Aloe Vera",
                    "Forage",
                    "The hard and spiked exterior hides a secret which will help you survive the Fire State.",
                    2,
                    3,
                    itemDatabase.GetItem(0),
                    "Foraging",
                    "Hunting Knife",
                    1,
                    true),
                new Resource(4,
                    "Cactus",
                    "Forage",
                    "The spikes say \"Stay away\", but the fruit says \"Come Closer\"",
                    2,
                    3,
                    itemDatabase.GetItem(0),
                    "Foraging",
                    null,
                    1,
                    true)
            };
    }
}

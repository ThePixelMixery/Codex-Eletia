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
            /*
            
                new Resource(0,
                    "Set up",
                    "Camp",
                    4,
                    "Time to change this uncultivated clearing into a place of rest and safety",
                    0, // sets up the camp/changes tile
                    null,
                    null,
                    0, // not done yet
                    null,
                    3),
                new Resource(1,
                    "Campfire",
                    "Light a fire",
                    "A simple fire for keep warm for the night, cook, and other luxuries unavailable on the run",
                    new List<outcome> {
                        { new outcome {itemDatabase.GetItem(0), (0, 0)} }
                    }, // ashes
                    new Dictionary<Item, int> {
                        { itemDatabase.GetItem(0), 1 },
                        { itemDatabase.GetItem(0), 1 }
                    }, // wood and branch /changes tile
                    "Firestarting",
                    "Firestarter",
                    1.5,
                    0, //not set up yet
                    4,
                    3),
                    */
                new Resource(100,
                "Hunt",
                "Deer",
                4,
                "A gentle creature, a staple of the hunter's diet",
                0, //net yet set up
                "Tracking",
                "Bow",
                2,
                new List<require> {
                    new require { item = itemDatabase.GetItem(1), count = 1 }
                }, // arrows
                new List<outcome> {
                    {
                        new outcome {
                            item = itemDatabase.GetItem(0),
                            min = 3,
                            max = 5,
                            chance = 10
                        }
                    }
                })};
            }
    }
/*

//                        { new outcome {itemDatabase.GetItem(0), (0, 0)}}
                    }) // meat and deer ears 
                new Resource(101,
                    "Hog",
                    "Hunt",
                    "Nighttime is safer to snuffle in the dirt for roots, most of the time",
                    new List<outcome> {
                        { new outcome {itemDatabase.GetItem(0), (0, 0)}},
                        { new outcome {itemDatabase.GetItem(0), (0, 0)}}
                    }, // meat
                    new Dictionary<Item, int> { itemDatabase.GetItem(0), 1 }, // arrows
                    "Tracking",
                    "Bow",
                    2.9,
                    0, // not yet set up
                    4,
                    2),
                new Resource(102,
                    "Rabbit",
                    "Trap",
                    "It's a good thing they breed like, well, rabbits!",
                    new List<outcome> {
                        { new outcome {itemDatabase.GetItem(0), (0, 0)}},
                        { new outcome {itemDatabase.GetItem(0), (0, 0)}}
                    }, //meat
                    new Dictionary<Item, int> { itemDatabase.GetItem(0), 1 }, // string and branch
                    "Trapping",
                    "Hunting Knife",
                    5,
                    2,
                    true),
                new Resource(103,
                    "Lizard",
                    "Trap",
                    "A small spiny thing, but better than starving",
                    new List<outcome> {
                        { new outcome {itemDatabase.GetItem(0), (0, 0)}},
                        { new outcome {itemDatabase.GetItem(0), (0, 0)}}
                    }, //meat
                    new Dictionary<Item, int> { itemDatabase.GetItem(0), 1 }, // string and branch
                    "Trapping",
                    "Hunting Knife",
                    null,
                    1,
                    2),
                new Resource(110,
                    "Berry bushes",
                    "Forage",
                    "The provider of drops of juicy goodness!",
                    new List<outcome> {
                        { new outcome {itemDatabase.GetItem(0), (0, 0)}},
                        { new outcome {itemDatabase.GetItem(0), (0, 0)}}
                    }, //meat
                    null,
                    "Foraging",
                    null,
                    null,
                    3,
                    1),
                new Resource(111,
                    "Aloe Vera",
                    "Forage",
                    "The hard and spiked exterior hides a secret which will help you survive the Fire State.",
                    new List<outcome> {
                        { new outcome {itemDatabase.GetItem(0), (0, 0)}},
                        { new outcome {itemDatabase.GetItem(0), (0, 0)}}
                    }, //meat
                    null,
                    "Foraging",
                    "Hunting Knife",
                    null,
                    1,
                    1),
                new Resource(112,
                    "Cactus",
                    "Forage",
                    "The spikes say \"Stay away\", but the fruit says \"Come Closer\"",
                    2,
                    3,
                    new List<outcome> {
                        { new outcome {itemDatabase.GetItem(0), (0, 0)}},
                        { new outcome {itemDatabase.GetItem(0), (0, 0)}}
                    }, //meat
                    null,
                    "Foraging",
                    null,
                    null,
                    1,
                    1)*/

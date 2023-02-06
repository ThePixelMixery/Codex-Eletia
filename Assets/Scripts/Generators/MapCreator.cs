using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MapCreator : MonoBehaviour
{
    public GameObject save;

    public GameObject maps;

    public GameObject resourcesObject;

    int capital;

    SaveHandler handler;

    MapManager MapManager;

    ResourceDatabase resourceData;

    public void MapBase()
    {
        resourceData =
            resourcesObject.GetComponentInChildren<ResourceDatabase>();
        handler = save.GetComponentInChildren<SaveHandler>();
        MapManager = maps.GetComponentInChildren<MapManager>();
        HashSet<int> stateTypeNumbers = new HashSet<int>();
        while (stateTypeNumbers.Count < 16)
        {
            stateTypeNumbers.Add(UnityEngine.Random.Range(0, 16));
        }
        int[] stateTypeArray = new int[stateTypeNumbers.Count()];
        stateTypeNumbers.CopyTo (stateTypeArray);
        int index = 0;

        for (int j = 0; j < 4; j++)
        {
            for (int k = 0; k < 4; k++)
            {
                State newState =
                    new State(index,
                        k,
                        j,
                        stateTypeArray[index],
                        StateNamer(stateTypeArray[index]),
                        StateFancy(stateTypeArray[index]),
                        null,
                        GenerateTiles(stateTypeArray[index]),
                        false);

                handler._GameData.stateCoords[index] = newState;
                index++;
            }

            Alerter.DragonSelect();
        }
    }

    public void NewGame(int select)
    {
        Alerter.DragonSelected();
        int tileX = UnityEngine.Random.Range(0, 12);
        int tileY = UnityEngine.Random.Range(0, 7);
        int tile = (tileY * 13) + tileX;
        for (int i = 0; i < handler._GameData.stateCoords.Length; i++)
        {
            if (select == handler._GameData.stateCoords[i].type)
            {
                State stateSelected = handler._GameData.stateCoords[i];
                Tile tileSelected = handler._GameData.stateCoords[i].tiles[tile];
                stateSelected.discovered = true;
                MapManager
                    .MapMade(tileX,
                    tileY,
                    tileSelected,
                    stateSelected.x,
                    stateSelected.y,
                    stateSelected);
            }
        }
        handler.SaveFile();
    }

    string StateNamer(int type)
    {
        string generatedName;
        int rand = UnityEngine.Random.Range(0, 4);
        int rando = UnityEngine.Random.Range(0, 4);

        switch (type)
        {
            case 0:
                string[] fireNames =
                { "Titus", "Avlyrra", "Saza", "Zefadolon", "Issavyre" };
                generatedName = fireNames[rand];
                break;
            case 1:
                string[] waterNames =
                { "Glappilan", "Halaema", "Ararin", "Mirlenas", "Aronorin" };
                generatedName = waterNames[rand];
                break;
            case 2:
                string[] earthNames =
                { "Kyhun", "Karenth", "Votara", "Krigor", "Volgograd" };
                generatedName = earthNames[rand];
                break;
            case 3:
                string[] airNames =
                { "Orivae", "Opheros", "Hoyatha", "Gomiris", "Thalvith" };
                generatedName = airNames[rand];
                break;
            case 4:
                string[] arcaneNames =
                { "Diatoran", "Ehodran", "Bredane", "Hvalba", "Gravago" };
                generatedName = arcaneNames[rand];
                break;
            case 5:
                string[] plantNames =
                { "Noci", "Eszee", "Kezig", "Jahnin", "Crocan" };
                generatedName = plantNames[rand];
                break;
            case 6:
                string[] mysticNames =
                { "Islavaria", "Yusia", "Lecit", "Maritria", "Hoterra" };
                generatedName = mysticNames[rand];
                break;
            case 7:
                string[] timeNames =
                { "Praston", "Warminster", "Monfort", "Falkenberg", "Algard" };
                generatedName = timeNames[rand];
                break;
            case 8:
                string[] ghostNames =
                { "Sheonnorat", "Tarrgain", "Thomnum", "Akureyri", "Wyntumal" };
                generatedName = ghostNames[rand];
                break;
            case 9:
                string[] hallowNames =
                { "Soliana", "Kathaela", "Noria", "Elinlya", "Sophutria" };
                generatedName = hallowNames[rand];
                break;
            case 10:
                string[] summonerNames =
                { "Khodour", "Kolvereid", "Okukeg", "Obapan", "Nuxinon" };
                generatedName = summonerNames[rand];
                break;
            case 11:
                string[] overseerNames =
                { "Azagrut", "Azagana", "Zegosh", "Tyrkak", "Zibbema" };
                generatedName = overseerNames[rand];
                break;
            case 12:
                string[] channelNames =
                { "Yesmaris", "Toshecion", "Brunnholl", "Gerin", "Bramukork" };
                generatedName = channelNames[rand];
                break;
            case 13:
                string[] immoralNames =
                { "Rorvik", "Thorgruzz", "Grozny", "Amberg", "Husavik" };
                generatedName = immoralNames[rand];
                break;
            case 14:
                string[] seaNames =
                { "Waters", "Tides", "Waves", "Abyss", "Sea" };
                string[] seaPrefix =
                { "Arching", "Rough", "Mighty", "Wasted", "Forbidden" };
                generatedName =
                    "The " + seaPrefix[rando] + " " + seaNames[rand];
                break;
            case 15:
                string[] mountNames =
                { "Mountain", "Rise", "Tops", "Peaks", "Heights" };
                string[] mountPrefix =
                { "Darkest", "Mammoth", "Forsaken", "Unscaled", "Haunted" };
                generatedName =
                    "The " + mountPrefix[rando] + " " + mountNames[rando];
                break;
            default:
                generatedName = "Unnamed";
                break;
        }
        return generatedName;
    }

    string StateFancy(int type)
    {
        string typeFancy;
        switch (type)
        {
            case 0:
                typeFancy = "Fire";
                break;
            case 1:
                typeFancy = "Water";
                break;
            case 2:
                typeFancy = "Earth";
                break;
            case 3:
                typeFancy = "Air";
                break;
            case 4:
                typeFancy = "Arcane";
                break;
            case 5:
                typeFancy = "Plant";
                break;
            case 6:
                typeFancy = "Mystic";
                break;
            case 7:
                typeFancy = "Time";
                break;
            case 8:
                typeFancy = "Ghost";
                break;
            case 9:
                typeFancy = "Hallow";
                break;
            case 10:
                typeFancy = "Summoner";
                break;
            case 11:
                typeFancy = "Overseer";
                break;
            case 12:
                typeFancy = "Channel";
                break;
            case 13:
                typeFancy = "Immoral";
                break;
            case 14:
                typeFancy = "Ocean";
                break;
            case 15:
                typeFancy = "Divide";
                break;
            default:
                typeFancy = "Invalid State Spec/Unassigned";
                Debug.LogError (typeFancy);
                break;
        }
        return typeFancy;
    }

    Tile[] GenerateTiles(int type)
    {
        Tile[] tiles = new Tile[104];

        //creates tiles
        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i] = new Tile();
        }

        //Assigns tile x and y
        int index = 0;
        for (int j = 0; j <= 7; j++)
        {
            for (int k = 0; k <= 12; k++)
            {
                tiles[index].x = k;
                tiles[index].y = j;

                index++;
            }
        }

        //Assigns type
        int[] tileTypes =
        { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

        int assignedType = 0;
        for (int i = 0; i < tiles.Length; i++)
        {
            int variation = UnityEngine.Random.Range(0, 5);
            if (variation == 0)
            {
                int randomType = UnityEngine.Random.Range(0, 15);
                assignedType = tileTypes[randomType];
            }
            else if (variation == 1)
                assignedType = tileTypes[type];
            else
                assignedType = 13;
            tiles[i].id = i;
            tiles[i].type = assignedType;
            tiles[i].tileColor = MapManager.tileColours[assignedType];
            if (assignedType == 14 || assignedType == 15)
            {
                tiles[i].access = 0;
            }
        }

        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i].features = GenerateFeatures(tiles[i].type);
        }

        return tiles;
    }

    Feature[] GenerateFeatures(int type)
    {
        Feature[] features = new Feature[4];

        int[] featureTypeArray = new int[4];

        for (int i = 0; i < 4; i++)
        {
            if (UnityEngine.Random.Range(0, 1) == 1)
                featureTypeArray[i] = UnityEngine.Random.Range(1, 7);
            else
                featureTypeArray[i] = 0;
        }

        //[] loot table
        //[] civ builder
        List<NPC> npcs = new List<NPC>();
        List<Resource> resources = new List<Resource>();

        for (int i = 0; i < featureTypeArray.Length; i++)
        {
            resources.Add(resourceData.GetResource(100));
            features[i] =
                new Feature(3, "Trapping ground", null, resources, false);
        }

        /*for (int i = 0; i < featureTypeArray.Length; i++)
        {
            switch (featureTypeArray[i])
            {
                case 0: //nothing
                    features[i] = new Feature(0, "Nothing");
                    break;
                case 1: //
                    switch (type)
                    {
                        case 0:
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                        case 7:
                            break;
                        case 8:
                            break;
                        case 9:
                            break;
                        case 10:
                            break;
                        case 11:
                            break;
                        case 12:
                            break;
                        case 13:
                            break;
                        default:
                            break;
                    }
                    break;
                case 2:
                    switch (type)
                    {
                        case 0:
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                        case 7:
                            break;
                        case 8:
                            break;
                        case 9:
                            break;
                        case 10:
                            break;
                        case 11:
                            break;
                        case 12:
                            break;
                        case 13:
                            break;
                        default:
                            break;
                    }

                    npcs.Add(NPCGen.NPC());
                    features[i] = new Feature(2, "Bedouin Tent", npcs);
                    break;
                case 3:
                    switch (type)
                    {
                        case 0:
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                        case 7:
                            break;
                        case 8:
                            break;
                        case 9:
                            break;
                        case 10:
                            break;
                        case 11:
                            break;
                        case 12:
                            break;
                        case 13:
                            break;
                        default:
                            break;
                    }

                    features[i] = new Feature(3, "Trapping ground");
                    break;
                case 4:
                    switch (type)
                    {
                        case 0:
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                        case 7:
                            break;
                        case 8:
                            break;
                        case 9:
                            break;
                        case 10:
                            break;
                        case 11:
                            break;
                        case 12:
                            break;
                        case 13:
                            break;
                        default:
                            break;
                    }

                    features[i] = new Feature(4, "Oasis");
                    break;
                case 5:
                    switch (type)
                    {
                        case 0:
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                        case 7:
                            break;
                        case 8:
                            break;
                        case 9:
                            break;
                        case 10:
                            break;
                        case 11:
                            break;
                        case 12:
                            break;
                        case 13:
                            break;
                        default:
                            break;
                    }

                    //enemy table
                    break;
                case 6:
                    //ores (gold, silver, copper), coal, gems
                    switch (type)
                    {
                        case 0:
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                        case 7:
                            break;
                        case 8:
                            break;
                        case 9:
                            break;
                        case 10:
                            break;
                        case 11:
                            break;
                        case 12:
                            break;
                        case 13:
                            break;
                        default:
                            break;
                    }

                    break;
                case 7:
                    //points of interest table
                    switch (type)
                    {
                        case 0:
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                        case 7:
                            break;
                        case 8:
                            break;
                        case 9:
                            break;
                        case 10:
                            break;
                        case 11:
                            break;
                        case 12:
                            break;
                        case 13:
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }*/
        return features;
    }
}

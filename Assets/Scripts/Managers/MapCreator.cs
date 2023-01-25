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

    SaveHandler Handler;

    bool Initialised = false;

    void Start()
    {
        initialise();
    }

    void initialise()
    {
        if (Initialised == false)
        {
            Handler = save.GetComponentInChildren<SaveHandler>();
        }
    }

    void MapBase()
    {
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
                StateClass newState =
                    new StateClass(k,
                        j,
                        stateTypeArray[index],
                        StateNamer(stateTypeArray[index]),
                        StateFancy(stateTypeArray[index]),
                        GenerateTiles(stateTypeArray[index]));

                Handler._GameData.stateCoords[index] = newState;
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

        foreach (StateClass state in Handler._GameData.stateCoords)
        {
            if (select == state.type)
            {
                state.discovered = true;
                Handler.MapMade(tileX, tileY, state.x, state.y, state);
            }
        }
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

    TileClass[] GenerateTiles(int type)
    {
        TileClass[] tiles = new TileClass[104];

        //creates tiles
        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i] = new TileClass();
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

            tiles[i].type = assignedType;
            tiles[i].tileColor = Handler._UIControl.tileColours[assignedType];
            if (assignedType == 14 || assignedType == 15)
            {
                tiles[i].access = 0;
            }
        }

        return tiles;
    }

    TileFeature[] GenerateFeatures(int type)
    {
        TileFeature[] features = new TileFeature[4];
        HashSet<int> featureTypeNumbers = new HashSet<int>();

        while (featureTypeNumbers.Count < 4)
        {
            featureTypeNumbers.Add(UnityEngine.Random.Range(0, 7));
        }
        int[] featureTypeArray = new int[featureTypeNumbers.Count()];
        featureTypeNumbers.CopyTo (featureTypeArray);

        for (int i = 0; i < 4; i++)
        {
            switch (type)
            {
                case 0:
                    switch (featureTypeArray[i])
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
                        default:
                            break;
                    }
                    break;
                case 1:
                    switch (featureTypeArray[i])
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
                        default:
                            break;
                    }
                    break;
                case 2:
                    switch (featureTypeArray[i])
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
                        default:
                            break;
                    }
                    break;
                case 3:
                    switch (featureTypeArray[i])
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
                        default:
                            break;
                    }
                    break;
                case 4:
                    switch (featureTypeArray[i])
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
                        default:
                            break;
                    }
                    break;
                case 5:
                    switch (featureTypeArray[i])
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
                        default:
                            break;
                    }
                    break;
                case 6:
                    switch (featureTypeArray[i])
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
                        default:
                            break;
                    }
                    break;
                case 7:
                    switch (featureTypeArray[i])
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
                        default:
                            break;
                    }
                    break;
                case 8:
                    switch (featureTypeArray[i])
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
                        default:
                            break;
                    }
                    break;
                case 9:
                    switch (featureTypeArray[i])
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
                        default:
                            break;
                    }
                    break;
                case 10:
                    switch (featureTypeArray[i])
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
                        default:
                            break;
                    }
                    break;
                case 11:
                    switch (featureTypeArray[i])
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
                        default:
                            break;
                    }
                    break;
                case 12:
                    switch (featureTypeArray[i])
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
                        default:
                            break;
                    }
                    break;
                case 13:
                    switch (featureTypeArray[i])
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
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
        return features;
    }
}

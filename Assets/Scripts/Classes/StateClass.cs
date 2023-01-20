using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class StateClass
{
    public string stateName;

    public int specialisation;

    public bool discovered;

    public int x;

    public int y;

    public List<MapNavClass> occupants = new List<MapNavClass>();

    public List<CivClass> townList;

    public List<TileClass> tiles;

    public StateClass(int spec, int X, int Y)
    {
        this.x = X;
        this.y = Y;
        this.specialisation = spec;
        this.stateName = randomStateNameGen(spec);
    }

    private string randomStateNameGen(int spec)
    {
        string generatedName;
        int rand = Random.Range(0, 4);
        int rando = Random.Range(0, 4);

        switch (spec)
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
                string[] mysticNames =
                { "Islavaria", "Yusia", "Lecit", "Maritria", "Hoterra" };
                generatedName = mysticNames[rand];
                break;
            case 6:
                string[] timeNames =
                { "Praston", "Warminster", "Monfort", "Falkenberg", "Algard" };
                generatedName = timeNames[rand];
                break;
            case 7:
                string[] ghostNames =
                { "Sheonnorat", "Tarrgain", "Thomnum", "Akureyri", "Wyntumal" };
                generatedName = ghostNames[rand];
                break;
            case 8:
                string[] hallowNames =
                { "Soliana", "Kathaela", "Noria", "Elinlya", "Sophutria" };
                generatedName = hallowNames[rand];
                break;
            case 9:
                string[] summonerNames =
                { "Khodour", "Kolvereid", "Okukeg", "Obapan", "Nuxinon" };
                generatedName = summonerNames[rand];
                break;
            case 10:
                string[] alchemyNames =
                { "Noci", "Eszee", "Kezig", "Jahnin", "Crocan" };
                generatedName = alchemyNames[rand];
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
}
//    public TileClass[] tiles;

/*    public void GenerateTiles(){
        this.tiles = new TileClass[104];

        //creates tiles
        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i] = new TileClass();
        }

        //Assigns tile x and y
        int index = 0;
        int j = 0;
        while (j < 8)
        {
            for (int k = 0; k < 13; k++)
            {
                tiles[index].x = k;
                tiles[index].y = j;

                //Debug.Log("Tile created: " + k + ", " + j);
                index++;
            }
            j++;
        }
        Debug.Log("State created");
    }

*/

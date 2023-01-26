using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UIController
{
    public GameObject mapCreator;

    public GameObject worldMapList;

    public GameObject worldMapPanel;

    public GameObject localMapPanel;

    public GameObject miniMapPanel;

    public GameObject blockedTile;

    public Sprite tile;

    public Sprite keeper;

    public GameObject[] navButtons = new GameObject[8];

    public GameObject ActionList;

    public GameObject stateInstance;

    public GameObject tileInstance;

    public GameObject actionInstance;

    public GameObject TilePosition;

    public GameObject StatePosition;

    public Color[] tileColours;

    public Sprite[] stateSprites;

    public Sprite[] tileFeatures;

}

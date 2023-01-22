using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UIController
{
    public GameObject worldMapList;

    public GameObject worldMapPanel;

    public GameObject localMapPanel;

    public GameObject miniMapPanel;

    public GameObject blockedTile;

    public GameObject[] navButtons = new GameObject[8];

    public GameObject stateInstance;

    public GameObject tileInstance;


    public GameObject TilePosition;

    public GameObject StatePosition;
}

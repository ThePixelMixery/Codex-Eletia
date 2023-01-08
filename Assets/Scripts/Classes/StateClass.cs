using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class StateClass : MonoBehaviour
{
    public string stateName;

    public string specialisation;

    public string capital;

    public List<TownTile> TownList;

    public int explored;

    public int exploredOutput;

    public int influence;

    public Sprite open;

    public Sprite closed;

    public Image expand;
}

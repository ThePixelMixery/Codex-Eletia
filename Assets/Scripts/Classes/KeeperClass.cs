using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class KeeperClass
{   
    public int stateX;

    public int stateY;

    public int tileX;

    public int tileY;

    public float stamina;

    public float staminaMax;

    public float staminaRate;

    public List<string> skills;

    public List<Item> inventory;
}

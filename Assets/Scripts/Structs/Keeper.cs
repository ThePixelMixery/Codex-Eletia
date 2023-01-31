using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct tool
{
    string toolName;

    int charges;
}

[System.Serializable]
public struct Keeper
{
    public int stateX;

    public int stateY;

    public int tileX;

    public int tileY;

    public float stamina;

    public float staminaMax;

    public float staminaRate;

    public List<string> skills;

    public List<string> toolKeys;

    public List<int> toolValue;

    public Dictionary<string, int> tools;

    public int time;
}

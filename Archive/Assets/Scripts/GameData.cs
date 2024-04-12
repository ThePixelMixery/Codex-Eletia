using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct GameData
{
    public Keeper keeper;

    public State[] stateCoords;

    public QuestData quests;
}

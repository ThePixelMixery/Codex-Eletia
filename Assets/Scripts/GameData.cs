using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public Keeper keeper = new Keeper();

    public State[] stateCoords;

    public QuestData quests = new QuestData();
}

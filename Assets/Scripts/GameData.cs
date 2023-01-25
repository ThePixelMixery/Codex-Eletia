using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public KeeperClass keeper = new KeeperClass();

    public StateClass[] stateCoords;

    public QuestData quests = new QuestData();
}

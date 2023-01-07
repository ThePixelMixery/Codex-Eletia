using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public List<QuestScript> quests;

    public List<DragonScript> dragons;
    public KeeperScript player;
    public MapKeeper map;

    public GameData(List<QuestScript> questList, List<DragonScript> dragonList, KeeperScript playerObject, MapKeeper mapObject)
    {
        quests = questList;
        dragons = dragonList;
        player = playerObject;
        map = mapObject;
    }
}

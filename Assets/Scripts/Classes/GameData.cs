using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public KeeperClass keeper;

    public List<MapNavClass> mapNavigators;

    public StateClass[] stateCoords;
}

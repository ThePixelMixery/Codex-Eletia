using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TileScript : MonoBehaviour
{
    TileClass tile;
    void Start()
    {
        Debug.Log (tile.explored);
    }

    public float ExploredAmount()
    {
        return tile.explored;
    }

    public void ExploredMore(float exploredMore)
    {
        tile.explored += exploredMore;
    }
}

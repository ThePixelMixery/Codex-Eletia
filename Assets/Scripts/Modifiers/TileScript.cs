using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileScript : MonoBehaviour
{
    TileClass tile;

    GameObject localMapPanel;

    public GameObject tileTile;

    GameObject tileTileObject;

    void Start()
    {
        //Debug.Log (tile.explored);
    }

    public float ExploredAmount()
    {
        return tile.explored;
    }

    public void ExploredMore(float exploredMore)
    {
        tile.explored += exploredMore;
    }

    public void TileCreate(
        TileClass tempTile,
        GameObject LocalMapPanel,
        Sprite tempSprite
    )
    {
        tile = tempTile;

        //tile.text = state.stateName;
        //SpecFancy(state.specialisation);
        localMapPanel = LocalMapPanel;
        if (tile.type > 0)
            this.GetComponent<Image>().sprite = tempSprite;
        tileTileObject.SetActive(tile.discovered);
    }
}

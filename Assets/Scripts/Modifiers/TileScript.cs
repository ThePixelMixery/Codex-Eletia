using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileScript : MonoBehaviour
{
    TileClass tile;

    GameObject localMapPanel;

    public GameObject tileTile;

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
        bool current,
        TileClass tempTile,
        Sprite tempSprite
    )
    {
        if (current) tileTile.GetComponent<Image>().color = new Color(0.3f,0.55f,1.0f,1.0f);
        else  tileTile.GetComponent<Image>().color = Color.white;
        tile = tempTile;
        if (tile.type > 0)
            tileTile.GetComponent<Image>().sprite = tempSprite;
        tileTile.SetActive(tile.discovered);
    }
}

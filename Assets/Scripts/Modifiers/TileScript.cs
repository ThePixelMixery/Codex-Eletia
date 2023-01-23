using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileScript : MonoBehaviour
{
    public TileClass tile;

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

    public void TileCreate(TileClass tempTile, Sprite tempSprite) //bool current,
    {
        tile = tempTile;

        //if (tile.type > 0)

        tileTile.GetComponent<Image>().sprite = tempSprite;
        tileTile.GetComponent<Image>().color = tile.tileColor;
        tileTile.SetActive(tile.discovered);
    }

    public void Discovery()
    {
        tile.discovered = true;
    }

    public void UpdateTile(Sprite tempSprite)
    {
        tileTile.GetComponent<Image>().sprite = tempSprite;
        tileTile.SetActive(tile.discovered);
    }
}

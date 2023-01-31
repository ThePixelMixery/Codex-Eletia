using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileScript : MonoBehaviour
{
    public Tile tile;

    GameObject localMapPanel;

    public GameObject tileTile;

    public GameObject Feature1;

    public GameObject Feature2;

    public GameObject Feature3;

    public GameObject Feature4;

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
        Tile tempTile,
        Sprite tempSprite,
        Sprite featureSprite1,
        Sprite featureSprite2,
        Sprite featureSprite3,
        Sprite featureSprite4
    ) //bool current,
    {
        tile = tempTile;

        //if (tile.type > 0)
        tileTile.GetComponent<Image>().sprite = tempSprite;
        tileTile.GetComponent<Image>().color = tile.tileColor;
        Feature1.GetComponent<Image>().sprite = featureSprite1;
        Feature2.GetComponent<Image>().sprite = featureSprite2;
        Feature3.GetComponent<Image>().sprite = featureSprite3;
        Feature4.GetComponent<Image>().sprite = featureSprite4;
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

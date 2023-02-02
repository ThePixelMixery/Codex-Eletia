using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileScript : MonoBehaviour
{
    public Tile tile;

    GameObject localMapPanel;

    public GameObject tileTile;

    public GameObject Feature0;

    public GameObject Feature1;

    public GameObject Feature2;

    public GameObject Feature3;

    void Start()
    {
        //Debug.Log (tile.explored);
    }

    public void ExploredMore(float exploredMore)
    {
        tile.explored += exploredMore;
        if (tile.explored >= 25) tile.features[0].discovered = true;
        if (tile.explored >= 50) tile.features[1].discovered = true;
        if (tile.explored >= 75) tile.features[2].discovered = true;
        if (tile.explored >= 100) tile.features[3].discovered = true;
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
        Feature0.GetComponent<Image>().sprite = featureSprite1;
        Feature0.SetActive(tile.features[0].discovered);
        Feature1.GetComponent<Image>().sprite = featureSprite2;
        Feature1.SetActive(tile.features[1].discovered);
        Feature2.GetComponent<Image>().sprite = featureSprite3;
        Feature2.SetActive(tile.features[2].discovered);
        Feature3.GetComponent<Image>().sprite = featureSprite4;
        Feature3.SetActive(tile.features[3].discovered);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileScript : MonoBehaviour
{
    public Tile tile;

    GameObject localMapPanel;

    public GameObject tileTile;

    public GameObject[] Features = new GameObject[4];

    void Start()
    {
        //Debug.Log (tile.explored);
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
        Features[0].GetComponent<Image>().sprite = featureSprite1;
        Features[0].SetActive(tile.features[0].discovered);
        Features[1].GetComponent<Image>().sprite = featureSprite2;
        Features[1].SetActive(tile.features[1].discovered);
        Features[2].GetComponent<Image>().sprite = featureSprite3;
        Features[2].SetActive(tile.features[2].discovered);
        Features[3].GetComponent<Image>().sprite = featureSprite4;
        Features[3].SetActive(tile.features[3].discovered);
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

    public void FeatureHandler(int exploredAmount)
    {
        Debug.Log("Before add on tile" + tile.explored);
        tile.explored = tile.explored + exploredAmount;
        Debug.Log("After add on tile" + tile.explored);
        if (tile.explored >= 100)
        {
            tile.features[3].discovered = true;
            Debug.Log("Feature 4 discovered!");
        }
        else if (tile.explored >= 75)
        {
            tile.features[2].discovered = true;
            Debug.Log("Feature 3 discovered!");
        }
        else if (tile.explored >= 50)
        {
            tile.features[1].discovered = true;
            Debug.Log("Feature 2 discovered!");
        }
        else if (tile.explored >= 25)
        {
            tile.features[0].discovered = true;
            Debug.Log("Feature 1 discovered!");
        }
        for (int i = 0; i < 4; i++)
        {
            Features[i].SetActive(tile.features[i].discovered);
        }
    }
}

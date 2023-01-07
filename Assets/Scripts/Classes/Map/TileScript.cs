using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileScript : MonoBehaviour
{
    public Sprite tileImage;

    public enum access
    {
        foot,
        horse,
        caravan
    }

    public List<ActionScript> tileActions;

    [SerializeField]
    public float explored;

    [SerializeField]
    public List<ObjectScript> tileObjects;

    public enum tileType
    {
        camp,
        farm,
        town,
        forest,
        necro,
        water
    }

    void Start()
    {
        Debug.Log (explored);
    }

    public float ExploredAmount()
    {
        return explored;
    }
    public void ExploredMore(int exploredMore)
    {
        explored += exploredMore;
    }

}

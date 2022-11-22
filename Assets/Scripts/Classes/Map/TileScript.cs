using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileScript : MonoBehaviour
{
    public Sprite emptyTile;
    public Sprite campTile;
    public Sprite farmTile;
    public Sprite forestTile;
    public Sprite necroTile;
    public Sprite townTile;
    public Sprite waterTile;

    public enum access{foot,horse,caravan};

    [SerializeField]
    public float explored;
}

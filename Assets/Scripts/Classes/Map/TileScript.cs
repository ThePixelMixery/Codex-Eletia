using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileScript : MonoBehaviour
{
    public Sprite tileImage;

    public enum access{foot,horse,caravan};

    public List<ActionScript> tileActions;
    
    [SerializeField]
    public float explored;
    
    [SerializeField]
    public List<ObjectScript> tileObjects;
}

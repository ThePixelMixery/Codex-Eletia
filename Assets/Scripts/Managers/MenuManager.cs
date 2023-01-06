using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{


    public GameObject Panel_Dragons;
    public GameObject Panel_Explore;
    public GameObject Panel_Map;
    public GameObject Panel_Combat;
    public GameObject Panel_Journal;


    public GameObject Actions;

    public GameObject MinimapInfo;
    public GameObject MiniMap;
    public Image button;





    //expands and contract minimap (REMOVED)
/*
    private bool Expanded = false;

    public Sprite ExpandSprite;
    public Sprite ContractSprite;


    public void ExpandMinimap()
    {
        if (Expanded == false)
        {
            button.sprite = ContractSprite;
            MiniMap.GetComponent<RectTransform>().sizeDelta =
                new Vector2(546, 487);
            Expanded = true;
            MinimapInfo.SetActive(false);
            Actions.SetActive(false);
        }
        else
        {
            button.sprite = ExpandSprite;
            MiniMap.GetComponent<RectTransform>().sizeDelta =
                new Vector2(276, 276);
            Expanded = false;
            MinimapInfo.SetActive(true);
            Actions.SetActive(true);
        }
    }
*/

    public void CloseMenus()
    {
        Panel_Dragons.SetActive(false);
        Panel_Explore.SetActive(false);
        Panel_Map.SetActive(false);
        Panel_Combat.SetActive(false);
        Panel_Journal.SetActive(false);
    }

}

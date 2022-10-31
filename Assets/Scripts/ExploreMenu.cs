using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExploreMenu : MonoBehaviour
{

    public GameObject Actions;

    public GameObject MinimapInfo;
    public GameObject MiniMap;
    public Image button;

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
}

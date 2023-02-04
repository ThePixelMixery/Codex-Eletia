using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LootScript : MonoBehaviour
{
    public TextMeshProUGUI itemName;

    public TextMeshProUGUI itemWeight;

    public Button button;

    public Sprite moveSprite;

    public GameObject LootMenu;

    LootMenu loots;

    bool source;

    void Start()
    {
        button.onClick.AddListener (ClickAction);
        loots = GameObject.Find("GameObject_LootMenu").GetComponent<LootMenu>();
    }

    public void CreateLoot(string itemName, float itemWeight, Sprite moveSprite)
    {
        this.itemName.text = itemName;
        this.itemWeight.text = itemWeight.ToString();
        this.moveSprite = moveSprite;
    }

    void ClickAction()
    {
        
    }
}

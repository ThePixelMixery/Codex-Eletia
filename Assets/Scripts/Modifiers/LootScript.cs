using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LootScript : MonoBehaviour
{
    public Button button;
LootMenu loots;


    Stack stack;

    public TextMeshProUGUI stackName;

    public TextMeshProUGUI stackCount;

    public TextMeshProUGUI stackWeight;


    Sprite moveSprite;

    

    bool source;

    void Start()
    {
        button.onClick.AddListener (ClickAction);
        loots = GameObject.Find("GameObject_LootMenu").GetComponent<LootMenu>();
    }

    public void CreateLoot(Stack stack, Sprite moveSprite, bool source)
    {
        this.stack = stack;
        this.stackName.text = stack.item.itemName;
        this.stackCount.text = stack.count.ToString();
        this.stackWeight.text = stack.totalWeight.ToString();
        this.moveSprite = moveSprite;
        this.source = source;
    }

    void ClickAction()
    {
        //stack.count
    }
}

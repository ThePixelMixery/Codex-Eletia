using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LootMenu : MonoBehaviour
{
    public GameObject saveObject;

    SaveHandler save;

    public GameObject sourceObject;

    public GameObject invoObject;

    public GameObject lootInstance;

    public TextMeshProUGUI fromText;

    public TextMeshProUGUI toText;

    public TextMeshProUGUI fromWeight;

    public TextMeshProUGUI toWeight;

    public Button button;

    Item item;

    bool destination;

    bool overMax;

    List<Item> fromStorage = new List<Item>();

    List<Item> toStorage = new List<Item>();

    void Start()
    {
        save = saveObject.GetComponentInChildren<SaveHandler>();
            }

    public void ToKeeper(List<Item> items, string sourceName)
    {
        //toStorage (keeper)
        toStorage = save._GameData.keeper.inventory;
        toText.text = "Keeper";
        float maxToStorageWeight = save._GameData.keeper.weightMax;
        float toStorageWeight = CalculateWeight(fromStorage);
        toWeight.text = toStorageWeight + "/" + maxToStorageWeight;
        CheckWeight(maxToStorageWeight, toStorageWeight, true);

        //from storage (resource)
        fromStorage = items;
        fromText.text = sourceName;
        float maxFromStorageWeight = save._GameData.keeper.weightMax;
        float fromStorageWeight = CalculateWeight(fromStorage);
        fromWeight.text = toStorageWeight + "/" + maxToStorageWeight;
        CheckWeight(maxFromStorageWeight, fromStorageWeight, true);
    }

    float CalculateWeight(List<Item> toWeigh)
    {
        float weight = 0;
        foreach (Item item in toWeigh)
        {
            weight += item.weight;
        }
        return weight;
    }

    void CheckWeight(float maxWeight, float compareWeight, bool toStorage)
    {
        if (maxWeight < compareWeight)
        {
            button.interactable = false;
            if (toStorage)
                toWeight.color = new Color(1, 0, 0, 1);
            else
                fromWeight.color = new Color(1, 0, 0, 1);
        }
        else
        {
            button.interactable = true;
            if (toStorage)
                toWeight.color = new Color(1, 1, 1, 1);
            else
                fromWeight.color = new Color(1, 1, 1, 1);
        }
    }
}

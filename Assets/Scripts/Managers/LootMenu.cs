using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LootMenu : MonoBehaviour
{
    public GameObject lootMenu;

    public GameObject saveObject;

    SaveHandler save;

    public GameObject sourceObject;

    public GameObject invoObject;

    public GameObject lootInstance;

    public TextMeshProUGUI fromText;

    public TextMeshProUGUI toText;

    public TextMeshProUGUI fromWeight;

    public TextMeshProUGUI toWeight;

    public GameObject nothing;

    public Button button;

    public Sprite moveTo;

    public Sprite moveFrom;

    Item item;

    bool destination;

    bool overMax;

    List<Item> fromStorage = new List<Item>();

    List<Item> toStorage = new List<Item>();

    void Start()
    {
        save = saveObject.GetComponentInChildren<SaveHandler>();
        lootMenu.SetActive(false);
    }

    public void ToKeeper(List<outcome> outcomes, string sourceName)
    {
        ClearLists();
        lootMenu.SetActive(true);

        //to Storage (keeper)
        toStorage = save._GameData.keeper.inventory;
        toText.text = "Keeper";
        float maxToStorageWeight = save._GameData.keeper.weightMax;
        float toStorageWeight = CalculateWeight(toStorage);
        toWeight.text = toStorageWeight + "/" + maxToStorageWeight;
        CheckWeight(maxToStorageWeight, toStorageWeight, true);
        PopulateList(toStorage, false);

        //from storage (resource)
        fromText.text = sourceName;
        float maxFromStorageWeight = 100;
        List<Item> result = OutcomeCalculator(outcomes);
        if (result.Count == 0)
            nothing.SetActive(true);
        else
        {
            nothing.SetActive(false);
            float fromStorageWeight = CalculateWeight(result);
            fromWeight.text = toStorageWeight + "/" + maxToStorageWeight;
            CheckWeight(maxFromStorageWeight, fromStorageWeight, true);
            PopulateList(fromStorage, true);
        }
    }

    void ClearLists()
    {
        foreach (Transform child in sourceObject.transform)
        {
            if (child.gameObject.name != "Text_Nothing") Destroy(child.gameObject);
        }
        foreach (Transform child in invoObject.transform)
        Destroy(child.gameObject);
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

    List<Item> OutcomeCalculator(List<outcome> outcomes)
    {
        List<Item> results = new List<Item>();
        foreach (outcome outcome in outcomes)
        {
            int amount = 0;
            double rand = Random.Range(1, outcome.chance);
            if (rand <= 1)
            {
                amount = Random.Range(outcome.min, outcome.max);
            }
            for (int i = 0; i < amount; i++)
            {
                results.Add(outcome.item);
            }
        }
        return results;
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

    void PopulateList(List<Item> items, bool from)
    {
        if (from)
        {
            foreach (Item item in items)
            {
                GameObject lootItem =
                    Instantiate(lootInstance, sourceObject.transform);
                LootScript script =
                    lootItem.GetComponentInChildren<LootScript>();
                script.CreateLoot(item.itemName, item.weight, moveTo);
            }
        }
        else
        {
            foreach (Item item in items)
            {
                GameObject lootItem =
                    Instantiate(lootInstance, sourceObject.transform);
                LootScript script =
                    lootItem.GetComponentInChildren<LootScript>();
                script.CreateLoot(item.itemName, item.weight, moveTo);
            }
        }
    }
}

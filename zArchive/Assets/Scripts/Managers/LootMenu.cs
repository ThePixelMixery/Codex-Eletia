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

    bool destination;

    bool overMax;

    List<Stack> fromStorage = new List<Stack>();

    List<Stack> toStorage = new List<Stack>();

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
        PopulateList (toStorage, invoObject);

        //from storage (resource)
        fromText.text = sourceName;
        float maxFromStorageWeight = 100;
        List<Stack> fromStorage = OutcomeCalculator(outcomes);
        if (fromStorage.Count == 0)
            nothing.SetActive(true);
        else
        {
            nothing.SetActive(false);
            float fromStorageWeight = CalculateWeight(fromStorage);
            fromWeight.text = fromStorageWeight + "/100";
            CheckWeight(maxFromStorageWeight, fromStorageWeight, true);
            PopulateList (fromStorage, sourceObject);
        }
    }

    void ClearLists()
    {
        foreach (Transform child in sourceObject.transform)
        Destroy(child.gameObject);
        foreach (Transform child in invoObject.transform)
        Destroy(child.gameObject);
    }

    float CalculateWeight(List<Stack> stacks)
    {
        float weight = 0;
        List<Item> weighStack = new List<Item>();
        for (int i = 0; i < weighStack.Count; i++)
        {
            for (int j = 0; j < stacks[i].count; j++)
            {
                weighStack.Add(stacks[i].item);
            }
        }
        foreach (Item item in weighStack)
        {
            weight += item.weight;
        }
        return weight;
    }

    List<Stack> OutcomeCalculator(List<outcome> outcomes)
    {
        List<Stack> results = new List<Stack>();
        Item outcomeItem;
        foreach (outcome outcome in outcomes)
        {
            int amount = 0;
            double rand = Random.Range(0, 1);
            if (rand <= 1)
            {
                amount = Random.Range(outcome.min, outcome.max);
            }
            outcomeItem = outcome.item;
            Stack loot = new Stack(amount, outcomeItem);
            results.Add (loot);
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

    void PopulateList(List<Stack> stacks, GameObject listObject)
    {
        Sprite moveSprite;
        bool source;
        if (listObject == sourceObject)
        {
            moveSprite = moveTo;
            source = true;
        }
        else
        {
            moveSprite = moveFrom;
            source = false;
        }
        if (stacks == null)
            Debug.LogError("No stacks to display");
        else
            foreach (Stack stack in stacks)
            {
                GameObject lootStack =
                    Instantiate(lootInstance, listObject.transform);
                LootScript script =
                    lootStack.GetComponentInChildren<LootScript>();
                script.CreateLoot (stack, moveSprite, source);
            }
    }

    public void AddToList()
    {
    }
}

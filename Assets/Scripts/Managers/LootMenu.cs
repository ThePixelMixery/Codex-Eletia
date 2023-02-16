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

    /*
        public void ToKeeper(List<outcome> outcomes, string sourceName)
        {
            ClearList(sourceObject.transform);
            ClearList(invoObject.transform);
            lootMenu.SetActive(true);

            //to Storage (keeper)
            toStorage = save._GameData.keeper.inventory;
            toText.text = "Keeper";
            float maxToStorageWeight = save._GameData.keeper.weightMax;
            float toStorageWeight = CalculateWeight(toStorage);
            toWeight.text = toStorageWeight + "/" + maxToStorageWeight;
            CheckWeight(maxToStorageWeight, toStorageWeight, true);
            PopulateList(toStorage, invoObject, false);

            //from storage (resource)
            fromText.text = sourceName;
            float maxFromStorageWeight = 100;
            fromStorage = OutcomeCalculator(outcomes);
            if (fromStorage.Count == 0)
                nothing.SetActive(true);
            else
            {
                nothing.SetActive(false);
                float fromStorageWeight = CalculateWeight(fromStorage);
                fromWeight.text = fromStorageWeight + "/100";
                CheckWeight(maxFromStorageWeight, fromStorageWeight, true);
                PopulateList(fromStorage, sourceObject, true);
            }
        }

        void ClearList(Transform transform)
        {
            foreach (Transform child in transform) Destroy(child.gameObject);
        }

        float CalculateWeight(List<Stack> stacks)
        {
            float weight = 0;
            List<Item> weighStack = new List<Item>();

            for (int i = 0; i < weighStack.Count; i++)
            {
                for (int j = 0; j < stacks[i].quantity; j++)
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
        float CalculateWeight(List<Stack> stacks)
        {
            int amount = 0;
            double rand = Random.Range(0, 1);
            if (rand <= 1)
            float weight = 0;
            List<Item> weighStack = new List<Item>();

            for (int i = 0; i < weighStack.Count; i++)
            {
                for (int j = 0; j < stacks[i].quantity; j++)
                {
                    weighStack.Add(stacks[i].item);
                }
            }

            foreach (Item item in weighStack)
            {
                amount = Random.Range(outcome.min, outcome.max);
                weight += item.weight;
            }
            outcomeItem = outcome.item;
            Stack loot = new Stack(amount, outcomeItem);
            results.Add (loot);
            return weight;
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

        void PopulateList(List<Stack> stacks, GameObject listObject, bool source)
        {
            ClearList(listObject.transform);
            Sprite moveSprite;
            if (source)
                moveSprite = moveTo;
            else
                moveSprite = moveFrom;
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

        public void RemoveFromList(Stack stack, bool source)
        {
            int itemID = stack.item.id;
            int index = -1;
            if (source)
            {
                index = CheckForStack(itemID, toStorage);
                toStorage.RemoveAt (index);
                PopulateList (toStorage, invoObject, source);
            }
            else
            {
                index = CheckForStack(itemID, fromStorage);
                fromStorage.RemoveAt (index);
                PopulateList (fromStorage, sourceObject, source);
            }
        }

        public void AddToList(Stack stack, bool source)
        {
            int itemID = stack.item.id;
            int index = -1;
            if (source)
            {
                index = CheckForStack(itemID, toStorage);
                Debug.Log("Index at toStroage: " + index);
                if (index == -1)
                {
                    Stack loot = new Stack(1, stack.item);
                    toStorage.Add (loot);
                }
                else
                {
                    Stack replaceStack = toStorage[index];
                    toStorage.RemoveAt (index);
                    replaceStack.quantity++;
                    toStorage.Insert (index, replaceStack);
                }
            PopulateList(toStorage, invoObject,source);
            }
            else
            {
                index = CheckForStack(itemID, fromStorage);
                Debug.Log("Index at fromStroage: " + index);

                if (index == -1)
                {
                    Stack loot = new Stack(1, stack.item);
                    fromStorage.Add (loot);
                }
                else
                {
                    Stack replaceStack = fromStorage[index];
                    fromStorage.RemoveAt (index);
                    replaceStack.quantity++;
                    fromStorage.Insert (index, replaceStack);
                }
            PopulateList(fromStorage, sourceObject,source);
            }
            
        }

        int CheckForStack(int itemID, List<Stack> checkedStack)
        {
            int index = -1;
            for (int i = 0; i < checkedStack.Count; i++)
            {
                if (checkedStack[i].item.id == itemID) index = i;
            }
            Debug.Log("stack found at " + index);
            return index;
        }
        */
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject saveObject;

    SaveHandler save;

    List<Stack> invo = new List<Stack>();

    void Start()
    {
        save = saveObject.GetComponentInChildren<SaveHandler>();
        invo = save._GameData.keeper.inventory;
    }

    public void Sourced(List<outcome> outcomes, string resource)
    {
        foreach (outcome outcome in outcomes)
        {
            Item outcomeItem;
            int amount = 0;
            double rand = Random.Range(0, 1); //chance instead of 1
            if (rand <= 1)
            {
                amount = Random.Range(outcome.min, outcome.max);
                outcomeItem = outcome.item;
                Stack stack = new Stack(amount, outcomeItem);
                AddToKeeper (stack, amount, resource);
            }
        }

        save._GameData.keeper.inventory = invo;
    }

    public void AddToKeeper(Stack stack, int amount, string resource)
    {
        int itemID = stack.item.id;
        int index = -1;
        index = CheckForStack(itemID, invo);
        if (index == -1)
        {
            invo.Add (stack);
            EventTracker
                .NewEvent(3,
                "You managed to gather " +
                amount +
                " " +
                stack.item.itemName +
                " from the " +
                resource +
                ". (" +
                amount +
                ")");
        }
        else
        {
            Stack replaceStack = invo[index];
            invo.RemoveAt (index);
            replaceStack.quantity += stack.quantity;
            invo.Insert (index, replaceStack);
            EventTracker
                .NewEvent(3,
                "You managed to gather " +
                amount +
                " " +
                stack.item.itemName +
                " from the " +
                resource +
                ". (" +
                invo[index].quantity +
                ")");
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
}

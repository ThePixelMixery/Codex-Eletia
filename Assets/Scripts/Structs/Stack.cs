using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Stack
{
    public int quantity;

    public Item item;

    public float totalWeight;

    public Stack(int quantity, Item item)
    {
        this.quantity = quantity;
        this.item = item;
        this.totalWeight = quantity * item.weight;
    }

    public void UpdateQuantity(int toAdd)
    {
        this.quantity = quantity + toAdd;
        this.totalWeight = quantity * item.weight;
    }
}

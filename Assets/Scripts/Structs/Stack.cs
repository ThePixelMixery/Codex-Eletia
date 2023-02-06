using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Stack
{
    public int count;

    public Item item;

    public float totalWeight;

    public Stack(int count, Item item)
    {
        this.count = count;
        this.item = item;
        this.totalWeight = count * item.weight;
    }
}

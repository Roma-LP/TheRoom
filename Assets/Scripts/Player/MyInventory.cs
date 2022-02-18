using System.Collections.Generic;
using UnityEngine;

public class MyInventory : MonoBehaviour
{
    private List<ItemType> myItems;

    private void Awake()
    {
        GlobalEventManager.OnItemPick += WhatIPicked;
        myItems = new List<ItemType>();
    }

    private void WhatIPicked(ItemType itemType)
    {
        myItems.Add(itemType);
    }

    public bool IsItemPicked(ItemType itemType) => myItems.Contains(itemType);

    private void OnDestroy()
    {
        GlobalEventManager.OnItemPick -= WhatIPicked;
    }
}

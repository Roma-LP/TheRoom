using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MyInventory : MonoBehaviour
{
    private List<ItemType> myItems;

    private void Awake()
    {
        GlobalEventManager.OnItemPick+= WhatIPicked;  
        myItems = new List<ItemType>();
    }

    private void WhatIPicked(ItemType itemType)
    {
        //switch (itemType)
        //{
        //    case ItemType.Key:
        //        break;
        //    case ItemType.KeyCard:
        //        break;
        //    case ItemType.Screwdriver:
        //        break;
        //}
       myItems.Add(itemType);
    }

    public bool IsItemPicked(ItemType itemType) => myItems.Exists(x => x == itemType);

    private void OnDestroy()
    {
        GlobalEventManager.OnItemPick += WhatIPicked;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CanvasInventory : MonoBehaviour
{
    [SerializeField] private InventoryItem cellPrefab;
    [SerializeField] private ImageStore imageStore;
    [SerializeField] private GameObject panel;


    private void Awake()
    {
        GlobalEventManager.OnItemPick += WhatNeedToShow;
    }

    private void WhatNeedToShow(ItemType itemType)
    {
        InventoryItem inventoryItem = Instantiate(cellPrefab, panel.transform);
        inventoryItem.SetItemType(itemType);
    }

    private void OnDestroy()
    {
        GlobalEventManager.OnItemPick -= WhatNeedToShow;
    }
}

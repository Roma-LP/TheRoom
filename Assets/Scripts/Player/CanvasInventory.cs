using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CanvasInventory : MonoBehaviour
{
    [SerializeField] private GameObject prefabCell;
    [SerializeField] private ImageStore imageStore;
    [SerializeField] private GameObject panel;

    private void Awake()
    {
        GlobalEventManager.OnItemPick += WhatNeedToShow;
    }

    private void WhatNeedToShow(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Key:
                prefabCell.GetComponentsInChildren<Image>().First(x => x.name == "ItemImage").sprite = imageStore.GetSpriteByItemType(ItemType.Key);
                break;
            case ItemType.KeyCard:
                prefabCell.GetComponentsInChildren<Image>().First(x => x.name == "ItemImage").sprite = imageStore.GetSpriteByItemType(ItemType.KeyCard);
                break;
            case ItemType.Screwdriver:
                prefabCell.GetComponentsInChildren<Image>().First(x => x.name == "ItemImage").sprite = imageStore.GetSpriteByItemType(ItemType.Screwdriver);
                break;
        }
        Instantiate(prefabCell, panel.transform);
    }


    private void OnDestroy()
    {
        GlobalEventManager.OnItemPick += WhatNeedToShow;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private ImageStore store;
    private ItemType itemType;

    public void SetItemType(ItemType itemType)
    {
        this.itemType = itemType;
        image.sprite = store.GetSpriteByItemType(itemType);
    }
}

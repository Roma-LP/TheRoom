using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasWhatNeed : MonoBehaviour
{
    [SerializeField] private Transform parentPanel;
    [SerializeField] private InventoryItem cellPrefab;
    [SerializeField, Min(0.3f)] private float blinksTime;

    private InventoryItem[] inventory;

    public void WhatNeedBlinks(ItemType[] itemTypes)
    {
        StopAllCoroutines();
        ClearInventory();
        inventory = new InventoryItem[itemTypes.Length];
        for (byte i = 0; i < itemTypes.Length; i++)
        {
            inventory[i] = Instantiate(cellPrefab, parentPanel);
            inventory[i].SetItemType(itemTypes[i]);
        }
        StartCoroutine(Blinks());
    }

    private void HideItems(bool value)
    {
        foreach (InventoryItem item in inventory)
            item.gameObject.SetActive(!value);
    }

    IEnumerator Blinks()
    {
        yield return new WaitForSeconds(blinksTime);
        HideItems(true);
        yield return new WaitForSeconds(blinksTime);
        HideItems(false);
        yield return new WaitForSeconds(blinksTime);
        HideItems(true);
        ClearInventory();
        inventory = null;
    }

    private void ClearInventory()
    {
        if (inventory == null)
            return;
        foreach (var item in inventory)
            Destroy(item.gameObject);
        inventory = null;
    }
}

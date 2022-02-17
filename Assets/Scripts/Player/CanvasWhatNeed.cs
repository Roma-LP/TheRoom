using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasWhatNeed : MonoBehaviour
{
    [SerializeField] private GameObject item_Key;
    [SerializeField] private GameObject item_CardKey;
    [SerializeField] private GameObject item_Screwdriver;
    [SerializeField, Min(0.3f)] private float blinksTime;
    
    private bool[] x = new bool[3];
    
    public void WhatNeedBlinks(ItemType[] itemTypes)
    {
        for (byte i = 0; i < itemTypes.Length; i++)
        {
            switch (itemTypes[i])
            {
                case ItemType.Key:
                    x[0] = true;
                    break;
                case ItemType.KeyCard:
                    x[1] = true;
                    break;
                case ItemType.Screwdriver:
                    x[2] = true;
                    break;
            }
        }

        StartCoroutine(Blinks());
    }

    IEnumerator Blinks()
    {
        SetTrue();
        yield return new WaitForSeconds(blinksTime);
        SetFalse();
        yield return new WaitForSeconds(blinksTime);
        SetTrue();
        yield return new WaitForSeconds(blinksTime);
        SetFalse();
    }

    private void SetTrue()
    {
        if (x[0]) item_Key.SetActive(true);
        if (x[1]) item_CardKey.SetActive(true);
        if (x[2]) item_Screwdriver.SetActive(true);
    }
    private void SetFalse()
    {
        if (x[0]) item_Key.SetActive(false);
        if (x[1]) item_CardKey.SetActive(false);
        if (x[2]) item_Screwdriver.SetActive(false);
    }
}

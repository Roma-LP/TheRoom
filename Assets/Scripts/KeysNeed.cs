using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeysNeed : MonoBehaviour
{
    [SerializeField] private ItemType[] keysNeed;
    [SerializeField] private CanvasWhatNeed canvasWhatNeed;
    [SerializeField] private MyInventory inventory;
    [SerializeField] private UnityEvent OnCorrect;

    private bool isCheckedPassword;

    public void CheckInventory()
    {
        if (!isCheckedPassword)
        {
            if (!isKeysPicked())
                canvasWhatNeed.WhatNeedBlinks(keysNeed);
        }
        else
        {
            return;
        }
    }


    private bool isKeysPicked()
    {
        for (byte i = 0; i < keysNeed.Length; i++)
        {
            if (inventory.IsItemPicked(keysNeed[i]))
                continue;
            else
                return false;
        }
        OnCorrect?.Invoke();
        isCheckedPassword = true;
        return true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GlobalEventManager : MonoBehaviour
{
    public static event Action<ItemType> OnItemPick;
    public static void TriggerOnItemPick(ItemType itemType) => OnItemPick?.Invoke(itemType);

    public static event Action<float> OnCommonVolumeChange;
    public static void TriggerOnCommonVolumeChange(float volume) => OnCommonVolumeChange?.Invoke(volume);
}

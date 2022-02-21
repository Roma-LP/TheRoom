using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GlobalEventManager : MonoBehaviour
{
    public static event Action<ItemType> OnItemPick;
    public static void TriggerOnItemPick(ItemType itemType) => OnItemPick?.Invoke(itemType);
}

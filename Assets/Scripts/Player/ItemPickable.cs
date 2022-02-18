using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickable : MonoBehaviour , IInteractable
{
    [SerializeField] private ItemType itemType;


    public void Interact()
    {
        GlobalEventManager.TriggerOnItemPick(itemType);
        Destroy(gameObject);
    }
}

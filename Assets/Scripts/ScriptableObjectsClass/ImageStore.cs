using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;


[CreateAssetMenu(menuName = "ScriptableObjects/ImageStore")]
public class ImageStore : ScriptableObject
{
    [SerializeField, ArrayElementTitle("itemType")] private ImageField[] imageFields;

    public Sprite GetSpriteByItemType(ItemType itemType)
    {
        return imageFields.First(x => x.itemType == itemType).sprite;
    }
}

public enum ItemType
{
    Key,
    KeyCard,
    Screwdriver,
}

[Serializable]
public class ImageField
{
    public ItemType itemType;
    public Sprite sprite;
}

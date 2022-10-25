using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Default Object", menuName ="Inventory Syestem/Items/Default")]
public class NDefaultObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Other;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {Food,CareItem,Furniture,Toy,Other}
public abstract class ItemObject : ScriptableObject
{

    public string ItemName;
    public Sprite Icon;
    public ItemType type;
    [TextArea(15,20)]
    public string Discription;
    public int BuyValue;

}

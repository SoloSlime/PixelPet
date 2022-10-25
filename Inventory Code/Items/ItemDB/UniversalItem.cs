using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Universal Object", menuName = "Inventory Syestem/Items/Universal")]
public class UniversalItem : ItemObject
{
  public  FoodObject foodobj;
  public CareItemObject careitmobj;
    // DecourObject Decobj;
    // ToyObject toyobj;


    public void SetFood (FoodObject food)
    {
        this.foodobj = food;
        this.type = ItemType.Food;
    }

    public void SetCare (CareItemObject care)
    {
        this.careitmobj = care;
        this.type = ItemType.CareItem;
    }


    [ContextMenu("AddToDB")]
public void AddToDB()
    {
      //itmDB.items.Add(this);
    }

}

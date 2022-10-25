using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Stat { None,Spd, Atk, Def, Mgk, Res, Dur, Luc}
public enum FoodGroup { None, Fruit, Veg, Meat, Dary, Grain, Sweet }
public enum Flavor { None, Sweet, Savory, Sour, Bitter, Spicy, Dry, Jucy}
[CreateAssetMenu(fileName = "New Food Object", menuName = "Inventory Syestem/Items/Food")]

public class FoodObject : ItemObject
{
    public Stat Statbonus;
    public float StatIncraseValue;
    public FoodGroup FoodGroup;
    public Flavor flavor1;
    public Flavor Flavor2;
    public Stat Statbonus2;
    public float Stat2IncreaseValue;
    public Stat StatReduced;
    public float StatReductionValue;
    public float FillingAmmount;
    


    public void Awake()
    {
        type = ItemType.Food;
    }

    
  
}

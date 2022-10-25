using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CareItemType {None,Bed,Bath,Excersise,Medical}
public enum CareArea {None,Hunger,Hygiene,Exhaustion, Fun,Health,Happyness}

[CreateAssetMenu(fileName = "New CareItem Object", menuName = "Inventory Syestem/Items/Care")]
public class CareItemObject : ItemObject
{
    public CareItemType Careitemtype;
    public float Caremultiplier;
    public Stat Stat;
    public float statbonus;
    public CareArea ReducedCareArea;
    public float ReducedCareAmmount;

    // Start is called before the first frame update
    public void Awake()
    {
        type = ItemType.CareItem;
    }

    //{ None,Spd, Atk, Def, Mgk, Res, Dur, Luc}
    public string StatToString(Stat stat)
    {
        switch (stat)
        {
            case Stat.None:
                return ("None");
                break;
            case Stat.Spd:
                return ("Speed");
                break;
            case Stat.Atk:
                return ("Attack");
                break;
            case Stat.Def:
                return ("Defence");
                break;
            case Stat.Mgk:
                return ("Magic");
                break;
            case Stat.Res:
                return ("Res");
                break;
            case Stat.Dur:
                return ("Duribility");
                break;
            case Stat.Luc:
                return ("Luck");
                break;
            default:
                Debug.LogError("Error No Stat Listed for this Object. 404 Stat not Found.");
                return ("None");
                break;



        }
    }


}

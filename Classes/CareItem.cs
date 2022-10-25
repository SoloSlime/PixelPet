using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slimecode.Items
{
    public struct CareItem
    {
        public int ID;
        public string ItemName;
        public string Discription;
        public string Type;
        public float Caremultiplier;
        public string Stat;
        public float statbonus;
        public string ReducedCareArea;
        public float ReducedCareAmmount;

        public CareItem(int id,string itmName, string itmDiscrp, string CareItemType,float CareMultiplier,string StatToIncrease,float StatBonusAmmount)
        {
            this.ID = id;
            this.ItemName = itmName;
            this.Discription = itmDiscrp;
            this.Type = CareItemType;
            this.Caremultiplier = CareMultiplier;
            this.Stat = StatToIncrease;
            this.statbonus = StatBonusAmmount;
            this.ReducedCareArea = null;
            this.ReducedCareAmmount = 0;
        }
        public CareItem(int id, string itmName, string itmDiscrp, string CareItemType, float CareMultiplier, string StatToIncrease, float StatBonusAmmount,string CareStatToBeReduced, float ReducedAmmount)
        {
            this.ID = id;
            this.ItemName = itmName;
            this.Discription = itmDiscrp;
            this.Type = CareItemType;
            this.Caremultiplier = CareMultiplier;
            this.Stat = StatToIncrease;
            this.statbonus = StatBonusAmmount;
            this.ReducedCareArea = CareStatToBeReduced;
            this.ReducedCareAmmount = ReducedAmmount;
        }

    }
}


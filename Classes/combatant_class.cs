using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slimecode.combat
{

    [System.Serializable]
    public struct Combatant 

    {
        public string CombatentName;
        public float Speed;
        public float Attack;
        public float Defence;
        public float Magic;
        public float Resistance;
        public float Durability;
        public float Luck;
        public float CurrentHP;
        public Combatant(string name, float spd, float atk, float def, float mgk, float res, float dur, float luc, float curhp)
        {
            CombatentName = name;
            Speed = spd;
            Attack = atk;
            Defence = def;
            Magic = mgk;
            Resistance = res;
            Durability = dur;
            Luck = luc;
            CurrentHP = curhp;
        }


    }
}
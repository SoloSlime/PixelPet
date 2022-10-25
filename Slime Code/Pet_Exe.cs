 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using Slimecode.combat;
using Slimecode.Items;

public class Pet_Exe : MonoBehaviour
{

    public Pet Thispet;
    public Animator SlimeAni;
    public Animator EmoteAni;
    public Animator HappynessAni;
    public float LockoutTimer = 0f; // used to count down time until an action can occour.
    float Ticks = 0f; // used to messure timeflow

    public bool UpdateOccoured = true;

    // Start is called before the first frame update
    void Start()
    {
        Thispet.PetStats = new Combatant("Slime", 15f, 15f, 15f, 15f, 15f, 15f, 5f, 15f);
        Thispet.Hunger= Random.Range(20f, 70f);
        Thispet.Hygiene = Random.Range(20f, 70f);
        Thispet.Health = Random.Range(20f, 70f);
        Thispet.Fun = Random.Range(20f, 70f);
        Thispet.Exhaustion = Random.Range(20f, 70f);
        Thispet.Happyness= 50;
        HappynessAni.SetFloat("Happyness", Thispet.Happyness);     

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Ticks += 1 * Time.deltaTime;
        if (LockoutTimer > 0) { Actionlockout(); }
        if (Ticks > 30f) { UpdateNeeds(); Ticks = 0f; } //Makes needs begin to randomly deplete
        if (UpdateOccoured) { DisplayNeeds();} // makes slime emote its needs.
        
    }

    void Actionlockout()
    {
        LockoutTimer -= (1 * Time.deltaTime); // ticks down the time until the player can cause a diferent interaction.
        if (LockoutTimer < 0) { LockoutTimer = 0;}
    }
    void UpdateNeeds()
    {
        Thispet.Hunger+= Random.Range(0, 5);
        Thispet.Hygiene -= Random.Range(0, 5);
        Thispet.Health += Random.Range(0, 5);
        Thispet.Fun += Random.Range(0, 5);
        Thispet.Exhaustion += Random.Range(0, 5);

        if (Thispet.Hunger< 20 && Thispet.Hygiene > 80 && Thispet.Health > 80 && Thispet.Fun > 80 && Thispet.Exhaustion < 20) { Thispet.Happyness++; }
        else { Thispet.Happyness--; }
        UpdateOccoured = true;

    }

    void DisplayNeeds()
    {
        HappynessAni.SetFloat("Happyness", Thispet.Happyness);

        if (Thispet.Hunger> (Thispet.Needyness-100)) { EmoteAni.SetBool("Hungery",true); }
        if (Thispet.Hunger< (Thispet.Needyness -100)) { EmoteAni.SetBool("Hungery",false);}
        if (Thispet.Hygiene < Thispet.Needyness) { EmoteAni.SetBool("Stinky", true); }
        if (Thispet.Hygiene > Thispet.Needyness) { EmoteAni.SetBool("Stinky", false);}
        if (Thispet.Hygiene < Thispet.Needyness) { EmoteAni.SetBool("Stinky", true); }
        if (Thispet.Hygiene > Thispet.Needyness) { EmoteAni.SetBool("Stinky",false) ;}
        if (Thispet.Fun < Thispet.Needyness)    { EmoteAni.SetBool("Bored", true);  }
        if (Thispet.Fun > Thispet.Needyness)    { EmoteAni.SetBool("Bored", false); }
        if (Thispet.Exhaustion > (Thispet.Needyness - 100)){ EmoteAni.SetBool("Tired", true); }
        if (Thispet.Exhaustion < (Thispet.Needyness - 100)){ EmoteAni.SetBool("Tired", false);}
        if (Thispet.Happyness> 85) {EmoteAni.SetBool("Happy", true);}
        if (Thispet.Happyness< 85){EmoteAni.SetBool("Happy", false);}
        if (Thispet.Happyness<30)  { EmoteAni.SetBool("Sad", true); }
        if (Thispet.Happyness> 30) {EmoteAni.SetBool("Sad", false); }
        UpdateOccoured = false;
    }

    public void Bath()
    {
        if (LockoutTimer > 0) { }
        else
        {
            LockoutTimer = 60;
            Thispet.Hygiene += ((10 * Home_exe.BathSlot.Caremultiplier) + (LockoutTimer / 10));
            if (Home_exe.BathSlot.Stat != Stat.None)
            {
                Thispet.PetStats = AddStats(Thispet.PetStats, Home_exe.BathSlot.StatToString(Home_exe.BathSlot.Stat), Home_exe.BathSlot.statbonus); // Add stats format, Subject, Stat to change, Stat change amount
            }
            if (Home_exe.BathSlot.ReducedCareArea != CareArea.None)
            {
                switch (Home_exe.BathSlot.ReducedCareArea)
                {
                    case CareArea.Hunger:

                        Thispet.Hunger-= Home_exe.BathSlot.ReducedCareAmmount;

                        break;

                    case CareArea.Hygiene:

                        Thispet.Hygiene -= Home_exe.BathSlot.ReducedCareAmmount;

                        break;

                    case CareArea.Health:

                        Thispet.Health -= Home_exe.BathSlot.ReducedCareAmmount;

                        break;

                    case CareArea.Fun:

                        Thispet.Fun -= Home_exe.BathSlot.ReducedCareAmmount;

                        break;

                    case CareArea.Exhaustion:

                        Thispet.Exhaustion -= Home_exe.BathSlot.ReducedCareAmmount;

                        break;



                }
            }
            UpdateOccoured = true;
        }
    }

    public void Sleep()
    {
        if (LockoutTimer > 0) { }
        else 
        {
            LockoutTimer = 180;
            Thispet.Exhaustion -= ((10 * Home_exe.BedSlot.Caremultiplier) + (LockoutTimer / 10));
            if (Thispet.Exhaustion < 0) { Thispet.Exhaustion = 0; }



            Thispet.PetStats = AddStats(Thispet.PetStats, Home_exe.BedSlot.StatToString(Home_exe.BedSlot.Stat), Home_exe.BedSlot.statbonus);
            
            if (Home_exe.BedSlot.ReducedCareArea != CareArea.None)
            {
                
                switch (Home_exe.BedSlot.ReducedCareArea)
                {
                    case CareArea.Hunger:

                        Thispet.Hunger+= Home_exe.BedSlot.ReducedCareAmmount;

                        break;

                    case CareArea.Hygiene:

                        Thispet.Hygiene -= Home_exe.BedSlot.ReducedCareAmmount;

                        break;

                    case CareArea.Health:

                        Thispet.Health -= Home_exe.BedSlot.ReducedCareAmmount;

                        break;

                    case CareArea.Fun:

                        Thispet.Fun -= Home_exe.BedSlot.ReducedCareAmmount;

                        break;

                    case CareArea.Exhaustion:

                        Thispet.Exhaustion += Home_exe.BedSlot.ReducedCareAmmount;

                        break;



                }
            }
            UpdateOccoured = true;
        }

    }

    Combatant AddStats(Combatant Target, string Stat, float StatIncrease)
    {
     // Debug.Log("Attempting to increase stats...");
     // Debug.Log("Combatent:" + Target);
     // Debug.Log("Stat to be increased:" + Stat);
     // Debug.Log("Incrase Value Requested:" + StatIncrease);
    
        string CombatentName = Target.CombatentName;
        float Speed = Target.Speed;
        float Attack = Target.Attack;
        float Defence = Target.Defence;
        float Magic = Target.Magic;
        float Resistance = Target.Resistance;
        float Durability = Target.Durability;
        float Luck = Target.Luck;
        float CurrentHP = Target.CurrentHP;
     // Debug.Log("Current Stats- Spe:" + Speed + " ATK:" + Attack + " Def:" + Defence + " Mag:" + Magic + " Res:" + Resistance + " Dur:" + Durability);
       
        switch (Stat)
        {
            case "Speed":
                Speed += StatIncrease;
                break;
            case "Attack":
                Attack += StatIncrease;
                break;
            case "Defence":
                Defence += StatIncrease;
                break;
            case "Magic":
                Magic += StatIncrease;
                break;
            case "Resistance":
                Resistance += StatIncrease;
                break;
            case "Durability":
                Durability += StatIncrease;
                break;
        }
        Combatant tmp = new Combatant(CombatentName, Speed, Attack, Defence, Magic, Resistance, Durability, Luck, CurrentHP);
     // Debug.Log("Upgraded Stats- Spe:" + tmp.Speed + " ATK:" + tmp.Attack + " Def:" + tmp.Defence + " Mag:" + tmp.Magic + " Res:" + tmp.Resistance + " Dur:" + tmp.Durability);
        return tmp;
    }
}

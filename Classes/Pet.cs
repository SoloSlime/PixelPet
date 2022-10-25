using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slimecode.combat;
using Slimecode.Items;

public enum Personality { Childish,Mischevious,playfull,Mean,Tempermental,Helpfull, Lazy,Energetic,Easygoing,Social,Dirty,Needy}
public enum Species {Slime}
public class Pet : MonoBehaviour
{
    public Combatant PetStats; // stores slimes combat data.
    public Species PetSpecies; // lists the pet species.
    public float Hunger;
    public float Hygiene;
    public float Health;
    public float Fun;
    public float Exhaustion;
    public float Happyness;
    public float Needyness; // how quickly the pets needs decreese
    public float HungerNeedMod;
    public float HygieneNeedMod;
    public float HealthNeedMod;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }
}

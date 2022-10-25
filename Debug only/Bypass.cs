using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bypass : MonoBehaviour
{
    public GameObject Pet;
    public Pet_Exe petcode;
    public Text LockoutTimer;

    // Start is called before the first frame update
    void Start()
    {
        Pet = GameObject.FindGameObjectsWithTag("Pet")[0];
        petcode = Pet.GetComponent<Pet_Exe>();
   
    }

    // Update is called once per frame
    void Update()
    {
        LockoutTimer.text = ""+petcode.LockoutTimer;
    }

    public void ResetLockoutTimer()
    {
        petcode.LockoutTimer = 0;
    }

    public void AddStr()
    {
     
    }


}

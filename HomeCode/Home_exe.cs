using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Home_exe : MonoBehaviour
    {

    public static CareItemObject BedSlot; // holds data for the Bed 
    public static CareItemObject BathSlot; // holds data for the Bath
    public CareItemObject Bed;
    public CareItemObject Bath;
    // public static ToyItemObject ToySlot; // holds data for the toy * this probobly should more so be a list? 


    // Start is called before the first frame update
    private void Awake()
    {
        SetBathSlot(Bath);
        SetBedSlot(Bed);
    }
    void Start()
        {
     
        }

        // Update is called once per frame
        void Update()
        {

        }

      public void SetBathSlot(CareItemObject Bath)
        {
            BathSlot = Bath;
        }

     public void SetBedSlot(CareItemObject bed)
        {
            BedSlot = bed;
        }
    }

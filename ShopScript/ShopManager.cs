using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Slimecode.Time;
namespace Slimecode.Shop
{

    public class ShopManager : MonoBehaviour
    {

        
        public TMP_Text CoinsUI;
        public ItemObject[] ShopItemsSO;
        public GameObject[] ShopPannelsGO;
        public ShopTemplate[] ShopPannels;
        public Button[] MyPerchaseBtns;
        public InventoryObject PlayerInv;
        public string LastLoadedDay;

        public ItemObject[] MondayItems;
        public ItemObject[] TusedayItems;
        public ItemObject[] WednesdayItems;
        public ItemObject[] ThursdayItems;
        public ItemObject[] FridayItems;
        public ItemObject[] SaturdayItems;
        public ItemObject[] SundayItems;

        // Start is called before the first frame update
        void Start()
        {
            TimeManager.CheckDay();
            if (LastLoadedDay != TimeManager.Day)
            {
                switch (TimeManager.Day)
                {
                    case "Monday":
                        for (int i = 0; i < ShopItemsSO.Length; i++)
                        {
                            ShopItemsSO[i] = null;
                        }
                        for (int i = 0; i < MondayItems.Length; i++)
                        {
                            ShopItemsSO[i] = MondayItems[i];
                        }
                        break;

                    case "Tuseday":
                        for (int i = 0; i < ShopItemsSO.Length; i++)
                        {
                            ShopItemsSO[i] = null;
                        }
                        for (int i = 0; i < TusedayItems.Length; i++)
                        {
                            ShopItemsSO[i] = TusedayItems[i];
                        }
                        break;

                    case "Wednesday":
                        for (int i = 0; i < ShopItemsSO.Length; i++)
                        {
                            ShopItemsSO[i] = null;
                        }
                        for (int i = 0; i < WednesdayItems.Length; i++)
                        {
                            ShopItemsSO[i] = WednesdayItems[i];
                        }
                        break;

                    case "Thursday":
                        for (int i = 0; i < ShopItemsSO.Length; i++)
                        {
                            ShopItemsSO[i] = null;
                        }
                        for (int i = 0; i < ThursdayItems.Length; i++)
                        {
                            ShopItemsSO[i] = ThursdayItems[i];
                        }
                        break;

                    case "Friday":
                        for (int i = 0; i < ShopItemsSO.Length; i++)
                        {
                            ShopItemsSO[i] = null;
                        }
                        for (int i = 0; i < FridayItems.Length; i++)
                        {
                            ShopItemsSO[i] = FridayItems[i];
                        }
                        break;

                    case "Saturday":
                        for (int i = 0; i < ShopItemsSO.Length; i++)
                        {
                            ShopItemsSO[i] = null;
                        }
                        for (int i = 0; i < SaturdayItems.Length; i++)
                        {
                            ShopItemsSO[i] = SaturdayItems[i];
                        }
                        break;

                    case "Sunday":
                        for (int i = 0; i < ShopItemsSO.Length; i++)
                        {
                            ShopItemsSO[i] = null;
                        }
                        for (int i = 0; i < SundayItems.Length; i++)
                        {
                            ShopItemsSO[i] = SundayItems[i];
                        }
                        break;
                }


            }



            for (int i = 0; i < ShopItemsSO.Length; i++)
            {
                ShopPannelsGO[i].SetActive(true);


            }
            CoinsUI.text = "Coins:" + PlayerInv.Coins;
            CheckPerchaseable();
            LoadPanels();
        }

        // Update is called once per frame
        void Update()
        {

        }

    

        public void LoadPanels()
        {
            for (int i = 0; i < ShopItemsSO.Length; i++)
            {
                ShopPannels[i].titleTxt.text = ShopItemsSO[i].ItemName;
                ShopPannels[i].descriptionTxt.text = ShopItemsSO[i].Discription;
                ShopPannels[i].IconSpr.sprite = ShopItemsSO[i].Icon;
                ShopPannels[i].costTxt.text = ShopItemsSO[i].BuyValue.ToString();
            }
        }

        public void CheckPerchaseable()
        {
            for (int i = 0; i < ShopItemsSO.Length; i++)
            {
                if (ShopItemsSO[i].BuyValue > PlayerInv.Coins)
                {
                    MyPerchaseBtns[i].interactable = false;
                }
                else
                {
                    MyPerchaseBtns[i].interactable = true;
                }
            }
        }

        public void PerchaseItem(int BtnNo)
        {
            if (PlayerInv.Coins >= ShopItemsSO[BtnNo].BuyValue) // checks to see if Coincs exceed the buy value of an object.
            {
               // Debug.Log("Attempting to dispence item" + BtnNo);
                PlayerInv.RemoveCoins(ShopItemsSO[BtnNo].BuyValue); // takes coins from player inventory.
                CoinsUI.text = "Coins:" + PlayerInv.Coins; 
                PlayerInv.AddItem(ShopItemsSO[BtnNo], 1);
                CheckPerchaseable();

            }

        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Slimecode.Shop;
namespace Slimecode.InvManager
{

    public class PlayerInv : MonoBehaviour
    {
        public InventoryObject inventory;
        public List<Item> ItemList;
        public ItemObject[] ItemSlot;
        public ItemLayout[] ItemLayout;
        public GameObject[] ItemSlotDisplay;
        public TMP_Text CoinDisplay;



        public void Awake()
        {
            UpdateInventoryDisplay();
        }

        public void Start()
        {
            UpdateInventoryDisplay();
            LoadPanels();
            
        }

        public void LoadPanels()
        {
            for (int i = 0; i < inventory.Container.Count; i++)
            {
                ItemLayout[i].ItemName.text = ItemSlot[i].ItemName;
                ItemLayout[i].FurnitureUsed.isOn = inventory.IsInUse(ItemSlot[i]);
                ItemLayout[i].ItemIcon.sprite = ItemSlot[i].Icon;
                ItemLayout[i].Amount.text = ItemSlot[i].BuyValue.ToString();
            }
        }

        public void UpdateInventoryDisplay()
        {
            CoinDisplay.text = "Coins:" + inventory.Coins;

            for (int i = 0; i < inventory.Container.Count; i++)
            {
                ItemSlot[i] = inventory.Container[i].item;
            }

            for (int i = 0; i < ItemSlot.Length; i++)
            {
                ItemList[i].ItemName.text = ItemSlot[i].ItemName;
                ItemList[i].ItemAmmount.text = inventory.Container[i].Amount.ToString();
                ItemList[i].ItemSprite.sprite = ItemSlot[i].Icon;
            }
        }

        public void UseItem(ItemObject Itm)
        {
          switch (Itm.type)
            {
                case ItemType.Food:
                   
                    //FoodObject fud = inventory.database.GetID[Itm], Itm); 
                    break;

                case ItemType.CareItem:

                    break;
                case ItemType.Furniture:

                    break;
                case ItemType.Toy:

                    break;

                case ItemType.Other:

                    break;



            }


        }
    }

    public class ItemLayout : MonoBehaviour
    {
        public TMP_Text ItemName;        // simply holds the local instance of the details from the instancated object in question.
        public Image ItemIcon;
        public Toggle FurnitureUsed;
        public TMP_Text Amount;
    }

}





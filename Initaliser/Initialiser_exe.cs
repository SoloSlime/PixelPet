using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Slimecode.Items
{

    public class Initialiser_exe : MonoBehaviour
    {
        public InventoryObject PlayerInv;
        public ItemObject[] StartingItems;

       public void NewGame()
        {
            PlayerInv = new InventoryObject();

            for (int i = 0; i < StartingItems.Length; i++)
            {
                PlayerInv.AddItem(StartingItems[i], 1);

            }

          
            

        }

    }
}

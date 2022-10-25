using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Database", menuName = "Inventory Syestem/Items/Database" )]
public class ItemDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    public List<UniversalItem> items; // creates a scalable arry of item objects
    public Dictionary<ItemObject, int> GetID = new Dictionary<ItemObject, int>(); // used as a dictionary to hold all items and their id's
    public Dictionary<int,ItemObject > GetItem = new Dictionary<int, ItemObject>(); // a copy of the above dictonary for quicker calls to items held, forgos a forloop and long loads but doubles memory usage.


    public void OnAfterDeserialize()
    {
        GetID = new Dictionary<ItemObject, int>(); // dictonary that when provided an item will return the ID
        GetItem = new Dictionary<int, ItemObject>(); // dictonary that when provided the ID will return the object
      for (int i = 0; i < items.Count; i++) // loop to poulate database with items.
        {
            GetID.Add(items[i], i);
            GetItem.Add(i, items[i]);
        }

      

    }


    public void OnBeforeSerialize()
    {
      
    }
}


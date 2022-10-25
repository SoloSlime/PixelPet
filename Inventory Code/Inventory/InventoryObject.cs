using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;


[CreateAssetMenu(fileName ="New Inventory", menuName = "Inventory Syestem/Inventory")]
public class InventoryObject : ScriptableObject, ISerializationCallbackReceiver // Uses Seralisation for save function
{
    public string savePath;
    public ItemDatabaseObject database;
    public List<InventorySlot> Container = new List<InventorySlot>();
    public int Coins;

    public void OnEnable()
    {
#if UNITY_EDITOR
        database = (ItemDatabaseObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/database.asset",typeof(ItemDatabaseObject));
#else
        database = Resources.Load<ItemDatabaseObject>("database");
#endif
    }

    public void AddItem(ItemObject _item, int _amount)
    {
       
        for (int i = 0; i < Container.Count; i++) // Checks through eeach item within the container.
        {
            if (Container[i].item == _item)    // checks to see if the item to be added is allready present in the players inventory.
            {
              
                Container[i].AddAmount(_amount); // if it is will add increase the ammount counter against that item.
                return; // breaks the code within this loop and exits out preventing any code beyond this point from running within this fucntion.
            }
        }
        
        Container.Add(new InventorySlot(database.GetID[_item],_item, _amount)); // Finds item in Item database and lists the ID, Item Object & ammout of that item the user has.
        
    }

    public ItemObject FindItemWithType(ItemType itemtype)
    {
        
        for (int i = 0; i < Container.Count; i++)
        {
            if(Container[i].item.type == itemtype)
            {
                return (Container[i].item);
            }
        }
        Debug.Log("No Item of TYPE:"+ itemtype + " was found Error 001");
        return (null);
    }

    public bool IsInUse(ItemObject _item)
    {
        if (_item == Home_exe.BathSlot || Home_exe.BedSlot)
        {
            return (true);
        }
        else return (false);
    }
  


    [ContextMenu("Save")]
    public void Save() 
    {
        string saveData = JsonUtility.ToJson(this, true); // makes a jason type text
        BinaryFormatter bf = new BinaryFormatter(); //
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        bf.Serialize(file, saveData);
        file.Close();
    }
    [ContextMenu("Load")]
    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savePath))){
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            file.Close();
        }

    }
    public void OnAfterDeserialize() // beforce Sealising data ensures that Item Database is matached via ID 
    {
        for (int i = 0; i < Container.Count; i++)
        {
            Debug.Log("The Current ID being Searched is container" + Container[i].ID);
           
            Container[i].item = database.GetItem[Container[i].ID];
            
        }
    }

    public void OnBeforeSerialize()
    {
        
    }

    public void RemoveItem(ItemObject _item, int _amount)
    {
      
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                Container[i].DeductAmount( _amount);
                if (Container[i].Amount <= 0) {Container.RemoveAt(i);}
                
                break;
            }
        }
      
    }

    public void Addcoins(int ammount)
    {
        Coins+= ammount;

    }

    public void RemoveCoins(int charge)
    {
        Coins -= charge;

    }



}


[System.Serializable]
public class InventorySlot
{
    public int ID;
    public ItemObject item;
    public int Amount;
    public InventorySlot(int _id, ItemObject _item, int _Amount)
    {
        ID = _id;
        item = _item;
        Amount = _Amount;
    }
    public void AddAmount(int value)
    {
        Amount += value;
    }
    public void DeductAmount(int value)
    {
        Amount -= value;
    }


}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
   public List<ItemsManager> itemsList;
    void Start()
    {
        instance = this;
        itemsList = new List<ItemsManager>();
      
    }

    public void AddItems(ItemsManager item)
    {
        if (item.isStackable)
        {
            bool itemsAlreadyInInventory = false;

            foreach (ItemsManager itemInInventory in itemsList)
            {
                if (itemInInventory.itemName == item.itemName)
                {
                    itemInInventory.amount += item.amount;
                    itemsAlreadyInInventory = true;
                }
            }
            if (!itemsAlreadyInInventory)
            {

                itemsList.Add(item);
            }
        }
        else
        {
            itemsList.Add(item);
        }
    }
    public void RevomeItem(ItemsManager item)
    {
        if (item.isStackable)
        {
            ItemsManager inventoryItem = null;

            foreach(ItemsManager itemInInventory in itemsList)
            {
                if(itemInInventory.itemName == item.itemName)
                {
                    itemInInventory.amount--;
                    inventoryItem = itemInInventory;
                }
            }
            if(inventoryItem!= null && inventoryItem.amount<= 0)
            {
                itemsList.Remove(inventoryItem);
            }
        }
        else
        {
            itemsList.Remove(item);
        }
    }
    public List<ItemsManager> GetItemsList()
    {
        return itemsList;
    }
}

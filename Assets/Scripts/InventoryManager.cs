using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public HotbarInventory inventory;
    public List<InventoryItem> items = new List<InventoryItem>();

    private void Start()
    {
        inventory = GetComponent<HotbarInventory>();
    }


    public void AddItem (InventoryItem item)
    {
        if (items.Count < inventory.slotCount)
        {
            items.Add(item);
            Debug.Log("Added " + item.name);
            inventory.UpdateHotbarUI();
        }
        
    }
    public void RemoveItem (InventoryItem item) {
        items.Remove(item); 
        inventory.UpdateHotbarUI();
    
    }

    public List<InventoryItem> GetItems ()
    {
        return new List<InventoryItem>(items);
    }
}

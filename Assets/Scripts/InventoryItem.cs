using UnityEngine;



public enum Itemtype
{
    Key,
    HoneyJar,
}

[CreateAssetMenu(fileName = "InventoryItem", menuName = "Scriptable Objects/InventoryItem")]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public Sprite icon; // icon in the inventory
    public GameObject prefab;
    public Itemtype type;   
}

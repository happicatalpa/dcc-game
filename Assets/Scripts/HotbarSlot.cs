using UnityEngine;
using UnityEngine.UI;

public class HotbarSlot : MonoBehaviour
{
    public GameObject iconImage;
    public Image img;
    public int slotIndex;

    private void Start()
    {
        img = iconImage.GetComponent<Image>();
    }

    public void ShowItem(InventoryItem item)
    {
        if (item != null)
        {
            img.sprite = item.icon;
            Debug.Log(item.icon);
            img.enabled = true;
        }
        else
        {
            img.sprite = null;
            img.enabled = false;
        }

    }

}

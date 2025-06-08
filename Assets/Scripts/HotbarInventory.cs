using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class HotbarInventory : MonoBehaviour
{

    public GameObject[] slots;
    public int selectedSlot = 0;
    public int slotCount = 8;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateSelection();
        
    }

    // Update is called once per frame
    void Update()
    {

        DetectScroll();
        
    }

    void UpdateSelection ()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            GameObject highlight = slots[i].transform.Find("Highlight").gameObject;
            if (highlight != null)
            {
                if (selectedSlot == i)
                {
                    highlight.SetActive(true);
                } else
                {
                    highlight.SetActive(false);
                }
            } else
            {
                return;
            }
        }
    }

    void DetectScroll ()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll > 0f)
        {
            if (selectedSlot == 0)
            {
                selectedSlot = slotCount-1;
            } 
            else
            {
                selectedSlot = (selectedSlot - 1);
            }
            UpdateSelection();
        } else if (scroll < -0f)
        {
            if (selectedSlot == slotCount)
            {
                selectedSlot = 0;
            }
            else
            {
                selectedSlot = (selectedSlot + 1);
            }
            UpdateSelection();

        }
    }

    public void UpdateHotbarUI ()
    {
        var items = GameManager.Instance.inventoryManager.GetItems();

        for (int i = 0; i < slotCount; i++)
        {
            if (i < items.Count && items[i] != null)
            {
                slots[i].GetComponent<HotbarSlot>().ShowItem(items[i]);
            }
            else
            {
                slots[i].GetComponent<HotbarSlot>().ShowItem(null);
            }
        }
    }
}



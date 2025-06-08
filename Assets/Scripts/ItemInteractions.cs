using UnityEngine;

public class ItemInteractions : MonoBehaviour
{

    public InventoryItem item;
    public float pickupRange = 3f;
    private Transform player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < pickupRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Pickup();
            }
        }
    }

    void Pickup()
    {
        GameManager.Instance.inventoryManager.AddItem(item);
        Debug.Log("picked up: " + item.name);
        Destroy(gameObject); // destroy self after being collected
    }
}

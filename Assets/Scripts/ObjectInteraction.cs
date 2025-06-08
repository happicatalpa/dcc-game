using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Progress;

public class ObjectInteraction : MonoBehaviour
{
    public float interactionRange = 3f; // Set max range for interaction
    public string message;
    public InventoryItem item; // Optional: if the item is collectable


    public float DistanceToPlayer(Transform player)
    {
        return Vector3.Distance(player.position, transform.position); 
    }

    private void OnEnable()
    {
        InteractionManager.Register(this);
    }
    private void OnDisable()
    {
        InteractionManager.Unregister(this);
    }

    

}

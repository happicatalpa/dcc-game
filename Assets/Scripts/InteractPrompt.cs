using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractPrompt : MonoBehaviour
{
    public GameObject interactPrompt; // The TMP message
    public Transform player; // Track position of player
    public float interactionRange = 3f; // Set max range for interaction

    private void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position); // Get distance between interactable object and player

        if (distance < interactionRange)
        {
            interactPrompt.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("entered the hive!");
                getObjectInteraction();
            }

        } 
        
        else
        {
            interactPrompt.SetActive(false);
        }

    }

    private void getObjectInteraction ()
    {
        if (tag == "Beehive")
        {
            SceneManager.LoadScene("Beehive");
        }
    }

}

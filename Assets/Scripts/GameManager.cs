using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public InventoryManager inventoryManager;
    public PromptDisplay prompt;
    public InteractionManager interactionManager;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // this is a duplicate
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        inventoryManager = GetComponent<InventoryManager>();
        prompt = GetComponent<PromptDisplay>();
        interactionManager = GetComponent<InteractionManager>();
    }
}

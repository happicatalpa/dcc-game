using TMPro;
using UnityEngine;

public class PromptDisplay : MonoBehaviour
{
    public GameObject interactPrompt; // The TMP message


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void ShowMessage(string message)
    {
        interactPrompt.GetComponent<TextMeshProUGUI>().text = message;
        interactPrompt.SetActive(true);

    }

    public void ClearMessage()
    {
        interactPrompt.SetActive(false);
    }
}

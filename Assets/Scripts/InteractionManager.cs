using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Security.Cryptography;
using static UnityEditor.Progress;
using UnityEngine.SceneManagement;

public class InteractionManager : MonoBehaviour
{
    public static List<ObjectInteraction> interactables = new List<ObjectInteraction>();
    private ObjectInteraction closest;
    private Transform player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float closestDistance = float.MaxValue; // Set the farthest default value
        ObjectInteraction interactable = null;

        foreach (ObjectInteraction obj in interactables)
        {
            float dist = obj.DistanceToPlayer(player);
            if (dist < closestDistance && dist < obj.interactionRange)
            {
                closestDistance = dist;
                interactable = obj;
            }
        }

        if (interactable != null)
        {
  
            closest = interactable;
            GameManager.Instance.prompt.ShowMessage(closest.message);
            

            if (Input.GetKey(KeyCode.E))
            {
                getObjectInteraction();
            }

        }
        else
        {
            closest = null;
            GameManager.Instance.prompt.ClearMessage();
        }
        
    }

    public static void Register (ObjectInteraction obj)
    {
        interactables.Add(obj);
    }
    public static void Unregister(ObjectInteraction obj)
    {
        interactables.Remove(obj);
    }

    private void getObjectInteraction()
    {
        GameObject thisObj = closest.gameObject;

        if (thisObj.tag == "Beehive")
        {
            SceneManager.LoadScene("Beehive");
        }

        else if (thisObj.tag == "Jar")
        {
            GameManager.Instance.inventoryManager.AddItem(closest.item);
            Debug.Log("picked up: " + closest.item.name);
            Destroy(thisObj); // destroy after being collected
        }
    }


}

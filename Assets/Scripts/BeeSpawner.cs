using UnityEngine;

public class BeeSpawner : MonoBehaviour
{
    public GameObject beePrefab;
    public float spawnDelay = 5f;
    public Transform hivePosition;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(spawnBee), 0f, spawnDelay);
    }

    void spawnBee ()
    {
        if (beePrefab == null || hivePosition == null)
        {
            return;
        }

        Instantiate(beePrefab, hivePosition.position + new Vector3(0.3f, 0, 0.3f), hivePosition.rotation);
    }
}

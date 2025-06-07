using UnityEngine;

public class beeNPCs : MonoBehaviour
{

    public float moveSpeed = 2f;
    public float turnSpeed = 2f;
    public float changeDirectionInterval = 3f;
    private Vector3 targetDirection;
    public float minHeight = 2.0f; // How high to stay above ground
    public float maxHeight = 20f; // Max height above ground

    void Start()
    {
        ChooseNewDirection();
        transform.rotation = Quaternion.LookRotation(targetDirection) * Quaternion.Euler(0, 180f, 0) ;
        InvokeRepeating("ChooseNewDirection", changeDirectionInterval, changeDirectionInterval);
    }

    void Update()
    {
        // Smoothly rotate towards the new direction
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection) * Quaternion.Euler(0, 180f, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);

        // Move forward
        transform.position += -1* transform.forward * moveSpeed * Time.deltaTime;

        // Raycast ground check
        KeepInRange();
    }

    void ChooseNewDirection()
    {
        // Random horizontal direction with slight vertical motion
        targetDirection = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-0.3f, 0.3f),
            Random.Range(-1f, 1f)
        ).normalized;
    }

    void KeepInRange()
    {
        RaycastHit hit;

        // Cast ray down
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 100f))
        {
            float groundY = hit.point.y;
            float minY = groundY + minHeight;
            float maxY = groundY +maxHeight;

            // change position if too low
            if (transform.position.y < minY)
            {
                Vector3 pos = transform.position;
                pos.y = Mathf.Lerp(pos.y, minY, Time.deltaTime * 5f);
                transform.position = pos;   
            }
            else if (transform.position.y > maxY ){
                Vector3 pos = transform.position;
                pos.y = Mathf.Lerp(pos.y, maxY, Time.deltaTime * 5f);
                transform.position = pos;

            }
        }
    }

}

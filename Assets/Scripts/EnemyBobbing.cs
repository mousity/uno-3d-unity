using UnityEngine;

public class EnemyBobbing : MonoBehaviour
{

    public float bobSpeed;
    public float bobAmount;
    private Vector3 startPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Remember the start position for the enemy
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Move enemy up and down in a wave using Mathf.sin
        float newY = Mathf.Sin(Time.time * bobSpeed) * bobAmount;
        //Set the new position
        transform.position = new Vector3(startPosition.x, startPosition.y + newY, startPosition.z);

    }
}

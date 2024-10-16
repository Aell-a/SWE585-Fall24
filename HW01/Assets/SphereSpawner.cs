using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    public GameObject spherePrefab; // Reference to the sphere prefab

    void Update()
    {
        // Check if the spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnSphere();
        }
    }

    void SpawnSphere()
    {
        // Generate random x and z coordinates within the specified range
        float randomX = Random.Range(-4f, 4f);
        float randomZ = Random.Range(-4f, 4f);
        
        // Set the spawn position with a fixed y-coordinate of 2
        Vector3 spawnPosition = new Vector3(randomX, 2f, randomZ);
        
        // Instantiate the sphere prefab at the calculated position with default rotation
        Instantiate(spherePrefab, spawnPosition, Quaternion.identity);
    }
}
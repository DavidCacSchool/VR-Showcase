using UnityEngine;
using System.Collections;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public Transform spawnArea;
    public float spawnInterval = 0.01f;
    private bool isSpawning = false;

    public void Spawn()
    {
        isSpawning = true;
        StartCoroutine(SpawnObjects());
    }

    public void NotSpawn()
    {
        isSpawning = false;
    }

    public IEnumerator SpawnObjects()
    {
        while(isSpawning)
        {
            Vector3 randomPosition = GetRandomPointOnPlane();
            GameObject prefab = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];
            Instantiate(prefab, randomPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    Vector3 GetRandomPointOnPlane()
    {
        Renderer planeRenderer = spawnArea.GetComponent<Renderer>();
        if(planeRenderer == null)
        {
            Debug.LogError("Spawn Area must have a Renderer component!");
            return Vector3.zero;
        }

        Bounds bounds = planeRenderer.bounds;
        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomZ = Random.Range(bounds.min.z, bounds.max.z);
        float y = bounds.max.y;

        return new Vector3(randomX, y, randomZ);
    }
}
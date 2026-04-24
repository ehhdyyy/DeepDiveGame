using UnityEngine;
using System.Collections.Generic;

public class ZoneSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject coinPrefab;
    public GameObject bubblePrefab;
    public LayerMask groundLayer;

    [Header("Spawn Settings")]
    public int maxObjects = 20;
    public float spawnInterval = 2f;
    [Range(0f, 1f)] public float bubbleChance = 0.4f;

    [Header("Spawn Area")]
    public Vector3 areaSize = new Vector3(20f, 10f, 20f);

    [Header("Optional")]
    public Transform parentForSpawnedObjects;
    public float groundOffset = 1.5f;

    private float timer;
    private List<GameObject> spawnedObjects = new List<GameObject>();

    void Update()
    {
        timer += Time.deltaTime;

        CleanupDestroyedObjects();

        if (timer >= spawnInterval && spawnedObjects.Count < maxObjects)
        {
            timer = 0f;
            SpawnRandomObject();
        }
    }

    void SpawnRandomObject()
    {
        Vector3 spawnPos = GetRandomPositionInZone();

        GameObject prefabToSpawn = Random.value < bubbleChance ? bubblePrefab : coinPrefab;

        if (prefabToSpawn == null)
        {
            Debug.LogWarning("Missing prefab in ZoneSpawner.");
            return;
        }

        GameObject spawned = Instantiate(
            prefabToSpawn,
            spawnPos,
            Quaternion.identity,
            parentForSpawnedObjects
        );

        spawnedObjects.Add(spawned);
    }

    Vector3 GetRandomPositionInZone()
    {
        Vector3 center = transform.position;

        float randomX = Random.Range(-areaSize.x / 2f, areaSize.x / 2f);
        float randomY = Random.Range(-areaSize.y / 2f, areaSize.y / 2f);
        float randomZ = Random.Range(-areaSize.z / 2f, areaSize.z / 2f);

        Vector3 spawnPos = center + new Vector3(randomX, randomY, randomZ);

        float groundY;
        if (TryGetGroundHeight(spawnPos, out groundY))
        {
            if (spawnPos.y < groundY + groundOffset)
            {
                spawnPos.y = groundY + groundOffset;
            }
        }

        return spawnPos;
    }

    bool TryGetGroundHeight(Vector3 position, out float groundY)
    {
        Vector3 rayStart = new Vector3(position.x, position.y + 1000f, position.z);

        RaycastHit hit;
        if (Physics.Raycast(rayStart, Vector3.down, out hit, 2000f, groundLayer))
        {
            groundY = hit.point.y;
            return true;
        }

        groundY = 0f;
        return false;
    }
    void CleanupDestroyedObjects()
    {
        spawnedObjects.RemoveAll(obj => obj == null);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, areaSize);
    }
}
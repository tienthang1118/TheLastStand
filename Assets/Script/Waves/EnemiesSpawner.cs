using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    private float spawnPositionX = 12.8f;
    private float spawnPositionZ = 8f;
    private Transform mainCameraTransform;

    private void Awake()
    {
        mainCameraTransform = Camera.main.transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnZombie(GameObject enemyPrefab)
    {
        ObjectPoolManager.SpawnObject(enemyPrefab, SpawnPosition(), Quaternion.identity, ObjectPoolManager.PoolType.GameObject);
    }
    Vector3 SpawnPosition()
    {
        Vector3 position = new Vector3();
        float sign;
        do
        {
            sign = Random.value > 0.5f ? 1f : -1f;
            if(Random.value > 0.5f)
            {
            
                position.x = Random.Range(mainCameraTransform.position.x - spawnPositionX, mainCameraTransform.position.x + spawnPositionX);
                position.z = mainCameraTransform.position.z + (spawnPositionZ * sign);
            }
            else
            {
                position.z = Random.Range(mainCameraTransform.position.z - spawnPositionZ, mainCameraTransform.position.z + spawnPositionZ);
                position.x = mainCameraTransform.position.x + (spawnPositionX * sign);
            }
        }
        while (position.x > 50 || position.x < -50 || position.z > 50 || position.z < -50);
        return position;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesManager : MonoBehaviour
{
    [Header("Hit particle prefab")]
    [SerializeField]
    private GameObject hitParticlePrefab;

    [Header("Shoot particle prefab")]
    [SerializeField]
    private GameObject shootParticlePrefab;

    [Header("Zombie death Particle prefab")]
    [SerializeField]
    private GameObject zombieDeathParticlePrefab;

    public void PlayHitParticle(Transform transform)
    {
        ObjectPoolManager.SpawnObject(hitParticlePrefab, transform.position, transform.rotation, ObjectPoolManager.PoolType.ParticleSystem);
    }
    public void PlayShootParticle(Transform transform)
    {
        ObjectPoolManager.SpawnObject(shootParticlePrefab, transform);
    }
    public void PlayZombieDeathParticle(Transform transform)
    {
        ObjectPoolManager.SpawnObject(zombieDeathParticlePrefab, transform.position, transform.rotation, ObjectPoolManager.PoolType.ParticleSystem);
    }
}

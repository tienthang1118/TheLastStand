using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : HumanoidHealthManager
{
    private ParticlesManager particlesManager;
    private PlayerStats playerStats;
    private BulletSpawner bulletSpawner;
    private WaveManager waveManager;
    protected override void Awake()
    {
        base.Awake();
        particlesManager = FindAnyObjectByType<ParticlesManager>();
        playerStats = FindAnyObjectByType<PlayerStats>();
        bulletSpawner = FindAnyObjectByType<BulletSpawner>();
        waveManager = FindAnyObjectByType<WaveManager>();
    }

    private void OnEnable()
    {
        humanoidStats.CurrentHealthPoint = humanoidStats.MaxHealthPoint;
    }
    public override void Die()
    {
        waveManager.EnemyNumbers--;
        particlesManager.PlayZombieDeathParticle(gameObject.transform);
        for(int i = 0; i < playerStats.BulletBounceAmount; i++)
        {
            bulletSpawner.SpawnRandomBullet(playerStats.Damage, BulletType.PlayerBullet, transform.position);
        }
        ObjectPoolManager.ReturnObjectToPool(gameObject);
    }
}

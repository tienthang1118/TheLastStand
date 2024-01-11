using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [Header("Bullet Prefab")]
    [SerializeField]
    private GameObject playerBulletPrefab;
    [SerializeField]
    private GameObject shooterZombieBulletPrefab;
    [SerializeField]
    private GameObject eliteShooterZombieBulletPrefab;

    private HumanoidStats enemyStats;

    private Quaternion bulletSpawnRotation;

    private void Awake()
    {
        enemyStats = GetComponent<HumanoidStats>();
    }

    public void SpawnRandomBullet(int bulletDamage, BulletType type, Vector3 position)
    {
        bulletSpawnRotation = Quaternion.Euler(new Vector3(0, Random.Range(0f, 360f), 0));

        switch(type)
        {
            case BulletType.PlayerBullet:
                ObjectPoolManager.SpawnObject(playerBulletPrefab, position, bulletSpawnRotation, ObjectPoolManager.PoolType.GameObject).GetComponent<Bullet>().SetBulletDamage(bulletDamage);
                break;
            case BulletType.ShooterZombieBullet:
                ObjectPoolManager.SpawnObject(shooterZombieBulletPrefab, position, bulletSpawnRotation, ObjectPoolManager.PoolType.GameObject).GetComponent<Bullet>().SetBulletDamage(bulletDamage);
                break;
            case BulletType.EliteShooterZombieBullet:
                ObjectPoolManager.SpawnObject(eliteShooterZombieBulletPrefab, position, bulletSpawnRotation, ObjectPoolManager.PoolType.GameObject).GetComponent<Bullet>().SetBulletDamage(bulletDamage);
                break;
        }

    }
}

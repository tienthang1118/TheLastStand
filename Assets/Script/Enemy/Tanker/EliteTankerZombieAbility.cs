using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteTankerZombieAbility : MonoBehaviour
{
    /*[Header("Bullet Prefab")]
    [SerializeField]
    private GameObject BulletPrefab;*/

    private BulletSpawner bulletSpawner;

    private HumanoidStats enemyStats;

    //private Quaternion bulletSpawnRotation;

    private void Awake()
    {
        enemyStats = GetComponent<HumanoidStats>();
        bulletSpawner = FindAnyObjectByType<BulletSpawner>();
    }

    public void SpawnRandomBullet()
    {
        //bulletSpawnRotation = Quaternion.Euler(new Vector3(0, Random.Range(0f, 360f), 0));
        //ObjectPoolManager.SpawnObject(BulletPrefab, transform.position, bulletSpawnRotation, ObjectPoolManager.PoolType.GameObject).GetComponent<Bullet>().SetBulletDamage(enemyStats.Damage);
        bulletSpawner.SpawnRandomBullet(enemyStats.Damage, BulletType.ShooterZombieBullet, transform.position);
    }
}
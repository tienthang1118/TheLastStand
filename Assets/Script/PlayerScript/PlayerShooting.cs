using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Bullet Prefab")]
    [SerializeField]
    private GameObject BulletPrefab;

    [Header("Bullet Spawn Position")]
    [SerializeField]
    private Transform bulletSpawnTransform;

    private float elapseReloadTime;

    private PlayerStats playerStats;

    private AudioManager audioManager;

    private ParticlesManager particlesManager;

    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
        audioManager = FindAnyObjectByType<AudioManager>();
        particlesManager = FindAnyObjectByType<ParticlesManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        elapseReloadTime = playerStats.ReloadTime;
    }

    // Update is called once per frame
    void Update()
    {
        ShootBullet();
    }
    void ShootBullet()
    {
        elapseReloadTime += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            SpawnBullet();
        }
        if (Input.GetMouseButton(0))
        {
            
            if (elapseReloadTime > playerStats.ReloadTime)
            {
                SpawnBullet();
            }
        }
    }
    void SpawnBullet()
    {
        if (elapseReloadTime > playerStats.ReloadTime)
        {
            elapseReloadTime = 0;
            switch (playerStats.GunAmount)
            {
                case 1:
                    ObjectPoolManager.SpawnObject(BulletPrefab, bulletSpawnTransform.position, bulletSpawnTransform.rotation, ObjectPoolManager.PoolType.GameObject).GetComponent<Bullet>().SetBulletDamage(playerStats.Damage);
                    break;
                case 2:
                    ObjectPoolManager.SpawnObject(BulletPrefab, new Vector3(bulletSpawnTransform.position.x - 0.1f, bulletSpawnTransform.position.y, bulletSpawnTransform.position.z), bulletSpawnTransform.rotation, ObjectPoolManager.PoolType.GameObject).GetComponent<Bullet>().SetBulletDamage(playerStats.Damage);
                    ObjectPoolManager.SpawnObject(BulletPrefab, new Vector3(bulletSpawnTransform.position.x + 0.1f, bulletSpawnTransform.position.y, bulletSpawnTransform.position.z), bulletSpawnTransform.rotation, ObjectPoolManager.PoolType.GameObject).GetComponent<Bullet>().SetBulletDamage(playerStats.Damage);
                    break;
                case 3:
                    ObjectPoolManager.SpawnObject(BulletPrefab, bulletSpawnTransform.position, bulletSpawnTransform.rotation, ObjectPoolManager.PoolType.GameObject).GetComponent<Bullet>().SetBulletDamage(playerStats.Damage);
                    ObjectPoolManager.SpawnObject(BulletPrefab, bulletSpawnTransform.position, transform.rotation * Quaternion.Euler(0, 15, 0), ObjectPoolManager.PoolType.GameObject).GetComponent<Bullet>().SetBulletDamage(playerStats.Damage);
                    ObjectPoolManager.SpawnObject(BulletPrefab, bulletSpawnTransform.position, transform.rotation * Quaternion.Euler(0, -15, 0), ObjectPoolManager.PoolType.GameObject).GetComponent<Bullet>().SetBulletDamage(playerStats.Damage);
                    break;
                case 4:
                    ObjectPoolManager.SpawnObject(BulletPrefab, new Vector3(bulletSpawnTransform.position.x - 0.1f, bulletSpawnTransform.position.y, bulletSpawnTransform.position.z), bulletSpawnTransform.rotation, ObjectPoolManager.PoolType.GameObject).GetComponent<Bullet>().SetBulletDamage(playerStats.Damage);
                    ObjectPoolManager.SpawnObject(BulletPrefab, new Vector3(bulletSpawnTransform.position.x + 0.1f, bulletSpawnTransform.position.y, bulletSpawnTransform.position.z), bulletSpawnTransform.rotation, ObjectPoolManager.PoolType.GameObject).GetComponent<Bullet>().SetBulletDamage(playerStats.Damage);
                    ObjectPoolManager.SpawnObject(BulletPrefab, bulletSpawnTransform.position, transform.rotation * Quaternion.Euler(0, 15, 0), ObjectPoolManager.PoolType.GameObject).GetComponent<Bullet>().SetBulletDamage(playerStats.Damage);
                    ObjectPoolManager.SpawnObject(BulletPrefab, bulletSpawnTransform.position, transform.rotation * Quaternion.Euler(0, -15, 0), ObjectPoolManager.PoolType.GameObject).GetComponent<Bullet>().SetBulletDamage(playerStats.Damage);
                    break;
                case 5:
                    ObjectPoolManager.SpawnObject(BulletPrefab, bulletSpawnTransform.position, bulletSpawnTransform.rotation, ObjectPoolManager.PoolType.GameObject).GetComponent<Bullet>().SetBulletDamage(playerStats.Damage);
                    ObjectPoolManager.SpawnObject(BulletPrefab, bulletSpawnTransform.position, transform.rotation * Quaternion.Euler(0, 15, 0), ObjectPoolManager.PoolType.GameObject).GetComponent<Bullet>().SetBulletDamage(playerStats.Damage);
                    ObjectPoolManager.SpawnObject(BulletPrefab, bulletSpawnTransform.position, transform.rotation * Quaternion.Euler(0, -15, 0), ObjectPoolManager.PoolType.GameObject).GetComponent<Bullet>().SetBulletDamage(playerStats.Damage);
                    ObjectPoolManager.SpawnObject(BulletPrefab, bulletSpawnTransform.position, transform.rotation * Quaternion.Euler(0, 30, 0), ObjectPoolManager.PoolType.GameObject).GetComponent<Bullet>().SetBulletDamage(playerStats.Damage);
                    ObjectPoolManager.SpawnObject(BulletPrefab, bulletSpawnTransform.position, transform.rotation * Quaternion.Euler(0, -30, 0), ObjectPoolManager.PoolType.GameObject).GetComponent<Bullet>().SetBulletDamage(playerStats.Damage);
                    break;

            }
            particlesManager.PlayShootParticle(bulletSpawnTransform);
            audioManager.PlayShootSound();
        }
    }
}

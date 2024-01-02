using System.Collections;
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

    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
        audioManager = FindAnyObjectByType<AudioManager>();
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
            ObjectPoolManager.SpawnObject(BulletPrefab, bulletSpawnTransform.position, bulletSpawnTransform.rotation, ObjectPoolManager.PoolType.GameObject);
            audioManager.PlayShootSound();
        }
    }
}

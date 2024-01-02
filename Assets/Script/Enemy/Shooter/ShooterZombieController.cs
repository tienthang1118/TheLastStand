using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterZombieController : MonoBehaviour
{
    [Header("Bullet Prefab")]
    [SerializeField]
    private GameObject BulletPrefab;

    [Header("Bullet spawn transform")]
    [SerializeField]
    private Transform bulletSpawnTransform;

    private ShooterZombieStats ShooterZombieStats;

    private Transform playerTransform;

    float elapseReloadTime;

    private ShooterZomieAnimationManager animationManager;
    private void Awake()
    {
        ShooterZombieStats = GetComponent<ShooterZombieStats>();
        playerTransform = GameObject.FindGameObjectWithTag(GameTags.PLAYER).transform;
        animationManager = GetComponent<ShooterZomieAnimationManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        elapseReloadTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TakeAction();
        UpdateRotation();
    }
    void TakeAction()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        if (distanceToPlayer > ShooterZombieStats.AttackRange)
        {
            if(!animationManager.IsShootingAnimation())
            {
                animationManager.PlayRunAnimation(true);
                UpdateMovement();
            }
                
        }
        else
        {
            animationManager.PlayRunAnimation(false);
            SpawnBullet();
        }
    }
    void UpdateMovement()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        transform.position += direction * ShooterZombieStats.MovementSpeed * Time.deltaTime;
    }
    void UpdateRotation()
    {
        transform.LookAt(playerTransform);
    }
    public void AnimationEventShootBullet()
    {
        ObjectPoolManager.SpawnObject(BulletPrefab, bulletSpawnTransform.position, bulletSpawnTransform.rotation, ObjectPoolManager.PoolType.GameObject);
        animationManager.PlayShootAnimation(false);
    }
    void SpawnBullet()
    {
        elapseReloadTime += Time.deltaTime;
        if (elapseReloadTime > ShooterZombieStats.BulletReloadTime)
        {
            elapseReloadTime = 0;
            animationManager.PlayShootAnimation(true);
        }
    }
}

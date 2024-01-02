using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private enum SHOOTER
    {
        PLAYER,
        SHOOTERZOMBIE
    }
    private Rigidbody bulletRigidbody;

    [Header("Shooter")]
    [SerializeField]
    private SHOOTER shooter;

    [Header("Bullet speed")]
    [SerializeField]
    private float speed;

    [Header("Bullet explosion effect")]
    [SerializeField]
    private GameObject Explosion;

    [Header("Destroy bullet after active time")]
    [SerializeField]
    private float activeTime;

    private float elapseActiveTime;

    private TrailRenderer trailRenderer;

    private PlayerStats playerStats;

    private EnemyStats enemyStats;

    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
        playerStats = FindObjectOfType<PlayerStats>();
        enemyStats = FindObjectOfType<EnemyStats>();
        trailRenderer = GetComponent<TrailRenderer>();
        bulletRigidbody = GetComponent<Rigidbody>();
        elapseActiveTime = 0;
    }
    private void Start()
    {

    }
    private void Update()
    {
        UnactiveAfterTimeUp();
    }
    private void OnEnable()
    {
        trailRenderer.Clear();
        ResetElapseActiveTime();
        BulletFly();
    }
    void ResetElapseActiveTime()
    {
        elapseActiveTime = 0;
    }
    void BulletFly()
    {
        /*bulletRigidbody.AddForce(transform.forward * speed);*/
        bulletRigidbody.velocity = transform.forward * speed;
    }
    void UnactiveAfterTimeUp()
    {
        elapseActiveTime += Time.deltaTime;
        if (elapseActiveTime >= activeTime)
        {
            UnactiveBullet();
        }
    }
    void UnactiveBullet()
    {
        ObjectPoolManager.ReturnObjectToPool(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        DealDamage(other.gameObject);
    }
    
    void DealDamage(GameObject target)
    {
        switch (target.tag)
        {
            case GameTags.ENEMY:
                if(shooter == SHOOTER.PLAYER)
                {
                    UnactiveBullet();
                    target.GetComponent<EnemyHealthManager>().TakeDamage(playerStats.ShootDamage);
                    audioManager.PlayHitSound();
                }
                break;
            case GameTags.PLAYER:
                UnactiveBullet();
                target.GetComponent<PlayerHealthManager>().TakeDamage(enemyStats.Damage);
                audioManager.PlayHitSound();
                break;
        }
    }
}

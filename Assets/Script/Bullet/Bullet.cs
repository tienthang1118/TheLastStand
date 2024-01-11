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

    private int bulletDamage;

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

    private AudioManager audioManager;

    private ParticlesManager particlesManager;

    private PlayerStats playerStats;

    private void Awake()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
        playerStats = FindObjectOfType<PlayerStats>();
        trailRenderer = GetComponent<TrailRenderer>();
        bulletRigidbody = GetComponent<Rigidbody>();
        particlesManager = FindAnyObjectByType<ParticlesManager>();
        elapseActiveTime = 0;
    }
    private void Start()
    {

    }
    private void Update()
    {
        UnactiveAfterTimeUp();
        RaycastCheck();
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
    void RaycastCheck()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward *-1, out hit, 1))
        {
            if(hit.transform.gameObject.tag == GameTags.ENEMY)
            {
                DealDamage(hit.transform.gameObject);
            }
        }
    }

    public void SetBulletDamage(int damage)
    {
        bulletDamage = damage;
    }

    void DealDamage(GameObject target)
    {
        switch (target.tag)
        {
            case GameTags.ENEMY:
                if(shooter == SHOOTER.PLAYER)
                {
                    UnactiveBullet();
                    bulletDamage += (int)(playerStats.BloodDamge * target.GetComponent<HumanoidStats>().CurrentHealthPoint);
                    target.GetComponent<HumanoidHealthManager>().TakeDamage(bulletDamage);
                    particlesManager.PlayHitParticle(target.transform);
                    audioManager.PlayHitSound();
                }
                break;
            case GameTags.PLAYER:
                if (shooter != SHOOTER.PLAYER)
                {
                    UnactiveBullet();
                    target.GetComponent<HumanoidHealthManager>().TakeDamage(bulletDamage);
                    audioManager.PlayHitSound();
                }
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterZombieStats : HumanoidStats
{
    [Header("Attack range")]
    [SerializeField]
    private float attackRange;

    [Header("Bullet reload time")]
    [SerializeField]
    private float bulletReloadTime;

    public float AttackRange
    {
        get { return attackRange; }
        set { attackRange = value; }
    }
    public float BulletReloadTime
    {
        get { return bulletReloadTime; }
        set { bulletReloadTime = value; }
    }
}

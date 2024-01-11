using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteTankerZombieHealthManager : EnemyHealthManager
{
    private EliteTankerZombieAbility eliteTankerZombieAbility;

    protected override void Awake()
    {
        base.Awake();
        eliteTankerZombieAbility = GetComponent<EliteTankerZombieAbility>();
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        eliteTankerZombieAbility.SpawnRandomBullet();
    }
}

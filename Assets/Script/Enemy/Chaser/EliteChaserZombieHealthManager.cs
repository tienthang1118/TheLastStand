using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteChaserZombieHealthManager : EnemyHealthManager
{
    private EliteChaserAbility eliteChaserAbility;

    protected override void Awake()
    {
        base.Awake();
        eliteChaserAbility = GetComponent<EliteChaserAbility>();
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        eliteChaserAbility.IncreaseMovementSpeed(damage);
    }
}

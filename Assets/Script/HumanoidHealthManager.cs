using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidHealthManager : MonoBehaviour
{
    protected HumanoidStats humanoidStats;

    protected virtual void Awake()
    {
        humanoidStats = GetComponent<HumanoidStats>();
    }

    private void Start()
    {
        humanoidStats.CurrentHealthPoint = humanoidStats.MaxHealthPoint; 
    }

    public virtual void TakeDamage(int damage)
    {
        humanoidStats.CurrentHealthPoint -= damage;
        if (humanoidStats.CurrentHealthPoint <= 0)
        {
            Die();
        }
    }
    public virtual void Die()
    {
        Debug.Log("Die");
    }
}

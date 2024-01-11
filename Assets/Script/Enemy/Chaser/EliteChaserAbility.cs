using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteChaserAbility : MonoBehaviour
{
    private HumanoidStats enemyStats;

    [SerializeField] 
    private float movementGrowSpeed;
    private void Awake()
    {
        enemyStats = GetComponent<HumanoidStats>();
    }

    public void IncreaseMovementSpeed(int damage)
    {
        enemyStats.MovementSpeed += (float)damage / (float)enemyStats.MaxHealthPoint * movementGrowSpeed;
    }
}

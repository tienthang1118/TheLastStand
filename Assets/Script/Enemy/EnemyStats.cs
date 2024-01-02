using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    /*[Header("Max health point")]
    [SerializeField]
    private int maxHealthPoint;*/

    [Header("Movement speed")]
    [SerializeField]
    private float movementSpeed;

    [Header("Damage")]
    [SerializeField]
    private int damage;

    /*public int MaxHealthPoint
    {
        get { return maxHealthPoint; }
        set { maxHealthPoint = value; }
    }*/
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    public float MovementSpeed
    {
        get { return movementSpeed; }
        set { movementSpeed = value; }
    }
}

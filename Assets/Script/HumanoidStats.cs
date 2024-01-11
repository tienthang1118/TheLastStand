using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidStats : MonoBehaviour
{
    [Header("Max health point")]
    [SerializeField]
    protected int maxHealthPoint;

    [Header("Current health point")]
    [SerializeField]
    protected int currentHealthPoint;

    [Header("Damage")]
    [SerializeField]
    protected int damage;

    [Header("Player movement speed")]
    [SerializeField]
    protected float movementSpeed;
    private float baseMovementSpeed;

    public int MaxHealthPoint
    {
        get { return maxHealthPoint; }
        set { maxHealthPoint = value; }
    }
    public int CurrentHealthPoint
    {
        get { return currentHealthPoint; }
        set { currentHealthPoint = value; }
    }
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
    private void Awake()
    {
        baseMovementSpeed = movementSpeed;
    }
    private void OnEnable()
    {
        movementSpeed = baseMovementSpeed;
    }
}

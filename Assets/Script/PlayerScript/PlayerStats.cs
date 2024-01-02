using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Player max health point")]
    [SerializeField]
    private int maxHealthPoint;

    [Header("Player shoot reload time")]
    [SerializeField]
    private float reloadTime;

    [Header("Player shoot damage")]
    [SerializeField]
    private int shootDamage;

    [Header("Player movement speed")]
    [SerializeField]
    private float movementSpeed;
    
    public int MaxHealthPoint
    {
        get { return maxHealthPoint; }
        set { maxHealthPoint = value; }
    }
    public float ReloadTime
    {
        get{ return reloadTime;}
        set{ reloadTime = value;}
    }
    public int ShootDamage
    {
        get { return shootDamage; }
        set { shootDamage = value; }
    }
    public float MovementSpeed
    {
        get { return movementSpeed; }
        set { movementSpeed = value; }
    }
    public void IncreaseATSD(float percent)
    {
        reloadTime = reloadTime * ( 1 - percent);
    }
    public void IncreaseDMG(float percent)
    {
        shootDamage = (int)(shootDamage * (1 + percent));
    }
}

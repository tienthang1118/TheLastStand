using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : HumanoidStats
{
    [Header("Player shoot reload time")]
    [SerializeField]
    private float reloadTime;

    [SerializeField]
    private float bloodDamage = 0;
    [SerializeField]
    private int gunAmount = 1;
    [SerializeField]
    private int bulletBounceAmount = 0;

    public float ReloadTime
    {
        get{ return reloadTime;}
        set{ reloadTime = value;}
    }
    public float BloodDamge
    {
        get { return bloodDamage; }
        set { bloodDamage = value; }
    }
    public int GunAmount
    {
        get { return gunAmount; }
        set { gunAmount = value; }
    }
    public int BulletBounceAmount
    {
        get { return bulletBounceAmount; }
        set { bulletBounceAmount = value; }
    }
    public void IncreaseATSD(float percent)
    {
        reloadTime = reloadTime * ( 1 - percent);
    }
    public void IncreaseDMG(float percent)
    {
        damage = (int)(damage * (1 + percent));
    }
}

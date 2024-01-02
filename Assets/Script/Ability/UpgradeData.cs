using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class UpgradeData : ScriptableObject
{
    public Abilities Ability;
    public Sprite Icon;
    public string Summary;
    public float StatIncreasePercent;
}

public enum Abilities
{
    IncreaseATSD,
    IncreaseDMG
}
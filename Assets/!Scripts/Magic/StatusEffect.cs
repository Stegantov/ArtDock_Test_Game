using UnityEngine;

[System.Serializable]
public class StatusEffect
{
    public string name;
    public float duration;
    public bool isPermanent;
    public StatusEffectType effectType;
}

public enum StatusEffectType
{
    Slow,
    Burn
}
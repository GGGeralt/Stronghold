using GGGeralt.Stats;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stat
{
    public float Value
    {
        get
        {
            return CalculateFinalValue();
        }

        set
        {

        }
    }
    [SerializeField] float BaseValue = 0;
    [SerializeField] List<StatModifier> statModifiers;
    [SerializeField] float DEBUGVALUE;

    public void AddModifier(StatModifier modifier)
    {
        statModifiers.Add(modifier);
    }

    public bool RemoveModifier(StatModifier modifier)
    {
        return statModifiers.Remove(modifier);
    }

    float CalculateFinalValue()
    {
        float finalValue = BaseValue;
        foreach (StatModifier mod in statModifiers)
        {
            switch (mod.type)
            {
                case modType.Flat:
                    finalValue += mod.value;
                    break;
                case modType.Multiplicative:
                    finalValue *= mod.value;
                    break;
                default:
                    break;
            }
        }
        DEBUGVALUE = finalValue;
        return finalValue;
    }
}

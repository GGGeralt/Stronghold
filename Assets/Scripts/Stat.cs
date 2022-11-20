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
    }
    [SerializeField] float BaseValue = 0;
    [SerializeField] List<StatModifier> statModifiers;
    [SerializeField] float DEBUGVALUE;

    public float CalculateFinalValue()
    {
        float finalValue = BaseValue;
        float multiplier = 1;
        bool isFirstMultiplicative = false;

        foreach (StatModifier statMod in statModifiers)
        {
            Debug.Log("STATMOD: " + statMod.value + " TYPE: " + statMod.type);

            switch (statMod.type)
            {
                case modType.Flat:
                    finalValue += Mathf.RoundToInt(statMod.value);
                    break;

                case modType.PrecentageAdditive:
                    multiplier += statMod.value / 100;
                    Debug.Log("MULTIPLIER:" + multiplier);
                    break;

                case modType.PrecentageMultiplicative:
                    if (isFirstMultiplicative == false)
                    {
                        isFirstMultiplicative = true;
                        finalValue = Mathf.RoundToInt(finalValue * multiplier);
                    }
                    finalValue = Mathf.RoundToInt(finalValue * (1 + (statMod.value / 100)));
                    break;
            }
        }
        if (isFirstMultiplicative == false)
        {
            finalValue = Mathf.RoundToInt(finalValue * multiplier);
        }
        DEBUGVALUE = finalValue;
        return finalValue;
    }

    public void AddModifier(StatModifier modifier)
    {
        statModifiers.Add(modifier);
        statModifiers.Sort(CompareModifierOrder);
    }

    public void RemoveModifier(StatModifier modifier)
    {
        statModifiers.Remove(modifier);
    }

    public bool HaveModifier(StatModifier mod)
    {
        return statModifiers.Contains(mod);
    }

    public int CompareModifierOrder(StatModifier a, StatModifier b)
    {
        if (a.type < b.type)
            return -1;
        else if (a.type > b.type)
            return 1;
        return 0; // if (a.Order == b.Order)
    }
}

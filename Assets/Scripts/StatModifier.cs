using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GGGeralt.Stats
{
    public enum modType
    {
        Flat,
        PrecentageAdditive,
        PrecentageMultiplicative,
    }
    [Serializable]
    public class StatModifier
    {
        public int value;
        public modType type;

        public StatModifier(int value, modType type)
        {
            this.value = value;
            this.type = type;
        }
    }
}
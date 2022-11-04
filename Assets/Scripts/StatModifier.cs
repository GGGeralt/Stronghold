using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GGGeralt.Stats
{
    public enum modType
    {
        Flat,
        Multiplicative,
    }
    [Serializable]
    public class StatModifier
    {
        public float value;
        public modType type;

        public StatModifier(float value, modType type)
        {
            this.value = value;
            this.type = type;
        }
    }
}
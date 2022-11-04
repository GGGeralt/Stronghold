using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGGeralt.Stats
{
    [Serializable]
    public class ChangeableStat
    {
        public Stat maxValue;
        public float currentValue;

        public void Decrease(float value)
        {
            currentValue = Mathf.Clamp(currentValue - value, 0, maxValue.Value);
        }

        public void Increase(float value)
        {
            currentValue = Mathf.Clamp(currentValue + value, 0, maxValue.Value);
        }

        public void Reset()
        {
            currentValue = maxValue.Value;
        }
    }
}
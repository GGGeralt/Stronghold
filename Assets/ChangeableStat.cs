using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGGeralt.Stats
{
    [Serializable]
    public class ChangeableStat
    {
        public int maxValue;
        public int currentValue;

        public void Decrease(int value)
        {
            currentValue = Mathf.Clamp(currentValue - value, 0, maxValue);
        }

        public void Increase(int value)
        {
            currentValue = Mathf.Clamp(currentValue + value, 0, maxValue);
        }

        public void Reset()
        {
            currentValue = maxValue;
        }
    }
}
using GGGeralt.Creatures;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GGGeralt.Managers
{
    public class BarsManager : MonoBehaviour
    {
        [SerializeField] Slider healthSlider;
        [SerializeField] TextMeshProUGUI healthText;
        [SerializeField] Slider manaSlider;
        private CreatureBase creature;

        public void SetManager(CreatureBase thing)
        {
            creature = thing;
            ResetBars();
        }

        private void ResetBars()
        {
            healthSlider.maxValue = creature.health.maxValue.Value;
            creature.health.Reset();
            UpdateBars();
        }
        public void UpdateBars()
        {
            healthSlider.value = creature.health.currentValue;
            healthText.text = $"{creature.health.currentValue}/{creature.health.maxValue.Value}";
        }
    }
}
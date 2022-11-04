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
        private Thing thing;

        public void SetManager(Thing thing)
        {
            this.thing = thing;
            ResetBars();
        }

        private void ResetBars()
        {
            healthSlider.maxValue = thing.health.maxValue.Value;
            thing.health.Reset();
            UpdateBars();
        }
        public void UpdateBars()
        {
            healthSlider.value = thing.health.currentValue;
            healthText.text = $"{thing.health.currentValue}/{thing.health.maxValue.Value}";
        }
    }
}
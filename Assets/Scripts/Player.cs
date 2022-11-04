using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGGeralt.Creatures
{
    public class Player : CreatureBase
    {
        public static Player Instance { get; private set; }


        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(Instance);
            }
            else
            {
                Instance = this;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                TakeDamage(10);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Heal(10);
            }
        }

    }
}
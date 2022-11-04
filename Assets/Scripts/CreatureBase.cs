using GGGeralt.Managers;
using GGGeralt.Stats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGGeralt.Creatures
{
    [RequireComponent(typeof(BarsManager))]
    public class CreatureBase : Thing
    {
        [Header("Creature Stats")]
        public int speed = 5;

      
    }
}
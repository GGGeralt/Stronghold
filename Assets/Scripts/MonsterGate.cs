using GGGeralt.Stats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGate : MonoBehaviour
{
    [SerializeField] ChangeableStat mana;
    [SerializeField] Stat manaPerSecond;

    private void Update()
    {
        mana.Increase(manaPerSecond.Value * Time.deltaTime);
    }

}

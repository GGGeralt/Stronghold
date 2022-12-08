using GGGeralt.Stats;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonsterGate : MonoBehaviour
{
    [Header("Special building things")]
    [SerializeField] ChangeableStat mana;
    [SerializeField] Stat manaPerSecond;


    [SerializeField] Creature[] creaturesToSpawn;
    [SerializeField] Transform world;

    [SerializeField] UnityEvent levelUp;
    [SerializeField] int waveTimer = 5;

    private void Start()
    {
        StartCoroutine("SpawnWave");
    }

    private void FixedUpdate()
    {
        mana.Increase(manaPerSecond.Value * Time.fixedDeltaTime);
    }

    IEnumerator SpawnWave()
    {
        Creature creature;
        while (true)
        {
            yield return new WaitForSeconds(waveTimer);
            if (UnityEngine.Random.Range(0, 2) % 2 == 0)
            {
                creature = creaturesToSpawn[0];
            }
            else
            {
                creature = creaturesToSpawn[1];
            }
            Instantiate(creature, transform.position, Quaternion.identity, world);

            Debug.Log("EMENIES SPAWNED");
        }
    }
}

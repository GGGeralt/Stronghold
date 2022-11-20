using GGGeralt.Stats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonsterGate : MonoBehaviour
{
    [Header("Special building things")]
    [SerializeField] ChangeableStat mana;
    [SerializeField] Stat manaPerSecond;


    [SerializeField] Creature enemy;
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
        while (true)
        {
            yield return new WaitForSeconds(waveTimer);

            Instantiate(enemy, transform.position, Quaternion.identity, world);

            Debug.Log("EMENIES SPAWNED");
        }
    }
}

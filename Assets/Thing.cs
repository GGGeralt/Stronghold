using GGGeralt.Managers;
using GGGeralt.Stats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thing : MonoBehaviour
{
    [Header("All things stats")]
    public ChangeableStat health;

    [Space]

    [Header("All things managers")]
    public BarsManager barsManager;

    private void Awake()
    {
        barsManager = GetComponent<BarsManager>();
        health.Reset();
    }
    private void Start()
    {
        barsManager.SetManager(this);
    }

    public void TakeDamage(int value)
    {
        health.Decrease(value);
        barsManager.UpdateBars();
    }
    public void Heal(int value)
    {
        health.Increase(value);
        barsManager.UpdateBars();
    }

}

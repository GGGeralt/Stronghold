using GGGeralt.Creatures;
using GGGeralt.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BarsManager))]
public class NexusCrystal : MonoBehaviour
{
    public static NexusCrystal Instance { get; private set; }

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
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string Name;
    public int Health;
    public int Energy;
    public int Gem;

    public event Action OnGemChanged;
    public event Action OnEnergyChanged;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
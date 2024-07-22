using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    public string Name;
    public int Health;
    public int Energy;
    public int Gem;
    public int Damage;

    public event Action OnGemChanged;
    public event Action OnEnergyChanged;

    /**
     * 몬스터 공격
     */
    public void Attack(Monster fieldMonster)
    {
        fieldMonster.TakeDamage(Damage, transform);
        Debug.Log($"{fieldMonster.Name}을 공격했습니다 !");

        if (fieldMonster.IsDead())
        {
            int reward = Random.Range(100, 501);
            GainReward(reward);
        }

    }

    private void GainReward(int reward)
    {
        Gem += reward;

        if (OnGemChanged != null)
        {
            OnGemChanged();
        }
        Debug.Log($"{reward}원을 얻었습니다.");
    }


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
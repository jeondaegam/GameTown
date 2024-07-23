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

        // 몬스터가 죽었을 때 보상은 던전에서 관리 
        //if (fieldMonster.IsDead())
        //{
        //    int reward = Random.Range(100, 501);
        //    GainReward(reward);
        //}

    }

    public void GainReward(int reward)
    {
        Gem += reward;

        if (OnGemChanged != null)
        {
            OnGemChanged();
        }
        Debug.Log($"Gem {reward}개를 얻었습니다.");
    }

    // TODO 
    internal void AddItem()
    {
        throw new NotImplementedException();
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
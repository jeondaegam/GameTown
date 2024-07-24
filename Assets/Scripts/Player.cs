using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    public string Name;
    // 최대 체력 
    public int MaxHealth;
    // 현재 남은 체력
    [HideInInspector] // 현재 남은 체력 
    public int CurHealth;
    public int Energy;
    public int Gem;
    public int Damage;

    public event Action OnGemChanged;
    public event Action OnEnergyChanged;
    public event Action OnHealtyChanged;

    private void Start()
    {
        CurHealth = MaxHealth;
    }


    /**
     * 몬스터 공격
     */
    public void Attack(Monster fieldMonster)
    {
        fieldMonster.TakeDamage(Damage, transform);
        Debug.Log($"{fieldMonster.Name}을 공격했습니다 !");

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
    public void AddItem(Item item)
    {
        Debug.Log($"Add Item : 구현 필요 => {item.Name} 획득");
    }

    /**
     * 공격을 받는다 
     */
    public void TakeDamage(int damage)
    {
        CurHealth -= damage;
        if (IsDead())
        {
            CurHealth = 0;
            Debug.Log("의식을 잃고 쓰러집니다 .");
        }
        if (OnHealtyChanged != null)
        {
            OnHealtyChanged();
        }

    }

    private bool IsDead()
    {
        return CurHealth <= 0;
    }


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
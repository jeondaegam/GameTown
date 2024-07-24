using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Monster : MonoBehaviour
{

    public string Name;
    // 최대 체력
    public int MaxHealth;
    [HideInInspector] // 현재 남은 체력 
    public int CurHealth;
    public int Damage;
    public Item[] _items;
    public event Action OnHealtyChanged;

    //private int MaxItemQuantity;

    public event Action OnMonsterDeath;


    private void Start()
    {
        CurHealth = MaxHealth;
    }

    /**
     * 사망여부 체크 
     */
    public bool IsDead()
    {
        return CurHealth <= 0;
    }

    /**
     * 공격을 받는다
     */
    public void TakeDamage(int damage, Transform transform)
    {
        CurHealth -= damage;

        if (IsDead())
        {
            CurHealth = 0;
            Debug.Log($"<{Name}>이 죽었습니다 .");
            // 사망 이벤트 호출
            if (OnMonsterDeath != null)
            {
                OnMonsterDeath();
            }
        }
        ShowStats();

        // 체력 변경 이벤트 호출 
        if (OnHealtyChanged != null)
        {
            OnHealtyChanged();
        }

    }

    /**
     * 스탯을 보여준다 
     */
    public void ShowStats()
    {
        Debug.Log($"<{Name}> \n체력:{CurHealth} / 공격력:{Damage}");
    }

    internal void DropItem()
    {
        int random = Random.Range(0, _items.Length);
        Item droppedItem = Instantiate(_items[random], transform.position, _items[random].transform.rotation);
    }

    /**
     * 공격한다
     */
    internal void Attack(Player player)
    {
        player.TakeDamage(Damage);
        Debug.Log($"{Name}이 공격했습니다 !");
    }
}
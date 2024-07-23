using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Monster : MonoBehaviour
{

    public string Name;
    public int Health;
    public int Damage;
    public Item[] _items;

    //private int MaxItemQuantity;

    public event Action OnMonsterDeath;

    /**
     * 사망여부 체크 
     */
    public bool IsDead()
    {
        return Health <= 0;
    }

    /**
     * 공격을 받는다
     */
    public void TakeDamage(int damage, Transform transform)
    {
        Health -= damage;

        // 몬스터 체력이 0이되면 사망 처리
        if (IsDead())
        {
            Health = 0;
            Debug.Log($"<{Name}>이 죽었습니다 .");
            if (OnMonsterDeath != null)
            {
                OnMonsterDeath();
            }
        }
        ShowStats();
    }

    /**
     * 스탯을 보여준다 
     */
    public void ShowStats()
    {
        Debug.Log($"<{Name}> \n체력:{Health} / 공격력:{Damage}");
    }

    internal void DropItem()
    {
        int random = Random.Range(0, _items.Length);
        Item droppedItem = Instantiate(_items[random], transform.position, _items[random].transform.rotation);
    }
}
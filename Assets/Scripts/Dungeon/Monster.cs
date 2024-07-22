using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    public string Name;
    public int Health;
    public int Damage;

    /**
     * 사망여부 체크 
     * Health가 <=0이면 사망처리
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

        if (Health <= 0)
        {
            Health = 0;
            Debug.Log($"<{Name}>이 죽었습니다 .");
            // DropItem(destination);
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


}
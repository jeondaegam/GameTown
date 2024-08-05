using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    // 체력바 슬라이더 
    public Slider _healthBer;


    public void UpdateUI(float curHealth, float maxHealth)
    {
        _healthBer.value = curHealth / maxHealth;

        // 체력이 0이되면 비활성화
        if (curHealth <= 0)
        {
            _healthBer.gameObject.SetActive(false);
        }
    }

}


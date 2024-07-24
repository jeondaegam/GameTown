using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    // 체력바 슬라이더 
    public Slider _healthBer;

    internal void UpdateUI(float curHealth, float maxHealth)
    {
        _healthBer.value = curHealth / maxHealth;
    }

}

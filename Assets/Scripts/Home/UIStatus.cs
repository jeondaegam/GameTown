using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIStatus : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI _text;

    public void UpdateUI(string message)
    {
        _text.text = message;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOneMinusButtons : MonoBehaviour
{

    public Button _rButton;
    public Button _pButton;
    public Button _sButton;

    public GameOneMinus _gameOneMinus;

    private enum RPS
    {
        Rock = 1,
        Paper = 2,
        Scissors = 0
    }

    // Start is called before the first frame update
    void Start()
    {
        _rButton.onClick.AddListener(HandleRButtonClicked);
        _pButton.onClick.AddListener(HandlePButtonClicked);
        _sButton.onClick.AddListener(HandleSButtonClicked);
    }

    private void HandleSButtonClicked()
    {
        _gameOneMinus.StartBattle((int)RPS.Scissors);
    }

    private void HandlePButtonClicked()
    {
        _gameOneMinus.StartBattle((int)RPS.Paper);
    }

    private void HandleRButtonClicked()
    {
        _gameOneMinus.StartBattle((int)RPS.Rock);
    }
}

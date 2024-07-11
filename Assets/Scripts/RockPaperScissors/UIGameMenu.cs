using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameMenu : MonoBehaviour
{
    public Button[] MiniGamesButtons;

    public Arcade Arcade;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < MiniGamesButtons.Length; i++)
        {
            int miniGameNum = i;
            MiniGamesButtons[i].onClick.AddListener(() => HandleMiniGameButtonClicked(miniGameNum));
        }
    }

    private void HandleMiniGameButtonClicked(int miniGameNum)
    {
        Debug.Log(miniGameNum + "번 게임 선택 ");
        Arcade.PlayMiniGame(miniGameNum);
    }

}

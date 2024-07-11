using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMjpButtons : MonoBehaviour
{

    public Button RButton;
    public Button PButton;
    public Button SButton;

    public GameMukjipa GameMukjipa;


    // TODO - MAnager 같은데 옮겨서 static으로 사용하면 좋을듯 
    public enum RPS
    {
        Rock = 1,
        Paper = 2,
        Scissors = 0
    }


    // Start is called before the first frame update
    void Start()
    {
        SButton.onClick.AddListener(HandleScissorsBtnClicked);
        RButton.onClick.AddListener(HandleRockBtnClicked);
        PButton.onClick.AddListener(HandlePaperBtnClicked);
    }

    private void HandleScissorsBtnClicked()
    {
        GameMukjipa.StartBattle((int)RPS.Scissors);
    }

    private void HandleRockBtnClicked()
    {
        GameMukjipa.StartBattle((int)RPS.Rock);
    }

    private void HandlePaperBtnClicked()
    {
        GameMukjipa.StartBattle((int)RPS.Paper);
    }


}

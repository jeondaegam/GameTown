using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPSGameManager : MonoBehaviour
{

    // 게임 선택 화면 On/Off
    // 선택한 게임 플레이
    // 선택한 게임 화면 On/Off

    // 게임 메뉴 선택 UI
    public GameObject UIGameMenu;


    // Start is called before the first frame update
    void Start()
    {
        UIGameMenu.SetActive(true);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

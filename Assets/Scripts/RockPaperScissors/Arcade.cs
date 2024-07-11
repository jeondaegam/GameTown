using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arcade : MonoBehaviour
{

    public UIGameMenu UIGameMenu;
   

    [SerializeField]
    private GameObject[] _miniGames; // 각 게임 UI 오브젝트를 들고있는 건가 ? 
    // 0==RPS, 1==MJP, 2==OneMinus

    public void PlayMiniGame(int miniGameNum)
    {
        if (miniGameNum <= -1 || miniGameNum > _miniGames.Length)
        {
            Debug.Log("게임 번호를 다시 선택하세요.");
        }

        // Inspector On
        _miniGames[miniGameNum].SetActive(true);
        // Game Menu Off
        UIGameMenu.gameObject.SetActive(false);
    }

}

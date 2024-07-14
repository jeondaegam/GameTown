using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHome : MonoBehaviour
{

    public Button _dungeonButton;
    public Button _gameRoomButton;
    public Button _restaurantButton;
    public Button _collegeButton;

    public UIStatus MoneyBar;
    public UIStatus EnergyBar;

    // Start is called before the first frame update
    void Start()
    {

        // TODO 
        // GameManager에서 Player의 OnMoneyChanged 이벤트가 발생하면 Player_UpdateMoney 리스너 메서드를 실행한다 
        //GameManager.Instance.Player.OnMoneyChanged += UpdatePlayerMoney;
        //GameManager.Instance.Player.OnEnergyChanged += UpdatePlayerEnergy;

        // 버튼 클릭 이벤트가 발생하면  소괄호 안의 메서드가 호출된다
        _dungeonButton.onClick.AddListener(HandleDungeonButtonClicked);
        _gameRoomButton.onClick.AddListener(HandleGameRoomButtonClicked);
        _restaurantButton.onClick.AddListener(HandleRestaurantButtonClicked);
        _collegeButton.onClick.AddListener(HandleCollegeButtonClicked);
    }

    private void UpdatePlayerMoney()
    {
        //MoneyBar.UpdateUI(GameManager.Instance.Player.Money.ToString());
    }

    private void UpdatePlayerEnergy()
    {
        //EnergyBar.UpdateUI(GameManager.Instance.Player.Energy.ToString());
    }

    private void HandleCollegeButtonClicked()
    {
        Debug.Log("Go College");
    }

    private void HandleRestaurantButtonClicked()
    {
        Debug.Log("Go Restaurant");
    }

    private void HandleGameRoomButtonClicked()
    {
        Debug.Log("Go GameRoom");
    }

    private void HandleDungeonButtonClicked()
    {
        Debug.Log("Go Dungeon");
        //GameManager.Instance.씬 로드 
    }
}

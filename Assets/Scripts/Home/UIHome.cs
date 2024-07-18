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

    public UIStatus GemBar;
    public UIStatus EnergyBar;

    // Start is called before the first frame update
    void Start()
    {
        UpdatePlayerGem();
        UpdatePlayerEnergy();
        // player에서 OnMoneyChanged 이벤트 액션이 발생하면 리스너가 UpdatePlayerGem 메서드를 실행한다 
        GameManager.Instance._player.OnGemChanged += UpdatePlayerGem;
        GameManager.Instance._player.OnEnergyChanged += UpdatePlayerEnergy;

        // 버튼 클릭 이벤트가 발생하면  소괄호 안의 메서드가 호출된다
        _dungeonButton.onClick.AddListener(HandleDungeonButtonClicked);
        _gameRoomButton.onClick.AddListener(HandleGameRoomButtonClicked);
        _restaurantButton.onClick.AddListener(HandleRestaurantButtonClicked);
        _collegeButton.onClick.AddListener(HandleCollegeButtonClicked);
    }

    private void UpdatePlayerGem()
    {
        string formattedGem = GameManager.Instance._player.Gem.ToString("#,###");
        GemBar.UpdateUI(formattedGem);
    }

    private void UpdatePlayerEnergy()
    {
        EnergyBar.UpdateUI($"{GameManager.Instance._player.Energy}/100");
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

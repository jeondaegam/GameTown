using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDungeon : MonoBehaviour
{
    // Left Buttons 
    public Button _spawnMonsterBtn;
    public Button _attackBtn;
    public Button _runBtn;
    public Button _catchBtn;

    // Right Buttons
    public Button _inventoryBtn;
    public Button _shopBtn;
    public Button _goHomeBtn;

    public Dungeon _dungeon;

    public UIStatus _enegerBar;
    public UIStatus _gemBar;


    // Start is called before the first frame update
    void Start()
    {

        UpdatePlaeyrEnergey();
        UpdatePlayerGem();

        _spawnMonsterBtn.onClick.AddListener(SpawnMonsterBtnClicked);
        _attackBtn.onClick.AddListener(AttackMonsterCBtnClicked);
        _runBtn.onClick.AddListener(RunAwayFromMonsterBtnClicked);
        _catchBtn.onClick.AddListener(CatchMonsterBtnClicked);

        _inventoryBtn.onClick.AddListener(InventoryBtnClicked);
        _shopBtn.onClick.AddListener(ShopBtnClicked);
        _goHomeBtn.onClick.AddListener(GoHomeBtnClicked);
    }

    private void UpdatePlaeyrEnergey()
    {
        _enegerBar.UpdateUI($"{GameManager.Instance._player.Energy}/100");
    }

    private void UpdatePlayerGem()
    {
        string formattedGem = GameManager.Instance._player.Gem.ToString("#,###");
        _gemBar.UpdateUI(formattedGem);
    }


    private void CatchMonsterBtnClicked()
    {
        Debug.Log("Catch Monster");
    }

    private void RunAwayFromMonsterBtnClicked()
    {
        Debug.Log("RunAway");
    }

    private void AttackMonsterCBtnClicked()
    {
        Debug.Log("Attack");
    }

    private void SpawnMonsterBtnClicked()
    {
        //_dungeon.SpawnMonster();
    }

    private void GoHomeBtnClicked()
    {
        Debug.Log("Go Home");
    }

    private void ShopBtnClicked()
    {
        Debug.Log("Go Shop");
    }

    private void InventoryBtnClicked()
    {
        Debug.Log("Go Inventory");
    }


}

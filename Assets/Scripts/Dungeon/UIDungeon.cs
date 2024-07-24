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

    public UIHealthBar _playerHealthBar;
    public UIHealthBar _monsterHealthBar;


    // Start is called before the first frame update
    void Start()
    {
        // Player Inspector On
        GameManager.Instance._player.gameObject.SetActive(true);
        _playerHealthBar.gameObject.SetActive(true);

        // 상태바 UI 업데이트
        UpdatePlaeyrEnergey();
        UpdatePlayerGem();

        // Left Buttons
        _spawnMonsterBtn.onClick.AddListener(SpawnMonsterBtnClicked);
        _attackBtn.onClick.AddListener(AttackMonsterCBtnClicked);
        _runBtn.onClick.AddListener(RunAwayFromMonsterBtnClicked);
        _catchBtn.onClick.AddListener(CatchMonsterBtnClicked);

        // Right Button
        _inventoryBtn.onClick.AddListener(InventoryBtnClicked);
        _shopBtn.onClick.AddListener(ShopBtnClicked);
        _goHomeBtn.onClick.AddListener(GoHomeBtnClicked);

        // 플레이어 상태바 업데이트 리스너
        GameManager.Instance._player.OnGemChanged += UpdatePlayerGem;
        GameManager.Instance._player.OnEnergyChanged += UpdatePlaeyrEnergey;
        // 플레이어 체력바 업데이트 리스너
        GameManager.Instance._player.OnHealtyChanged += UpdatePlayerHealth;



    }

    /**
     * 몬스터 체력바 업데이트 
     */
    private void UpdateMonsterHealth()
    {
        _monsterHealthBar.UpdateUI(
            _dungeon._fieldMonster.CurHealth,
            _dungeon._fieldMonster.MaxHealth);
    }

    /**
     * 플레이어 체력바 업데이트 
     */
    private void UpdatePlayerHealth()
    {
        _playerHealthBar.UpdateUI(
            GameManager.Instance._player.CurHealth,
            GameManager.Instance._player.MaxHealth);
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


    // Spawn a monster
    private void SpawnMonsterBtnClicked()
    {
        _dungeon.SpawnMonsterOnField();
        _monsterHealthBar.gameObject.SetActive(true);

        // 몬스터 체력바 변경 이벤트 리스너
        _dungeon._fieldMonster.OnHealtyChanged += UpdateMonsterHealth;
        // 몬스터 사망 이벤트 리스너
        _dungeon._fieldMonster.OnMonsterDeath += OnMonsterDestroyed;
    }

    /**
     * Monster 이벤트 리스너 해제
     * 작동시점: 몬스터 사망 
     */
    private void OnMonsterDestroyed()
    {
        // 등록된 이벤트 리스너를 해제
        _dungeon._fieldMonster.OnHealtyChanged -= UpdateMonsterHealth;
        _dungeon._fieldMonster.OnMonsterDeath -= OnMonsterDestroyed;
        _monsterHealthBar.gameObject.SetActive(false);
    }


    // Attack
    private void AttackMonsterCBtnClicked()
    {
        Debug.Log("Attack");
        _dungeon.AttackToMonster();
        // 공격은 플레이어가 하지만 , 공격에 대한 룰을 던전이 관리해야함
        // 데미지가 몇이고 몬스터의 체력이 얼마나 달았는지 
    }

    // Catch
    private void CatchMonsterBtnClicked()
    {
        Debug.Log("Catch Monster");
    }

    // Run 
    private void RunAwayFromMonsterBtnClicked()
    {
        Debug.Log("RunAway");
        _dungeon.Runaway();
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

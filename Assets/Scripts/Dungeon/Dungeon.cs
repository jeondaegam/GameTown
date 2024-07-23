using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Dungeon : MonoBehaviour
{
    [SerializeField]
    private Monster[] _monsters;

    [SerializeField]
    private Transform _monsterSpawnPoint;

    [SerializeField]
    private Item _reward;
    private int MaxReward = 500;

    private Player Player;
    private Monster _fieldMonster;


    void Start()
    {
        // 레퍼런싱 안하는 방법 
        Player = GameManager.Instance._player;
        //_fieldMonster.OnMonsterDeath += DropReward; //monster에 값이 없으면 안되나  
    }

    private void DropReward()
    {
        int gemCnt = Random.Range(0, MaxReward); // TODO 499까지인지 500까지 인지 ? +1해주기  
        Item gem = Instantiate(_reward, _fieldMonster.transform.position, _reward.transform.rotation);
        Player.GainReward(gemCnt);
    }


    /**
     * 필드에 몬스터를 소환한다
     */
    public void SpawnMonsterOnField()
    {
        int random = Random.Range(0, _monsters.Length);
        _fieldMonster = SpawnMonster(random);
        _fieldMonster.OnMonsterDeath += DropReward; // 몬스터 소환 후 이벤트 리스너 등록 
        Debug.Log($"<{_fieldMonster.Name}>이 나타났습니다 - !");
    }

    /**
     * 몬스터 인스턴스 생성
     */
    private Monster SpawnMonster(int index)
    {
        return Instantiate(_monsters[index],
            _monsterSpawnPoint.position,
            _monsters[index].transform.rotation);
    }

    public void StartBattle()
    {
        //int random = Random.Range(0, _monsters.Length);
        //_fieldMonster = SpawnMonster(random);
    }


    // Update is called once per frame
    void Update()
    {

    }

    /**
     * 몬스터를 공격한다 
     */
    public void Attack()
    {
        if (_fieldMonster != null)
        {
            Player.Attack(_fieldMonster);

            // 몬스터가 들고있는 아이템을 드랍
            if (_fieldMonster.IsDead())
            {
                _fieldMonster.DropItem();
                Destroy(_fieldMonster.gameObject);
            }
        }

    }

    public void Runaway()
    {
        if(_fieldMonster != null)
        {
            Debug.Log($"<{_fieldMonster.Name}>으로부터 도망칩니다 -");
            Destroy(_fieldMonster.gameObject);
        } else
        {
            Debug.Log("아무것도 없습니다. ");
        }
    }
}

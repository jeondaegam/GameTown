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

    private Player Player;
    private Monster _fieldMonster;


    void Start()
    {
        // 레퍼런싱 안하는 방법 
        Player = GameManager.Instance._player;
    }


    /**
     * 필드에 몬스터를 소환한다
     */
    public void SpawnMonster()
    {
        int random = Random.Range(0, _monsters.Length);
        _fieldMonster = SpawnMonsterByIndex(random);
        Debug.Log($"<{_fieldMonster.Name}>이 나타났습니다 - !");
    }

    /**
     * 몬스터 인스턴스 생성
     */
    private Monster SpawnMonsterByIndex(int index)
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
     * 플레이어가 몬스터를 공격
     */
    public void Attack()
    {
        if (_fieldMonster != null)
        {
            Player.Attack(_fieldMonster);
            if (_fieldMonster.IsDead())
            {
                // Drop Item  TODO
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

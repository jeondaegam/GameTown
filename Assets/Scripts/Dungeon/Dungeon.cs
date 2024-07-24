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
    public Monster _fieldMonster; // TODO public으로 했을 때 레퍼런싱 안해도 돌아가나 ? 안되면 Internal

    public enum BattleState
    {
        MonsterTurn,
        PlayerTurn,
    }

    public BattleState state;



    void Start()
    {
        // 레퍼런싱 안하는 방법 
        Player = GameManager.Instance._player;
    }

    private void DropReward()
    {
        int gemCnt = Random.Range(0, MaxReward+1);
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
        Debug.Log($"<{_fieldMonster.Name}>이 나타났습니다 - !");

        // 몬스터 소환 후 이벤트 리스너 등록 
        _fieldMonster.OnMonsterDeath += DropReward;
        _fieldMonster.OnMonsterDeath += OnMonsterDestroyed;

        state = BattleState.PlayerTurn;
    }


    /**
     * 몬스터가 죽으면 이벤트 리스너를 해제한다 
     */
    private void OnMonsterDestroyed()
    {
        _fieldMonster.OnMonsterDeath -= DropReward;
        _fieldMonster.OnMonsterDeath -= OnMonsterDestroyed;
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
        //IsPlayerTurn = true;
    }


    // Update is called once per frame
    void Update()
    {

    }

    /**
     * 몬스터를 공격한다 
     */
    public void AttackToMonster()
    {
        if (_fieldMonster != null)
        {
            Player.Attack(_fieldMonster);

            if (_fieldMonster.IsDead())
            {
                // 몬스터의 아이템을 드랍
                _fieldMonster.DropItem();
                Destroy(_fieldMonster.gameObject);
            }
            else
            {
                // 몬스터에게 턴을 넘긴다
                StartCoroutine(MonsterTurn());
            }
        }

    }

    /**
     * 턴을 받고 1.5초 뒤에 플레이어를 공격한다 
     */
    private IEnumerator MonsterTurn()
    {
        yield return new WaitForSeconds(1.5f);

        state = BattleState.MonsterTurn;
        AttackToPlayer();
        PlayerTurn();
    }

    private void PlayerTurn()
    {
        state = BattleState.PlayerTurn;
        // TODO - 공격 버튼 활성화
        // TODO - MonsterTurn()과 동일하게 변경 필요 
    }

    /**
     * 플레이어를 공격한다 
     */
    public void AttackToPlayer()
    {
        _fieldMonster.Attack(Player);
    }


    /**
     * 몬스터에게서 도망친다 
     */
    public void Runaway()
    {
        if (_fieldMonster != null)
        {
            Debug.Log($"<{_fieldMonster.Name}>으로부터 도망칩니다 -");
            Destroy(_fieldMonster.gameObject);
        }
        else
        {
            Debug.Log("아무것도 없습니다. ");
        }
    }
}

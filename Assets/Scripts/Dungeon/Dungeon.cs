using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon : MonoBehaviour
{
    [SerializeField]
    private Monster[] _monsters;

    [SerializeField]
    private Transform _monsterSpawnPoint;


    private Monster FieldMonster;


    //public Monster SpawnMonster(int index)
    //{
    //    GameObject gameObj = Instantiate(Monsters[index], MonsterPoint.position, MonsterPoint.rotation);
    //    Monster monster = gameObj.GetComponent<Monster>(); // ?
    //    //monster.Text.text = $" {monster.GetName()} -\nHP:{monster.GetHealth()}";
    //    return monster;
    //}


    //public void SpawnMonster()
    //{
    //    Debug.Log("Dungeon.SpawnMonster");
    //    int random = Random.Range(0, _monsters.Length);
    //    Instantiate(_monsters[random], _monsterSpawnPoint.position, Quaternion.identity);
    //}

    public Monster SpawnMonster(int index)
    {
        Monster monster = Instantiate(_monsters[index], _monsterSpawnPoint.position, Quaternion.identity);
        Debug.Log($"{monster.name}이 나타났습니다 - !");
        return monster;
    }

    public void StartBattle()
    {
        int random = Random.Range(0, _monsters.Length);
        FieldMonster = SpawnMonster(random);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // 이름
    public string Name;
    // 설명 
    public string Description;

    // 공격력 
    public int AttackPower;
    // 방어력 
    public int DefensePower;
    // 회복력
    public int Recovery;

    // 플레이어의 위치 
    private Transform PlayerPosition;
    // 이동속도
    [SerializeField]
    private float MoveSpeed = 7f;



    /**
     * 플레이어에게 이동
     */
    internal void MoveToPlayer()
    {
        if (PlayerPosition != null)
        {
            Vector3 moveDirection = (PlayerPosition.position - transform.position).normalized;
            transform.position += moveDirection * MoveSpeed * Time.deltaTime;
            // 방향 벡터에 속도를 붙여주고, 프레임마다 일정한 속도로 움직이도록 Time.deltaTime을 붙여줌

            if (Vector3.Distance(transform.position, PlayerPosition.position) < .5f)
            {
                Debug.Log($"<{Name}>을 획득했습니다."); // TODO 이거 player쪽으로 옮겨야할듯
                Destroy(gameObject);

                // TODO 
                GameManager.Instance._player.AddItem(this);
            }

        }

    }


    void Start()
    {
        // TODO 아이템 관련 정보 db로 관리했으면

        // 인스턴스가 생성되면 목적지로 이동한다
        PlayerPosition = GameManager.Instance._player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
    }


}

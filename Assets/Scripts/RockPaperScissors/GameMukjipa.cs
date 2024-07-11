using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class GameMukjipa : MonoBehaviour
{
    // 게임 화면을 구성하고 게임 플레이 기능 수행

    [SerializeField]
    private SpriteRenderer _mySpriteRenderer; // 그려주는 애(=컴포넌트)

    [SerializeField]
    private SpriteRenderer _aiSpritesRenderer;

    [SerializeField]
    private Sprite[] _rpsSprites; // 그릴 때 사용할 이미지 

    public UIMjpButtons UIMukjipaButtons;

    // ? TODO
    public float RandomSpriteDelay = 1f;

    public float RandomInterval = 0.5f;

    // Coroutine을 스탑하기 위해서 변수에 담아두는 것 같음 
    private Coroutine _routine;


    // 0==ai, 1==user
    private int attackTurn = -1;


    private void OnEnable()
    {
        UIMukjipaButtons.gameObject.SetActive(true);
        _routine = StartCoroutine(RandomSpriteRoutine(true));

    }


    public void StartBattle(int myCard)
    {
        string[] items = { "찌", "묵", "빠" };

        // Coroutine을 멈춘다 
        StopCoroutine(_routine);

        Debug.Log(items[myCard] + "를 냈습니다 . ");

        //ai 카드 선택 
        int aiCard = new Random().Next(0, 3);

        // 선택한 카드 화면에 그리기
        UpdateSprites(myCard, aiCard);

        if (aiCard == (myCard + 1) % 3)
        {
            Debug.Log("You Lose. ");
            Debug.Log("Ai turn, wating. . .");
            // 턴 변경 => Ai
            attackTurn = 0;
        }
        else if (aiCard == myCard)
        {
            if (attackTurn == -1)
            {
                Debug.Log("It's a draw !");
            }
            // 묵찌빠 게임중에는 비길경우, 턴을 갖고잇는 유저가 이기는거고 턴 변화 없음
            else if (attackTurn == 1)
            {
                Debug.Log("Your turn . .");
            } else
            {
                Debug.Log("Ai turn . .");
            }
        }
        else
        {
            Debug.Log("You Win ! ");
            Debug.Log("Your turn .");
            attackTurn = 1;
        }

    }

    // 각자 선택한 카드를 화면에 그림 
    private void UpdateSprites(int myCard, int aiCard)
    {
        _mySpriteRenderer.sprite = _rpsSprites[myCard];
        _aiSpritesRenderer.sprite = _rpsSprites[aiCard];
    }

    private IEnumerator RandomSpriteRoutine(bool delay)
    {
        if (delay)
        {
            yield return new WaitForSeconds(RandomSpriteDelay);
        }

        int myIndex = 0;
        int aiIndex = 0;

        while(true)
        {
            yield return new WaitForSeconds(RandomInterval);
            UpdateSprites(myIndex++, aiIndex++);
            myIndex %= _rpsSprites.Length;
            aiIndex %= _rpsSprites.Length;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class GameRPS : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _mySpriteRenderer;

    [SerializeField]
    private SpriteRenderer _aiSpriteRenderer;


    [SerializeField]
    // 화면에 카드 이미지 업데이트를 위해 묵찌빠 sprite image를 모두 들고 있어야 함 
    private Sprite[] _rpsSprites;

    public UIRpsButtons UIRpsButtons;


    public float RandomInterval;

    // 이미지 변경 시간 간격 
    public float RandomSpriteDelay;

    private Coroutine _routine;


    // Runtime일 때 Inspector가 On으로 체크될 때마다 호출된다
    private void OnEnable()
    {
        UIRpsButtons.gameObject.SetActive(true);

        _routine = StartCoroutine(RandomSpriteRoutine(true));

    }

    /*
     * Siccors == 0 
     * Rock == 1
     * Paper == 2
     */

    public void StartBattle(int myCard)
    {
        StopCoroutine(_routine);
        Debug.Log(myCard + "를 냈습니다.");

        // ai Card 선택 
        int aiCard = new Random().Next(0, 3);
        // 양쪽 카드를 화면에 띄움 
        UpdateSprites(myCard, aiCard);

        // 다시 랜덤 카드 돌리기 
        _routine = StartCoroutine(RandomSpriteRoutine(true));

        // 승부 판결
        if (aiCard == (myCard + 1) % 3)
        {
            Debug.Log("You Lose.");
        }
        else if (myCard == aiCard)
        {
            Debug.Log("It's a Draw. ");
        }
        else
        {
            Debug.Log("You Win. ");
        }
    }


    // 이 함수 이해 안됨 (동기 , 비동기 sync, async)
    private IEnumerator RandomSpriteRoutine(bool delay)
    {
        if (delay)
        {
            yield return new WaitForSeconds(RandomSpriteDelay);
        }

        int myIndex = 0;
        int aiIndex = 0;

        while (true)
        {
            yield return new WaitForSeconds(RandomInterval);
            UpdateSprites(myIndex++, aiIndex++);

            myIndex %= _rpsSprites.Length; // _rpsSprites.Length == 3
            aiIndex %= _rpsSprites.Length;
        }

    }

    // 유저가 선택한 카드를 화면에 띄운다 
    public void UpdateSprites(int myCard, int aiCard)
    {
        _mySpriteRenderer.sprite = _rpsSprites[myCard];
        _aiSpriteRenderer.sprite = _rpsSprites[aiCard];
    }


}

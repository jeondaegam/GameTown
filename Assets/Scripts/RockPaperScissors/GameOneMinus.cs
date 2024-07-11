using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class GameOneMinus : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer[] _aiSpriteRenderers;
    [SerializeField]
    private SpriteRenderer[] _mySpriteRenderers;


    public Sprite[] _rpsSprites;

    // Buttons UI On/Off
    public UIOneMinusButtons _uiOneMinusButtons;

    public float _randomInterval;

    public float _randomSpriteDelay;

    private Coroutine _routineOne;
    private Coroutine _routineTwo;


    private int _cardCount;
    private int _MAXCOUNT = 2;

    private string[] rpsStrArr = { "찌", "묵", "빠" };

    private List<int> aiCartList, myCardList; //= new List<int>();

    private enum RPS
    {
        Rock = 1,
        Paper = 2,
        Scissors = 0
    }


    // 유저가 Game OneMinus를 선택 => GameOnminus On  
    private void OnEnable()
    {
        //Button On
        _uiOneMinusButtons.gameObject.SetActive(true);
        // 카드 랜덤 돌리기 On
        _routineOne = StartCoroutine(RandomSpriteRoutine(true, 0));
        _routineTwo = StartCoroutine(RandomSpriteRoutine(true, 1));

        _cardCount = 0;
        aiCartList = new List<int>();
        myCardList = new List<int>();

    }


    private IEnumerator RandomSpriteRoutine(bool delay, int cardSlotNum)
    {
        // randomSpriteDelay만큼 지연을 준다
        if (delay)
        {
            yield return new WaitForSeconds(_randomSpriteDelay);
        }

        int myIndex = 0; // 0 부터 시작 
        int aiIndex = 1; // 1 부터 시작 

        // 그런다음 묵/찌/빠 반복 렌더링
        while (true)
        {
            yield return new WaitForSeconds(_randomInterval);
            UpdateCardSprites(cardSlotNum, myIndex, aiIndex);

            aiIndex++;
            myIndex++;

            myIndex %= _rpsSprites.Length;
            aiIndex %= _rpsSprites.Length;
        }

    }

    // cardSlotNum = 몇번째로 선택한 카드인지 (첫번째 카드 선택이면 0, 두번째 카드 선택이면 1)
    // 0 == 첫째줄 슬롯의 묵찌빠 이미지를 업데이트
    // 1 == 둘째줄 슬롯의 묵찌빠 이미지를 업데이트 
    private void UpdateCardSprites(int cardSlotNum, int myCard, int aiCard)
    {
        _aiSpriteRenderers[cardSlotNum].sprite = _rpsSprites[aiCard];
        _mySpriteRenderers[cardSlotNum].sprite = _rpsSprites[myCard];
    }


    public void StartBattle2(int myCard)
    {
        if (_cardCount == 0)
        {
            // ai : 첫번째 카드 선택
            int aiCard = new Random().Next(0, _rpsSprites.Length);
            // 첫번째 카드 이미지 세팅 
            //UpdateSpritesOne(myCard, aiCard);
            UpdateCardSprites(0, myCard, aiCard);
            // 첫번째 카드 랜덤 돌리기 중지 
            StopCoroutine(_routineOne);
            // 선택한 카드를 리스트에 저장 
            myCardList.Add(myCard);
            aiCartList.Add(aiCard);
            // count++
            _cardCount++;
        }
        else if (_cardCount == 1)
        {
            // ai : 두번째 카드 선택
            int aiCard = new Random().Next(0, _rpsSprites.Length);
            // 두번째 카드 이미지 세팅 
            //UpdateSpritesTwo(myCard, aiCard);
            UpdateCardSprites(1, myCard, aiCard);
            // 두번째 카드 랜덤 돌리기 중지
            StopCoroutine(_routineTwo);
            // 선택한 카드를 내 카드 리스트에 저장 
            myCardList.Add(myCard);
            aiCartList.Add(aiCard);
            // count++
            _cardCount++;
        }
        else if (_cardCount == _MAXCOUNT)
        {
            // 하나를 선택해야함
            if (myCardList.Contains(myCard))
            {
                Debug.Log("my 최종선택 : " + myCard + " , " + rpsStrArr[myCard]);
                int myCardIndex = myCardList.IndexOf(myCard);
                // 선택되지 않은 나머지 카드 지우기 
                _mySpriteRenderers[1 - myCardIndex].enabled = false;

                // ai: 최종선택
                int randomIndex = new Random().Next(0, 2);
                int aiCard = aiCartList[randomIndex];
                Debug.Log("ai 최종선택 : " + aiCard + " , " + rpsStrArr[aiCard]);
                // 선택되지 않은 나머지 카드 지우기
                _aiSpriteRenderers[1 - randomIndex].enabled = false;



                // 승부 판결
                if (aiCard == (myCard + 1) % 3)
                {
                    Debug.Log("You Lose. ");
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
            else
            {
                Debug.Log("다른 카드를 선택하세요. ");
                return;
            }

            // 승부 후 게임 리셋 (다른 카드 선택하세요 다음에 이게 수행되ㄴ ㅏ?)
            ResetGame();
        }

    }

    public void StartBattle(int myCard)
    {
        // 첫 번째, 두 번째 카드 선택 
        if (_cardCount < _MAXCOUNT)
        {
            HandleCardSelection(myCard);
        }
        // 최종 카드 선택
        else
        {
            // _cardCount == MAXCOUNT
            HandleFinalCardSelection(myCard);
            
        }
    }

    // 첫 번째, 두 번째 카드 선택 
    private void HandleCardSelection(int myCard)
    {
        // ai : 카드 선택
        int aiCard = new Random().Next(0, _rpsSprites.Length);
        // 선택한 카드 스프라이트 이미지 업데이트  
        UpdateCardSprites(_cardCount, myCard, aiCard);
        // n번째 카드 랜덤 돌리기 중지 (0==첫째줄 카드 스톱, 1== 둘째줄 카드 스톱) 
        StopCoroutine(_cardCount == 0 ? _routineOne : _routineTwo);
        // 선택한 카드를 리스트에 저장 
        myCardList.Add(myCard);
        aiCartList.Add(aiCard);
        // count++
        _cardCount++;
    }

    // 최종 카드 선택 
    private void HandleFinalCardSelection(int myCard)
    {
        // 둘중 하나를 선택해야함
        if (myCardList.Contains(myCard))
        {
            //Debug.Log("my 최종선택 : " + myCard + " , " + rpsStrArr[myCard]);
            int myCardIndex = myCardList.IndexOf(myCard);

            // 선택되지 않은 나머지 카드 지우기 
            _mySpriteRenderers[1 - myCardIndex].enabled = false;

            // ai: 최종선택
            int randomIndex = new Random().Next(0, 2);
            int aiCard = aiCartList[randomIndex];
            //Debug.Log("ai 최종선택 : " + aiCard + " , " + rpsStrArr[aiCard]);
            // 선택되지 않은 나머지 카드 지우기
            _aiSpriteRenderers[1 - randomIndex].enabled = false;

            CheckWinner(myCard, aiCard);
            ResetGame();
        }
        else
        {
            Debug.Log("다른 카드를 선택하세요. ");
        }
    }


    private void ResetGame()
    {
        _cardCount = 0;
        aiCartList.Clear();
        myCardList.Clear();

        // 모든 카드 슬롯 On
        Invoke("EnableAllObjects", _randomSpriteDelay);
        // 랜덤 돌리기 On 
        _routineOne = StartCoroutine(RandomSpriteRoutine(true, 0));
        _routineTwo = StartCoroutine(RandomSpriteRoutine(true, 1));
    }


    public void EnableAllObjects()
    {
        foreach (SpriteRenderer renderer in _mySpriteRenderers)
        {
            renderer.enabled = true;
        }

        foreach (SpriteRenderer renderer in _aiSpriteRenderers)
        {
            renderer.enabled = true;
        }
    }

    private void CheckWinner(int myCard, int aiCard)
    {
        // 승부 판결
        if (aiCard == (myCard + 1) % 3)
        {
            Debug.Log("You Lose. ");
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
}


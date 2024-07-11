using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRpsButtons : MonoBehaviour
{
    public Button SButton;
    public Button RButton;
    public Button PButton;

    [SerializeField]
    private Text Message;

    public GameRPS GameRPS;

    // TODO - 왜 들고있어야 하는지 모르겠. RPS가 UIButton을 들고있고 UIButton도 RPS를 들고있?
    // 선택된 버튼정보로 RPS를 호출해야해서 ?

    // RPS를 직접 호출하기보다 Static Game Manager를 통해 하면 좋겟다 

    // Start is called before the first frame update
    void Start()
    {
        RButton.onClick.AddListener(HandleRButtonClicked);
        PButton.onClick.AddListener(HandlePButtonClicked);
        SButton.onClick.AddListener(HandleSButtonClicked);
    }

    private void HandleSButtonClicked()
    {
        // Siccors == 0
        GameRPS.StartBattle(0);
    }

    private void HandleRButtonClicked()
    {
        // Rock == 1
        GameRPS.StartBattle(1);
    }

    private void HandlePButtonClicked()
    {
        // Paper == 2
        GameRPS.StartBattle(2);
    }


}

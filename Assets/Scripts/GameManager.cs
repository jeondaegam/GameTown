using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    private AsyncOperation LoadingOp;
    public bool SaveEnabled;

    public Player _player; // TODO
    public Transform _playerSpawnPoint;
    public GameObject[] _playerPfs;

    public string MainScene; // 인스턴싱이 필요한 기본 타입 변수는 ?어떻게 ㅂ명명해 

    public enum Scene
    {
        Home,
        Loading,
        RockPaperScissors,
    }

    private const string SavedFileName = "PlayerData.json";

    private void Awake()
    {
        // GameManager 컴포넌트에 현재 오브젝트를 넣는다 ? 이거 전에도 했는데 또 헷갈리네
        // this랑 gameObject 차이도 
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        LoadGame();
    }


    private void LoadGame()
    {
        SpawnPlayer(0);
        LoadFile(); // 읽을 파일이 없으면 ? 
        SaveEnabled = true; // 이게 true면 어떻게 되는데 ?

        // 씬 로드 할 때 false를 줬음 
        LoadScene(Scene.Home.ToString(), false); // Loading 씬에서 시작한다고 치고 , 다음 씬인 Home 을 로딩함 
        // TODO - 홈씬 로드된 다음 캐릭터 뜨게 하려면 ? false 값 넘겨서 씬 로드 대기 
    }


    /**
     * 플레이어 캐릭터를 씬에 생성한다
     */
    private void SpawnPlayer(int playerIdx)
    {
        // 플레이어 Instance 생성 
        GameObject obj = Instantiate(_playerPfs[playerIdx], _playerSpawnPoint.position, _playerSpawnPoint.rotation);

        // 플레이어 컴포넌트에 넣어준다 
        _player = obj.GetComponent<Player>();
    }


    /**
     * 비동기 작업으로 씬을 불러온다  
     */
    public void LoadScene(string sceneName, bool activation = true) // default값을 true로 설정 
    {
        // Comp 
        // LoadSceneMode.Single: 기존 씬을 지우고 새로운 씬 로딩
        // 씬 로드를 비동기로 작업한다. 비동기 작업은 AsyncOperation 객체를 리턴한다 .  
        LoadingOp = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        // 씬 로드가 완료된 후 활성화 대기 (activation = false)
        LoadingOp.allowSceneActivation = activation; // = false 
    }



    /**
     * 저장된 게임 파일을 불러온다 
     */
    private void LoadFile() // LoadData
    {
        // 경로에서 파일을 읽어온다
        string fileInfo = Application.persistentDataPath + SavedFileName;

        if (File.Exists(fileInfo))
        {
            string str = File.ReadAllText(fileInfo);
            // json string 데이터를 PlayerData에 매핑(=바인딩) 한다
            PlayerData data = JsonUtility.FromJson<PlayerData>(str);
        }
        else
        {
            Debug.Log("Saved file does not exist.");
            return;
        }

    }



    private void SaveFile()
    {
        if (SaveEnabled)
        {
            PlayerData data = new PlayerData
            {
                Name = _player.Name,
                Health = _player.Health,
                Energy = _player.Energy,
                Money = _player.Money
            };
            File.WriteAllText(Application.persistentDataPath + SavedFileName,
                JsonUtility.ToJson(data)); // 직렬화 시킬 데이터를 넣는다 .

        }

    }


    // DONE 이게 뭔데 ? = 로딩씬에서 로딩이 완료되면 call 하는 함수 
    public void CompleteLoading()
    {
        if (LoadingOp != null)
        {
            Debug.Log("CompleteLoading 호출");
            // 비동기로 로드해둔 Home 씬을 활성화
            LoadingOp.allowSceneActivation = true;

            // 비동기 작업이 완료된 리소스를 참조 해제 
            LoadingOp = null;
        }
    }


    // TODO 비동기 씬 로드 작업이 시작 전이면 
    public float GetLoadingProgress()
    {
        // 비동기 씬 로드 작업이 시작 전이면 
        if (LoadingOp == null)
        {
            return 0f;
        }
        else
        {
            Debug.Log($"Loading progress: {Mathf.RoundToInt(LoadingOp.progress * 100)}%");
            return LoadingOp.progress;
        }
    }
}




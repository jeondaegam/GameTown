using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILoading : MonoBehaviour
{

    // 로딩바: Slider 컴포넌트
    public Slider _loadingBar;

    // 로딩 속도 
    public float _maxLoadingSpeed = 0.001f;

    // Text
    public Text _loadingText;


    private void OnEnable()
    {
        StartCoroutine(LoadingBarFillingRoutine());
        StartCoroutine(RendingTextRoutine(.3f, true));
    }


    private IEnumerator LoadingBarFillingRoutine()
    {
        while (true)
        {
            if (GameManager.Instance == null)
            {
                yield return null;
                continue;
            }

            if (_loadingBar.value >= .9f)
            {
                _loadingBar.value += _maxLoadingSpeed;

                // 슬라이딩바 로딩 완료 
                if (_loadingBar.value >= 1f)
                {
                    GameManager.Instance.CompleteLoading();
                    break;
                }
            }
            else
            {
                // 로딩바가 최대값(0.9)을 넘어가지 않도록 체크 
                // 비동기 작업 진행이 loadingBar 증가 속도보다 느리면 loadingProgress 작업 속도에 로딩바 속도를 맞춘다
                _loadingBar.value += _maxLoadingSpeed;
                float loadingProgress = GameManager.Instance.GetLoadingProgress();
                if (_loadingBar.value > loadingProgress)
                    _loadingBar.value = loadingProgress; // value가 0.9를 초과하는 순간 이 로직을 타고 value = loadingProcess == 0.9가 되면서 무한루프 
            }

            yield return null;

        }
    }


    private IEnumerator RendingTextRoutine(float delay, bool active)
    {
        while (active)
        {
            yield return new WaitForSeconds(delay);
            _loadingText.enabled = false;

            yield return new WaitForSeconds(delay);
            _loadingText.enabled = true;
            _loadingText.text += ". ";
        }
    }

}

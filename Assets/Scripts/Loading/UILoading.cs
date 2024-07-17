using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILoading : MonoBehaviour
{

    // 로딩바 = Slider 컴포넌트
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
        float value = 0.1f;
        while (true)
        {
            // TODO 
            //if (GameManager.Instance == null)
            //{
            //    yield return null;
            //    continue;
            //}

            if (_loadingBar.value >= .9f)
            {
                _loadingBar.value += _maxLoadingSpeed;
                if (_loadingBar.value >= 1f)
                {
                    // TODO
                    //GameManager.Instance.CompleteLoadin();
                    break;
                }
            }
            else
            {
                _loadingBar.value += _maxLoadingSpeed;
                // TODO 
                //float value = GameManager.Instance.GetLoadingProgress();
                 value += 0.0001f; //여기서 0.1f 더해줬더니 1로 훅가는듯 ? // 아닌가봄 .. 0.0001f로 했더니 빠르게 가다 느리게가다 빠름 
                /* 
                 * 로딩바 임계값 설정 
                 * 로딩바가 최대값을 넘어가지 않도록 체크 
                 */
                if (_loadingBar.value > value)
                {
                    _loadingBar.value = value;
                }
                yield return null;
            }
        }
    }

    private IEnumerator RendingTextRoutine(float delay, bool active)
    {
        while(active)
        {
            yield return new WaitForSeconds(delay);
            _loadingText.enabled = false;

            yield return new WaitForSeconds(delay);
            _loadingText.enabled = true;
            _loadingText.text += ". ";
        }
    }

}

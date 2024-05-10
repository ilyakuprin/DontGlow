using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using YG;

public class TimerBeforeAdsYG : MonoBehaviour
{
    private const int TimeUntilAd = 3;
    private const string FormatTimer = "{0} {1}...";
    [SerializeField] private TextMeshProUGUI _timerText;
    private string _startText;

    [SerializeField, 
        Tooltip("Объект таймера перед показом рекламы. Он будет активироваться и деактивироваться в нужное время.")]
    private GameObject secondsPanelObject;

    [SerializeField,
        Tooltip("Работа таймера в реальном времени, независимо от time scale.")]
    private bool realtimeSeconds;

    [Space(20)]
    [SerializeField]
    private UnityEvent onShowTimer; 
    [SerializeField]
    private UnityEvent onHideTimer;

    private void Start()
    {
        if (secondsPanelObject)
            secondsPanelObject.SetActive(false);

        if (_timerText)
            StartCoroutine(CheckTimerAd());
        else
            Debug.LogError("Fill in the array 'secondObjects'");
    }

    IEnumerator CheckTimerAd()
    {
        bool checking = true;
        while (checking)
        {
            if (YandexGame.timerShowAd >= YandexGame.Instance.infoYG.fullscreenAdInterval)
            {
                onShowTimer?.Invoke();
                objSecCounter = 0;
                if (secondsPanelObject)
                    secondsPanelObject.SetActive(true);

                StartCoroutine(TimerAdShow());
                yield return checking = false;
            }

            if (!realtimeSeconds)
                yield return new WaitForSeconds(1.0f);
            else
                yield return new WaitForSecondsRealtime(1.0f);
        }
    }

    int objSecCounter;
    IEnumerator TimerAdShow()
    {
        _startText = _timerText.text;
        PauseGame();

        bool process = true;
        while (process)
        {
            if (objSecCounter < TimeUntilAd)
            {
                _timerText.text = string.Format(FormatTimer, _startText, TimeUntilAd - objSecCounter);
                objSecCounter++;

                if (!realtimeSeconds)
                    yield return new WaitForSeconds(1.0f);
                else
                    yield return new WaitForSecondsRealtime(1.0f);
            }

            if (objSecCounter == TimeUntilAd)
            {
                YandexGame.FullscreenShow();
                StartCoroutine(BackupTimerClosure());

                _timerText.text = _startText;

                while (!YandexGame.nowFullAd)
                    yield return null;

                secondsPanelObject.SetActive(false);
                onHideTimer?.Invoke();
                objSecCounter = 0;
                StartCoroutine(CheckTimerAd());
                process = false;
            }
        }
    }

    IEnumerator BackupTimerClosure()
    {
        if (!realtimeSeconds)
            yield return new WaitForSeconds(2.5f);
        else
            yield return new WaitForSecondsRealtime(2.5f);
        
        if (objSecCounter != 0)
        {
            secondsPanelObject.SetActive(false);
            onHideTimer?.Invoke();
            objSecCounter = 0;
            StopCoroutine(TimerAdShow());
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
    }
}

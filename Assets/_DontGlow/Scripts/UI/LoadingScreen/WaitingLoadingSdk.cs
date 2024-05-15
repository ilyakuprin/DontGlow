using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using YG;

namespace _DontGlow.Scripts.UI.LoadingScreen
{
    public class WaitingLoadingSdk : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;

        private CancellationToken _ct;

        private void Start()
        {
            _ct = this.GetCancellationTokenOnDestroy();
            Wait().Forget();
        }


        private async UniTask Wait()
        {
            while (!YandexGame.SDKEnabled)
            {
                await UniTask.NextFrame(_ct);
            }

            _canvas.gameObject.SetActive(false);
        }
    }
}
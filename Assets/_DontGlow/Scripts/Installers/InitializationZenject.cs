using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using YG;
using Zenject;

namespace _DontGlow.Scripts.Installers
{
    public class InitializationZenject : MonoBehaviour
    {
        [SerializeField] private SceneContext _sceneContext;

        private CancellationToken _ct;
        
        private void Start()
        {
            _ct = this.GetCancellationTokenOnDestroy();
            Initialize().Forget();
        }


        private async UniTask Initialize()
        {
            while (!YandexGame.SDKEnabled)
                await UniTask.NextFrame(_ct);
            
            _sceneContext.Run();
        }
    }
}
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Zenject;

namespace _DontGlow.Scripts.Timer
{
    public class TimeCounter : IInitializable, IDisposable
    {
        public event Action<float> Counted;

        private CancellationTokenSource _cts = new CancellationTokenSource();
        private bool _isPause;
        private float _time;
        
        public void Initialize()
            => Start();

        public void Dispose()
        {
            _cts.Cancel();
            _cts.Dispose();
        }

        public void Stop()
            => _isPause = true;

        public void Start()
        {
            _isPause = false;
            Count().Forget();
        }

        private async UniTask Count()
        {
            while (!_isPause)
            {
                _time += UnityEngine.Time.deltaTime;
                Counted?.Invoke(_time);
                await UniTask.NextFrame(_cts.Token);
            }
        }
    }
}
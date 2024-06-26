using System;
using System.Threading;
using _DontGlow.Scripts.Pause;
using Cysharp.Threading.Tasks;
using Zenject;

namespace _DontGlow.Scripts.Timer
{
    public class TimeCounter : IInitializable, IDisposable, IPausable
    {
        public event Action<float> Counted;

        private readonly CancellationTokenSource _cts = new ();
        
        private bool _isPause;

        public float Time { get; private set; }

        public void Initialize()
            => StartCount();

        public void Dispose()
        {
            _cts.Cancel();
            _cts.Dispose();
        }

        public void Stop()
            => _isPause = true;

        public void Continue()
        {
            _isPause = false;
            StartCount();
        }

        private void StartCount()
            => Count().Forget();

        private async UniTask Count()
        {
            while (!_isPause && !_cts.IsCancellationRequested)
            {
                Time += UnityEngine.Time.deltaTime;
                Counted?.Invoke(Time);
                await UniTask.NextFrame(_cts.Token);
            }
        }
    }
}

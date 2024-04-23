using System;
using System.Threading;
using _DontGlow.Scripts.ScriptableObj;
using Cysharp.Threading.Tasks;
using Zenject;

namespace _DontGlow.Scripts.Enemy.Trap
{
    public class TimerStayingInTrap : IInitializable, IDisposable
    {
        public event Action GotOut; 
        
        private readonly InteractingWithTrap _interactingWithTrap;
        private readonly float _timeStaying;
        private readonly CancellationTokenSource _cts = new ();

        public TimerStayingInTrap(InteractingWithTrap interactingWithTrap,
                                  EnemyConfig enemyConfig)
        {
            _interactingWithTrap = interactingWithTrap;
            _timeStaying = enemyConfig.StandingTimeTrappedInSec;
        }
        
        public void Initialize()
            => _interactingWithTrap.Trapped += StartCount;

        public void Dispose()
        {
            _interactingWithTrap.Trapped -= StartCount;

            if (_cts.IsCancellationRequested) return;
            
            _cts.Cancel();
            _cts.Dispose();
        }

        private void StartCount()
            => CountTime().Forget();
        
        private async UniTask CountTime()
        {
            await UniTask.WaitForSeconds(_timeStaying, false, PlayerLoopTiming.Update, _cts.Token);
            
            GotOut?.Invoke();
        }
    }
}
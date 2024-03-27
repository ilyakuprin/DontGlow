using System;
using System.Threading;
using _DontGlow.Scripts.Pause;
using Cysharp.Threading.Tasks;
using UnityEngine.AI;
using Zenject;

namespace _DontGlow.Scripts.Enemy
{
    public class EnemyMovement : IInitializable, IPausable
    {
        public event Action Moved; 
        private readonly NavMeshAgent _agent;

        private GettingRandomPositionNavMesh _gettingPosition;
        private CancellationToken _ct;
        private bool _isPause;

        public EnemyMovement(EnemyView enemyView)
        {
            _agent = enemyView.Agent;
        }

        public void Initialize()
        {
            _agent.updateRotation = false;
            _agent.updateUpAxis = false;

            _gettingPosition = new GettingRandomPositionNavMesh();
            _gettingPosition.Init();

            _ct = _agent.GetCancellationTokenOnDestroy();
            
            Move().Forget();
        }

        public void Continue()
        {
            _isPause = false;
            Move().Forget();
        }

        public void Stop()
        {
            _isPause = true;
        }

        private async UniTask Move()
        {
            while (IsGamePlaying())
            {
                if (!_agent.hasPath)
                    _agent.SetDestination(_gettingPosition.Get());

                while (IsGamePlaying() && !_agent.hasPath)
                    await UniTask.NextFrame(_ct);

                while (IsGamePlaying() && _agent.hasPath)
                {
                    Moved?.Invoke();
                    await UniTask.WaitForFixedUpdate(_ct);
                }
            }
        }

        private bool IsGamePlaying()
            => !_isPause || !_ct.IsCancellationRequested;
    }
}
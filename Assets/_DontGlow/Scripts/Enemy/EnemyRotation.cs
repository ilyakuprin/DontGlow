using System.Threading;
using Cysharp.Threading.Tasks;
using Spine.Unity;
using UnityEngine;
using Zenject;

namespace _DontGlow.Scripts.Enemy
{
    public class EnemyRotation : IInitializable
    {
        private const int CountFrameWait = 10;

        private readonly SkeletonAnimation _spineAnim;
        private Transform _enemy;

        private Vector3 _lastPosition;
        private CancellationToken _ct;

        public EnemyRotation(EnemyView enemyView)
        {
            _spineAnim = enemyView.SpineAnim;
        }

        public void Initialize()
        {
            _enemy = _spineAnim.transform;

            _ct = _spineAnim.GetCancellationTokenOnDestroy();
            StartRotate();
        }
        
        private void StartRotate()
            => Rotate().Forget();
        
        private async UniTask Rotate()
        {
            _lastPosition = _enemy.position;

            await UniTask.DelayFrame(CountFrameWait, PlayerLoopTiming.Update, _ct);

            var currentPosition = _enemy.position;
            var moveVector = currentPosition - _lastPosition;

            Turn(moveVector.x);
            StartRotate();
        }

        private void Turn(float x)
        {
            if (x < 0 && _enemy.localScale.x < 0 || x > 0 && _enemy.localScale.x > 0)
                _enemy.localScale = new Vector3(-_enemy.localScale.x, _enemy.localScale.y, _enemy.localScale.z);
        } 
    }
}
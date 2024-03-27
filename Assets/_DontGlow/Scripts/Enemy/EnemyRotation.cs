using System;
using Spine.Unity;
using UnityEngine;
using Zenject;

namespace _DontGlow.Scripts.Enemy
{
    public class EnemyRotation : IInitializable, IDisposable
    {
        private readonly EnemyMovement _enemyMovement;
        private readonly SkeletonAnimation _spineAnim;
        
        private Transform _enemy;
        private Vector3 _lastPosition;

        public EnemyRotation(EnemyMovement enemyMovement,
                             EnemyView enemyView)
        {
            _enemyMovement = enemyMovement;
            _spineAnim = enemyView.SpineAnim;
        }

        public void Initialize()
        {
            _enemy = _spineAnim.transform;
            _lastPosition = _enemy.position;

            _enemyMovement.Moved += Rotate;
        }

        public void Dispose()
            => _enemyMovement.Moved -= Rotate;
        
        private void Rotate()
        {
            var enemyPos = _enemy.position;
            var moveVector = enemyPos - _lastPosition;

            Turn(moveVector.x);
            _lastPosition = enemyPos;
        }

        private void Turn(float x)
        {
            var enemyScale = _enemy.localScale;
            
            if (x < 0 && enemyScale.x < 0 || x > 0 && enemyScale.x > 0)
                _enemy.localScale = new Vector3(-enemyScale.x, enemyScale.y, enemyScale.z);
        } 
    }
}
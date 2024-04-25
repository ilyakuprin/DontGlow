using System;
using _DontGlow.Scripts.ScriptableObj;
using _DontGlow.Scripts.StringValues;
using UnityEngine;
using Zenject;

namespace _DontGlow.Scripts.Enemy
{
    public class KillingMainHero : IInitializable, IDisposable
    {
        public event Action Killed;
        
        private readonly DiscoveringMainHero _discovering;
        private readonly EnemyConfig _enemyConfig;
        private readonly EnemyView _enemyView;

        private int _mainHeroMask;

        public KillingMainHero(DiscoveringMainHero discovering,
                               EnemyConfig enemyConfig,
                               EnemyView enemyView)
        {
            _discovering = discovering;
            _enemyConfig = enemyConfig;
            _enemyView = enemyView;
        }

        public void Initialize()
        {
            _mainHeroMask = LayerMask.GetMask(LayerString.MainHero);
            
            _discovering.Discovered += DetectCollide;
        }

        public void Dispose()
        {
            _discovering.Discovered -= DetectCollide;
        }

        private void DetectCollide()
        {
            var hit = Physics2D.OverlapCircle(_enemyView.AttackCollider.position,
                                                       _enemyConfig.RadiusColliderAttack,
                                                       _mainHeroMask);

            if (hit)
            {
                Killed?.Invoke();
            }
        }
    }
}
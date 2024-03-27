using System;
using _DontGlow.Scripts.ScriptableObj;
using Zenject;

namespace _DontGlow.Scripts.Enemy
{
    public class SettingSpeed : IInitializable, IDisposable
    {
        private readonly EnemyConfig _enemyConfig;
        private readonly EnemyView _enemyView;
        private readonly DiscoveringMainHero _discoveringMainHero;
        private readonly CalculationSpeed _calculationSpeed;

        private bool _isDiscovered = true;
        
        public SettingSpeed(EnemyConfig enemyConfig,
                            EnemyView enemyView,
                            DiscoveringMainHero discoveringMainHero,
                            CalculationSpeed calculationSpeed)
        {
            _enemyConfig = enemyConfig;
            _enemyView = enemyView;
            _discoveringMainHero = discoveringMainHero;
            _calculationSpeed = calculationSpeed;
        }

        public void Initialize()
        {
            _discoveringMainHero.Discovered += SetIsDiscovered;
            _discoveringMainHero.NotDiscovered += SetIsNotDiscovered;
        }

        public void Dispose()
        {
            _discoveringMainHero.Discovered -= SetIsDiscovered;
            _discoveringMainHero.NotDiscovered -= SetIsNotDiscovered;
        }

        private void SetIsDiscovered()
        {
            if (_isDiscovered) return;
            
            _isDiscovered = true;
            _enemyView.Agent.speed = _calculationSpeed.Calculate(_enemyConfig.HuntingSpeed);
        } 

        private void SetIsNotDiscovered()
        {
            if (!_isDiscovered) return;
            
            _isDiscovered = false;
            _enemyView.Agent.speed = _calculationSpeed.Calculate(_enemyConfig.PatrolSpeed);
        } 
    }
}
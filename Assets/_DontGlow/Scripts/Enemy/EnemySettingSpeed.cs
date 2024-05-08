using System;
using _DontGlow.Scripts.Enemy.Trap;
using _DontGlow.Scripts.Pause;
using _DontGlow.Scripts.ScriptableObj;
using Zenject;

namespace _DontGlow.Scripts.Enemy
{
    public class EnemySettingSpeed : IInitializable, IDisposable
    {
        private readonly EnemyConfig _enemyConfig;
        private readonly EnemyView _enemyView;
        private readonly DiscoveringMainHero _discoveringMainHero;
        private readonly EnemyCalculationSpeed _enemyCalculationSpeed;
        private readonly InteractingWithTrap _interactingWithTrap;
        private readonly TimerStayingInTrap _timerStayingInTrap;

        private bool _isDiscovered = true;
        private bool _isTrapped;

        private float _speedBeforePause;
        
        public EnemySettingSpeed(EnemyConfig enemyConfig,
                                 EnemyView enemyView,
                                 DiscoveringMainHero discoveringMainHero,
                                 EnemyCalculationSpeed enemyCalculationSpeed,
                                 InteractingWithTrap interactingWithTrap,
                                 TimerStayingInTrap timerStayingInTrap)
        {
            _enemyConfig = enemyConfig;
            _enemyView = enemyView;
            _discoveringMainHero = discoveringMainHero;
            _enemyCalculationSpeed = enemyCalculationSpeed;
            _interactingWithTrap = interactingWithTrap;
            _timerStayingInTrap = timerStayingInTrap;
        }

        public void Initialize()
        {
            _discoveringMainHero.Discovered += SetIsDiscovered;
            _discoveringMainHero.NotDiscovered += SetIsNotDiscovered;
            _interactingWithTrap.Trapped += Trapped;
            _timerStayingInTrap.GotOut += UnTrapped;
            _enemyCalculationSpeed.Adeed += ReCalculate;
        }

        public void Dispose()
        {
            _discoveringMainHero.Discovered -= SetIsDiscovered;
            _discoveringMainHero.NotDiscovered -= SetIsNotDiscovered;
            _interactingWithTrap.Trapped -= Trapped;
            _timerStayingInTrap.GotOut -= UnTrapped;
            _enemyCalculationSpeed.Adeed -= ReCalculate;
        }

        private void Trapped()
        {
            if (_isTrapped) return;
            
            _isTrapped = true;

            _enemyView.Agent.speed = 0f;
        }

        private void UnTrapped()
        {
            if (!_isTrapped) return;
            
            _isTrapped = false;

            ReCalculate();
        }

        private void ReCalculate()
        {
            if (_isDiscovered)
            {
                _isDiscovered = false;
                SetIsDiscovered();
            }
            else
            {
                _isDiscovered = true;
                SetIsNotDiscovered();
            }
        }

        private void SetIsDiscovered()
        {
            if (_isDiscovered) return;
            
            _isDiscovered = true;
            
            if (_isTrapped) return;
            
            _enemyView.Agent.speed = _enemyCalculationSpeed.Calculate(_enemyConfig.HuntingSpeed);
        } 

        private void SetIsNotDiscovered()
        {
            if (!_isDiscovered) return;
            
            _isDiscovered = false;
            
            if (_isTrapped) return;
            
            _enemyView.Agent.speed = _enemyCalculationSpeed.Calculate(_enemyConfig.PatrolSpeed);
        } 
    }
}

using System;
using _DontGlow.Scripts.ScriptableObj;
using Zenject;

namespace _DontGlow.Scripts.Enemy
{
    public class CalculationSpeed : IInitializable, IDisposable
    {
        private readonly EnemyConfig _enemyConfig;
        private int _lvlSpeed;

        public CalculationSpeed(EnemyConfig enemyConfig)
        {
            _enemyConfig = enemyConfig;
        }

        public void Initialize()
        {
            
        }

        public void Dispose()
        {
            
        }

        private void Add()
            => _lvlSpeed++;

        public float Calculate(float startSpeed)
            => startSpeed + startSpeed * _enemyConfig.SpeedMultiplier * _lvlSpeed;
    }
}
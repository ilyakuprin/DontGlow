using System;
using _DontGlow.Scripts.MainHero;
using _DontGlow.Scripts.ScriptableObj;
using Zenject;

namespace _DontGlow.Scripts.Enemy
{
    public class EnemyCalculationSpeed : IInitializable, IDisposable
    {
        public event Action Adeed;
        
        private readonly EnemyConfig _enemyConfig;
        private readonly PickingUpItems _pickingUpItems;
        private int _lvlSpeed;

        public EnemyCalculationSpeed(EnemyConfig enemyConfig,
                                     PickingUpItems pickingUpItems)
        {
            _enemyConfig = enemyConfig;
            _pickingUpItems = pickingUpItems;
        }
        
        public void Initialize()
            => _pickingUpItems.TakenNote += Add;

        public void Dispose()
            => _pickingUpItems.TakenNote += Add;

        private void Add()
        {
            _lvlSpeed++;
            Adeed?.Invoke();
        }

        public float Calculate(float startSpeed)
            => startSpeed + startSpeed * _enemyConfig.SpeedMultiplier * _lvlSpeed;
    }
}
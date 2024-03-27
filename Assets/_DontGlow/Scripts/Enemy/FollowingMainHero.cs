using System;
using _DontGlow.Scripts.MainHero;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace _DontGlow.Scripts.Enemy
{
    public class FollowingMainHero : IInitializable, IDisposable
    {
        private readonly DiscoveringMainHero _discoveringMainHero;
        private readonly NavMeshAgent _agent;
        private readonly Transform _mainHero;

        public FollowingMainHero(DiscoveringMainHero discoveringMainHero,
                                 EnemyView enemyView,
                                 MainHeroView mainHeroView)
        {
            _discoveringMainHero = discoveringMainHero;
            _agent = enemyView.Agent;
            _mainHero = mainHeroView.Rigidbody.transform;
        }

        public void Initialize()
            => _discoveringMainHero.Discovered += Follow;

        public void Dispose()
            => _discoveringMainHero.Discovered -= Follow;

        private void Follow()
            => _agent.SetDestination(_mainHero.position);
    }
}
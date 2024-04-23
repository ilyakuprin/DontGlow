using System;
using _DontGlow.Scripts.Enemy.Trap;
using UnityEngine;
using Zenject;

namespace _DontGlow.Scripts.Objects.OpenTrap
{
    public class DisablingTrap : IInitializable, IDisposable
    {
        private readonly TimerStayingInTrap _timerStayingInTrap;
        
        private GameObject _trap;

        public DisablingTrap(TimerStayingInTrap timerStayingInTrap)
        {
            _timerStayingInTrap = timerStayingInTrap;
        }

        public void SetTrap(GameObject trap)
            => _trap = trap;

        public void Initialize()
            => _timerStayingInTrap.GotOut += Disable;

        public void Dispose()
            => _timerStayingInTrap.GotOut -= Disable;

        private void Disable()
            => _trap.SetActive(false);
    }
}

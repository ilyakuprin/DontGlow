using System;
using _DontGlow.Scripts.Objects.OpenTrap;
using _DontGlow.Scripts.StringValues;
using UnityEngine;
using Zenject;

namespace _DontGlow.Scripts.Enemy.Trap
{
    public class InteractingWithTrap : MonoBehaviour
    {
        public event Action Trapped;
        
        [Inject] private readonly TimerStayingInTrap _timerStayingInTrap;
        [Inject] private readonly DisablingTrap _disablingTrap;
        
        private int _trapLayer;
        private bool _isTrapped;
        
        private void Awake()
            => _trapLayer = LayerMask.NameToLayer(LayerString.Trap);

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!_isTrapped && other.gameObject.layer == _trapLayer)
            {
                _disablingTrap.SetTrap(other.gameObject);
                Trapped?.Invoke();
            }
        }

        private void UnTrapped()
            => _isTrapped = false;

        private void OnEnable()
            => _timerStayingInTrap.GotOut += UnTrapped;

        private void OnDisable()
            => _timerStayingInTrap.GotOut -= UnTrapped;
    }
}

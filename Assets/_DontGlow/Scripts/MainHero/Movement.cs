using System;
using _DontGlow.Scripts.Inputting;
using _DontGlow.Scripts.ScriptableObj;
using UnityEngine;
using Zenject;

namespace _DontGlow.Scripts.MainHero
{
    public class Movement : IExecutive, IFixedTickable, IInitializable, IDisposable
    {
        public event Action<bool> Executed;
        public event Action<Vector2> Moved;
        
        private const float SpeedError = 0.01f;
        
        private readonly Rigidbody2D _rigidbody;
        private readonly float _speed;
        private readonly PlayerInput _input;
        
        private float _horizontalForce;
        private Vector2 _moveVelocity;

        public Movement(MainHeroView mainHeroView,
                        MainHeroConfig mainHeroConfig, 
                        PlayerInput input)
        {
            _rigidbody = mainHeroView.Rigidbody;
            _speed = mainHeroConfig.Speed;
            _input = input;
        }

        public void Initialize()
            => _input.Inputted += Execute;

        public void Dispose()
            => _input.Inputted -= Execute;

        public void Execute(InputData inputData)
        {
            var normalizedDirection = inputData.Direction.normalized;
            _moveVelocity = normalizedDirection * _speed;

            var isMove = IsMove();
            Executed?.Invoke(isMove);
            
            if (isMove)
                Moved?.Invoke(normalizedDirection);
        }

        public void FixedTick()
            => _rigidbody.MovePosition(_rigidbody.position + _moveVelocity * Time.fixedDeltaTime);

        private bool IsMove()
            => _moveVelocity.x is > SpeedError or < -SpeedError ||
               _moveVelocity.y is > SpeedError or < -SpeedError;
    }
}
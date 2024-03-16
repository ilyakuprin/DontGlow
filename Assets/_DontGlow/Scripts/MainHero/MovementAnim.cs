using System;
using _DontGlow.Scripts.StringValues;
using UnityEngine;
using Zenject;

namespace _DontGlow.Scripts.MainHero
{
    public class MovementAnim : IInitializable, IDisposable
    {
        private readonly Movement _movement;
        private readonly int _moveAnim;
        private readonly Animator _animator;

        public MovementAnim(Movement movement,
                            MainHeroView mainHeroView)
        {
            _movement = movement;
            _moveAnim = new AnimName().Move;
            _animator = mainHeroView.Animator;
        }

        public void Initialize()
            => _movement.Moved += SetAnim;

        private void SetAnim(bool value)
            => _animator.SetBool(_moveAnim, value);

        public void Dispose()
            => _movement.Moved -= SetAnim;
    }
}
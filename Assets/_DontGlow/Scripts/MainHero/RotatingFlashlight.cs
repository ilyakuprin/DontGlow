using System;
using _DontGlow.Scripts.ScriptableObj;
using UnityEngine;
using Zenject;

namespace _DontGlow.Scripts.MainHero
{
    public class RotatingFlashlight : IInitializable, IDisposable
    {
        private readonly Movement _movement;
        private readonly MainHeroView _mainHeroView;
        private readonly MainHeroConfig _mainHeroConfig;

        public RotatingFlashlight(Movement movement,
                                  MainHeroView mainHeroView,
                                  MainHeroConfig mainHeroConfig)
        {
            _movement = movement;
            _mainHeroView = mainHeroView;
            _mainHeroConfig = mainHeroConfig;
        }

        public void Initialize()
            => _movement.Moved += Rotate;

        public void Dispose()
            => _movement.Moved -= Rotate;

        private void Rotate(Vector2 direction)
        {
            var fromRotate = _mainHeroView.Flashlight.rotation;
            var toRotate = Quaternion.LookRotation(Vector3.forward, direction);
            var speed = _mainHeroConfig.SpeedRotateFlashlight * Time.deltaTime;
            
            _mainHeroView.Flashlight.rotation = Quaternion.RotateTowards(fromRotate,
                                                                         toRotate,
                                                                         speed);
        }
    }
}

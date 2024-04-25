using System;
using System.Collections.Generic;
using _DontGlow.Scripts.Enemy;
using _DontGlow.Scripts.Flashlight;
using _DontGlow.Scripts.Inputting;
using _DontGlow.Scripts.MainHero;
using _DontGlow.Scripts.Timer;
using Zenject;

namespace _DontGlow.Scripts.Pause
{
    public class SettingPause : IInitializable, IDisposable
    {
        private readonly KillingMainHero _killingMainHero;
        private readonly PickingUpItems _pickingUpItems;
        private readonly List<IPausable> _pausables = new(5);

        public SettingPause(KillingMainHero killingMainHero,
                            PickingUpItems pickingUpItems,
                            DiscoveringMainHero discoveringMainHero,
                            EnemyMovement enemyMovement,
                            PlayerInput playerInput,
                            RunningLowFlashlight runningLowFlashlight,
                            TimeCounter timeCounter)
        {
            _killingMainHero = killingMainHero;
            _pickingUpItems = pickingUpItems;
            
            _pausables.Add(discoveringMainHero);
            _pausables.Add(enemyMovement);
            _pausables.Add(playerInput);
            _pausables.Add(runningLowFlashlight);
            _pausables.Add(timeCounter);
        }

        public void Initialize()
        {
            _killingMainHero.Killed += Pause;
            _pickingUpItems.TakenDoorExit += Pause;
        }

        public void Dispose()
        {
            _killingMainHero.Killed -= Pause;
            _pickingUpItems.TakenDoorExit -= Pause;
        }

        private void Pause()
        {
            foreach (var pause in _pausables)
            {
                pause.Stop();
            }
        }
    }
}
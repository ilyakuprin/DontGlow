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
        private readonly IPausable[] _pausables;

        public SettingPause(KillingMainHero killingMainHero,
                            PickingUpItems pickingUpItems,
                            IPausable[] pausables)
        {
            _killingMainHero = killingMainHero;
            _pickingUpItems = pickingUpItems;
            _pausables = pausables;
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
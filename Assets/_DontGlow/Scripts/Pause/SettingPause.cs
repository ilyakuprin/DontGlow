using System;
using _DontGlow.Scripts.Enemy;
using _DontGlow.Scripts.MainHero;
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

        public void Pause()
        {
            foreach (var pause in _pausables)
            {
                pause.Stop();
            }
        }

        public void UnPause()
        {
            foreach (var pause in _pausables)
            {
                pause.Continue();
            }
        }
    }
}
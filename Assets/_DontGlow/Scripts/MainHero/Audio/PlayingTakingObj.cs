using System;
using UnityEngine;
using Zenject;

namespace _DontGlow.Scripts.MainHero.Audio
{
    public class PlayingTakingObj : IInitializable, IDisposable
    {
        private readonly PickingUpItems _pickingUpItems;
        private readonly AudioSource _audioSource;

        public PlayingTakingObj(PickingUpItems pickingUpItems,
                         MainHeroView mainHeroView)
        {
            _pickingUpItems = pickingUpItems;
            _audioSource = mainHeroView.TakenObjSound;
        }

        public void Initialize()
        {
            _pickingUpItems.TakenBattery += Play;
            _pickingUpItems.TakenKey += Play;
            _pickingUpItems.TakenNote += Play;
            _pickingUpItems.TakenTrap += Play;
        }

        public void Dispose()
        {
            _pickingUpItems.TakenBattery -= Play;
            _pickingUpItems.TakenKey -= Play;
            _pickingUpItems.TakenNote -= Play;
            _pickingUpItems.TakenTrap -= Play;
        }

        private void Play()
            => _audioSource.Play();
    }
}
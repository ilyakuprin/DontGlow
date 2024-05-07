using System;
using UnityEngine;
using Zenject;

namespace _DontGlow.Scripts.MainHero.Audio
{
    public class PlayingExit : IInitializable, IDisposable
    {
        private readonly AudioSource _audioSource;
        private readonly PickingUpItems _pickingUpItems;

        public PlayingExit(MainHeroView mainHeroView,
                           PickingUpItems pickingUpItems)
        {
            _audioSource = mainHeroView.ExitSound;
            _pickingUpItems = pickingUpItems;
        }

        public void Initialize()
            => _pickingUpItems.TakenDoorExit += Play;

        public void Dispose()
            => _pickingUpItems.TakenDoorExit -= Play;

        private void Play()
            => _audioSource.Play();
    }
}
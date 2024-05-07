using System;
using UnityEngine;
using Zenject;

namespace _DontGlow.Scripts.Flashlight.Audio
{
    public class PlayingChargingSatDown : IInitializable, IDisposable
    {
        private readonly RunningLowFlashlight _runningLowFlashlight;
        private readonly AudioSource _audioSource;

        public PlayingChargingSatDown(RunningLowFlashlight runningLowFlashlight,
                                      FlashlightView flashlightView)
        {
            _runningLowFlashlight = runningLowFlashlight;
            _audioSource = flashlightView.Audio;
        }

        public void Initialize()
            => _runningLowFlashlight.DivisionsOver += Play;

        public void Dispose()
            => _runningLowFlashlight.DivisionsOver -= Play;

        private void Play()
            => _audioSource.Play();
    }
}
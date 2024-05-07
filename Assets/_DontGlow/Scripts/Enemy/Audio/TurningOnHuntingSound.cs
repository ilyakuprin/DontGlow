using System;
using System.Threading;
using _DontGlow.Scripts.MainHero;
using _DontGlow.Scripts.ScriptableObj;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace _DontGlow.Scripts.Enemy.Audio
{
    public class TurningOnHuntingSound : IInitializable, IDisposable
    {
        private readonly AudioSource _audioSource;
        private readonly DiscoveringMainHero _discoveringMainHero;
        private readonly EnemyConfig _enemyConfig;

        private CancellationToken _ct;
        private bool _isTurnOn; 

        public TurningOnHuntingSound(MainHeroView mainHeroView,
                                     DiscoveringMainHero discoveringMainHero,
                                     EnemyConfig enemyConfig)
        {
            _audioSource = mainHeroView.MainSounds;
            _discoveringMainHero = discoveringMainHero;
            _enemyConfig = enemyConfig;
        }

        public void Initialize()
        {
            _ct = _audioSource.GetCancellationTokenOnDestroy();
            
            _discoveringMainHero.Discovered += TurnOn;
            _discoveringMainHero.NotDiscovered += TurnOff;
        }

        public void Dispose()
        {
            _discoveringMainHero.Discovered -= TurnOn;
            _discoveringMainHero.NotDiscovered -= TurnOff;
        }

        private void TurnOn()
        {
            if (_isTurnOn) return;

            _isTurnOn = true;
            
            SetHuntAudio().Forget();
        }

        private async UniTask SetHuntAudio()
        {
            SetAudio(_enemyConfig.PreRun);

            var timer = 0f;
            while (timer < _enemyConfig.PreRun.length && _isTurnOn)
            {
                timer += Time.deltaTime;
                await UniTask.NextFrame(_ct);
            }
            
            if (_isTurnOn && !_ct.IsCancellationRequested)
                SetAudio(_enemyConfig.Run);
        }

        private void TurnOff()
        {
            if (!_isTurnOn) return;

            _isTurnOn = false;

            SetAudio(_enemyConfig.Walking);
        }
        
        private void SetAudio(AudioClip clip)
        {
            _audioSource.clip = clip;
            _audioSource.Play();
        } 
    }
}
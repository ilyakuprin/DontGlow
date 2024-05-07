using System.Threading;
using _DontGlow.Scripts.Pause;
using _DontGlow.Scripts.ScriptableObj;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace _DontGlow.Scripts.Enemy.Audio
{
    public class PlayingMonsterSound : IInitializable, IPausable
    {
        private readonly AudioSource _audioSource;
        private readonly EnemyConfig _enemyConfig;
        
        private bool _isPause;
        private float _timer;
        private CancellationToken _ct;

        public PlayingMonsterSound(EnemyView enemyView,
                                   EnemyConfig enemyConfig)
        {
            _audioSource = enemyView.Audio;
            _enemyConfig = enemyConfig;
        }

        public void Initialize()
        {
            _ct = _audioSource.GetCancellationTokenOnDestroy();
            StartTimer();
        }

        public void Stop()
        {
            _isPause = true;
        }

        public void Continue()
        {
            _isPause = false;
            StartTimer();
        }

        private void StartTimer()
            => CountTime().Forget();

        private async UniTask CountTime()
        {
            if (_timer <= 0f)
                _timer = Random.Range(_enemyConfig.MinRandomTimeAudioInSec, _enemyConfig.MaxRandomTimeAudioInSec);

            while (_timer > 0f && !_isPause)
            {
                _timer -= Time.deltaTime;
                await UniTask.NextFrame(_ct);
            }

            Play();
            StartTimer();
        }

        private void Play()
            => _audioSource.Play();
    }
}
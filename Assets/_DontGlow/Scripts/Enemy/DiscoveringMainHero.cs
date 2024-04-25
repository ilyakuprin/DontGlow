using System;
using System.Threading;
using _DontGlow.Scripts.MainHero;
using _DontGlow.Scripts.Pause;
using _DontGlow.Scripts.ScriptableObj;
using _DontGlow.Scripts.StringValues;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace _DontGlow.Scripts.Enemy
{
    public class DiscoveringMainHero : IInitializable, IDisposable, IPausable
    {
        public event Action Discovered;
        public event Action NotDiscovered;
        
        private readonly CancellationTokenSource _cts = new ();
        private readonly EnemyConfig _enemyConfig;
        private readonly EnemyView _enemyView;
        private readonly MainHeroView _mainHeroView;

        private int _mask;
        private int _layerHeroIndex;
        private bool _isPause;

        public DiscoveringMainHero(EnemyConfig enemyConfig,
                                   EnemyView enemyView,
                                   MainHeroView mainHeroView)
        {
            _enemyConfig = enemyConfig;
            _enemyView = enemyView;
            _mainHeroView = mainHeroView;
        }
        
        public void Initialize()
        {
            var maskWall = LayerMask.GetMask(LayerString.Wall);
            var maskMainHero = LayerMask.GetMask(LayerString.MainHero);
            _mask = maskWall | maskMainHero;
            
            _layerHeroIndex = LayerMask.NameToLayer(LayerString.MainHero);
            
            StartDetect();
        } 

        public void Dispose()
        {
            _cts.Cancel();
            _cts.Dispose();
        }

        public void Stop()
            => _isPause = true;

        public void Continue()
        {
            _isPause = false;
            StartDetect();
        }
        
        private void StartDetect()
            => Detect().Forget();
        
        private async UniTask Detect()
        {
            while (!_isPause && !_cts.IsCancellationRequested)
            {
                await UniTask.WaitForFixedUpdate(_cts.Token);
                
                var position = _enemyView.Eyes.position;
                var direction = _mainHeroView.Rigidbody.transform.position - position;
                var distanceSqr = direction.sqrMagnitude;

                if (distanceSqr > _enemyConfig.RadiusLineSight * _enemyConfig.RadiusLineSight)
                {
                    NotDiscovered?.Invoke();
                    continue;
                }
                
                var hit = Physics2D.Raycast(position,
                                            direction,
                                            _enemyConfig.RadiusLineSight,
                                            _mask);

                if (hit.collider && hit.collider.gameObject.layer == _layerHeroIndex)
                {
                    Discovered?.Invoke();
                }
            }
        }
    }
}
using System;
using _DontGlow.Scripts.MainHero;
using _DontGlow.Scripts.Pause;
using _DontGlow.Scripts.ScriptableObj;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Zenject;

namespace _DontGlow.Scripts.UI.HeroUi
{
    public class FadingTextHeroUi : IInitializable, IDisposable, IPausable
    {
        private const float TargetFade = 0f;
        
        private readonly TextMeshProUGUI _text;
        private readonly PickingUpItems _pickingUpItems;
        private readonly HeroTextConfig _heroTextConfig;

        private float _timer;
        private bool _isPause;
        private bool _faded = true;

        public FadingTextHeroUi(HeroUiView heroUiView,
                                PickingUpItems pickingUpItems,
                                HeroTextConfig heroTextConfig)
        {
            _text = heroUiView.Text;
            _pickingUpItems = pickingUpItems;
            _heroTextConfig = heroTextConfig;
        }

        public void Initialize()
        {
            var color = _text.color;
            color.a = 0f;
            _text.color = color;
            
            _pickingUpItems.TakenNote += StartTimer;
        }

        public void Dispose()
            => _pickingUpItems.TakenNote += StartTimer;

        public void Continue()
        {
            _isPause = false;
            ContinueTimer();
        }

        public void Stop()
        {
            _isPause = true;
        }

        private void StartTimer()
        {
            var color = _text.color;
            color.a = 1f;
            _text.color = color;
            _faded = false;
            
            _timer = _heroTextConfig.TimeStayTextInSec;

            ContinueTimer();
        } 

        private void ContinueTimer()
            => CoutTime().Forget();

        private async UniTask CoutTime()
        {
            while (_timer > 0f && !_isPause)
            {
                _timer -= Time.deltaTime;
                await UniTask.NextFrame();
            }

            if (!_isPause && !_faded)
            {
                Fade();
            }
        }

        private void Fade()
            => _text.DOFade(TargetFade, _heroTextConfig.FadeTimeInSec).OnComplete(() => _faded = true);
    }
}
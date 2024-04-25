using System;
using _DontGlow.Scripts.Enemy;
using DG.Tweening;
using Zenject;

namespace _DontGlow.Scripts.UI.Pause
{
    public class FadingDefeatCanvas : IInitializable, IDisposable
    {
        private readonly UiPauseView _uiPauseView;
        private readonly KillingMainHero _killingMainHero;

        public FadingDefeatCanvas(UiPauseView uiPauseView,
                                  KillingMainHero killingMainHero)
        {
            _uiPauseView = uiPauseView;
            _killingMainHero = killingMainHero;
        }

        public void Initialize()
            => _killingMainHero.Killed += Fade;

        public void Dispose()
            => _killingMainHero.Killed -= Fade;

        private void Fade()
        {
            for (var i = 0; i < _uiPauseView.LengthGraphicDefeat; i++)
            {
                var color = _uiPauseView.GetGraphicDefeat(i).color;
                color.a = 0;
                _uiPauseView.GetGraphicDefeat(i).color = color;
                
                _uiPauseView.GetGraphicDefeat(i).DOFade(UiPauseView.TargetFade, UiPauseView.FadeTime);
            }
        }
    }
}
using System;
using _DontGlow.Scripts.MainHero;
using DG.Tweening;
using Zenject;

namespace _DontGlow.Scripts.UI.Pause
{
    public class FadingVictoryCanvas : IInitializable, IDisposable
    {
        private readonly UiPauseView _uiPauseView;
        private readonly PickingUpItems _pickingUpItems;

        public FadingVictoryCanvas(UiPauseView uiPauseView,
                                  PickingUpItems pickingUpItems)
        {
            _uiPauseView = uiPauseView;
            _pickingUpItems = pickingUpItems;
        }

        public void Initialize()
            => _pickingUpItems.TakenDoorExit += Fade;

        public void Dispose()
            => _pickingUpItems.TakenDoorExit -= Fade;

        private void Fade()
        {
            for (var i = 0; i < _uiPauseView.LengthGraphicVictory; i++)
            {
                var color = _uiPauseView.GetGraphicVictory(i).color;
                color.a = 0;
                _uiPauseView.GetGraphicVictory(i).color = color;
                
                _uiPauseView.GetGraphicVictory(i).DOFade(UiPauseView.TargetFade, UiPauseView.FadeTime);
            }
        }
    }
}
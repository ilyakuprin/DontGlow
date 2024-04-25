using System;
using _DontGlow.Scripts.Enemy;
using Zenject;

namespace _DontGlow.Scripts.UI.Pause
{
    public class ShowingDefeat : IInitializable, IDisposable
    {
        private readonly UiPauseView _uiPauseView;
        private readonly KillingMainHero _killingMainHero;

        public ShowingDefeat(UiPauseView uiPauseView,
                             KillingMainHero killingMainHero)
        {
            _uiPauseView = uiPauseView;
            _killingMainHero = killingMainHero;
        }

        public void Initialize()
            => _killingMainHero.Killed += Show;

        public void Dispose()
            => _killingMainHero.Killed -= Show;

        private void Show()
            => _uiPauseView.Defeat.gameObject.SetActive(true);
    }
}
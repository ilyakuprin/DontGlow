using System;
using _DontGlow.Scripts.MainHero;
using Zenject;

namespace _DontGlow.Scripts.UI.GameStatus
{
    public class ShowingVictory : IInitializable, IDisposable
    {
        private readonly UiPauseView _uiPauseView;
        private readonly PickingUpItems _pickingUpItems;

        public ShowingVictory(UiPauseView uiPauseView,
                             PickingUpItems pickingUpItems)
        {
            _uiPauseView = uiPauseView;
            _pickingUpItems = pickingUpItems;
        }

        public void Initialize()
            => _pickingUpItems.TakenDoorExit += Show;

        public void Dispose()
            => _pickingUpItems.TakenDoorExit -= Show;

        private void Show()
            => _uiPauseView.Victory.gameObject.SetActive(true);
    }
}
using System;
using _DontGlow.Scripts.MainHero;
using Zenject;

namespace _DontGlow.Scripts.UI.Game
{
    public class ShowingKey : IInitializable, IDisposable
    {
        private readonly PickingUpItems _pickingUpItems;
        private readonly UiInGameView _uiInGameView;

        public ShowingKey(PickingUpItems pickingUpItems,
                          UiInGameView uiInGameView)
        {
            _pickingUpItems = pickingUpItems;
            _uiInGameView = uiInGameView;
        }

        public void Initialize()
            => _pickingUpItems.TakenKey += Show;

        public void Dispose()
            => _pickingUpItems.TakenKey -= Show;

        private void Show()
            => _uiInGameView.Key.SetActive(true);
    }
}
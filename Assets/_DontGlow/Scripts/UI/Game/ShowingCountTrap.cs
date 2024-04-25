using System;
using _DontGlow.Scripts.Objects;
using Zenject;

namespace _DontGlow.Scripts.UI.Game
{
    public class ShowingCountTrap : IInitializable, IDisposable
    {
        private const string Format = "x{0}";
        
        private readonly CounterTrap _counterTrap;
        private readonly UiInGameView _uiInGameView;

        public ShowingCountTrap(CounterTrap counterTrap,
                                UiInGameView uiInGameView)
        {
            _counterTrap = counterTrap;
            _uiInGameView = uiInGameView;
        }
        
        public void Initialize()
            => _counterTrap.CountChanged += Show;

        public void Dispose()
            => _counterTrap.CountChanged -= Show;

        private void Show(int count)
            => _uiInGameView.Trap.text = string.Format(Format, count);
    }
}
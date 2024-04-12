using System;
using _DontGlow.Scripts.Objects;
using Zenject;

namespace _DontGlow.Scripts.UI
{
    public class ShowingCountBattery : IInitializable, IDisposable
    {
        private const string Format = "x{0}";

        private readonly CounterBattery _counterBattery;
        private readonly UiInGameView _uiInGameView;

        public ShowingCountBattery(CounterBattery counterBattery,
                                   UiInGameView uiInGameView)
        {
            _counterBattery = counterBattery;
            _uiInGameView = uiInGameView;
        }

        public void Initialize()
            => _counterBattery.CountChanged += Show;

        public void Dispose()
            => _counterBattery.CountChanged -= Show;

        private void Show(int count)
            => _uiInGameView.Battery.text = string.Format(Format, count);
    }
}
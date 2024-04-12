using System;
using _DontGlow.Scripts.Flashlight;
using Zenject;

namespace _DontGlow.Scripts.UI
{
    public class ShowingCountDivisionFlashlight : IInitializable, IDisposable
    {
        private readonly RunningLowFlashlight _runningLowFlashlight;
        private readonly UiInGameView _uiInGameView;

        public ShowingCountDivisionFlashlight(RunningLowFlashlight runningLowFlashlight,
                                              UiInGameView uiInGameView)
        {
            _runningLowFlashlight = runningLowFlashlight;
            _uiInGameView = uiInGameView;
        }

        public void Initialize()
            => _runningLowFlashlight.DivisionChanged += Show;

        public void Dispose()
            => _runningLowFlashlight.DivisionChanged -= Show;

        private void Show(int countDivision)
        {
            for (var i = 0; i < _uiInGameView.LengthDivision; i++)
            {
                var isEnabled = i < countDivision;
                
                _uiInGameView.GetDivision(i).enabled = isEnabled;
            }
        }
    }
}
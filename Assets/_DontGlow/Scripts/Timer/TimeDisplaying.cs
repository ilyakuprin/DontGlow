using System;
using Zenject;

namespace _DontGlow.Scripts.Timer
{
    public class TimeDisplaying : IInitializable, IDisposable
    {
        private readonly TimerView _timerView;
        private readonly TimeCounter _timeCounter;
        
        public TimeDisplaying(TimeCounter timeCounter,
                              TimerView timerView)
        {
            _timeCounter = timeCounter;
            _timerView = timerView;
        }

        public void Initialize()
            => _timeCounter.Counted += Show;

        public void Dispose()
            => _timeCounter.Counted -= Show;

        private void Show(float time)
        {
            var ts = TimeSpan.FromSeconds(time);
            _timerView.TextTimer.text = $"{ts.Minutes:00}:{ts.Seconds:00}";
        }
    }
}
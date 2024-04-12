using System;
using _DontGlow.Scripts.Objects;
using Zenject;

namespace _DontGlow.Scripts.Flashlight
{
    public class ChargingChargedFlashlight : IInitializable, IDisposable
    {
        private readonly RunningLowFlashlight _runningLowFlashlight;
        private readonly CounterBattery _counterBattery;

        public ChargingChargedFlashlight(RunningLowFlashlight runningLowFlashlight,
                                         CounterBattery counterBattery)
        {
            _runningLowFlashlight = runningLowFlashlight;
            _counterBattery = counterBattery;
        }

        public void Initialize()
            => _counterBattery.CountChanged += Charge;

        public void Dispose()
            => _counterBattery.CountChanged -= Charge;

        private void Charge(int count)
        {
            if (count <= 0 || _runningLowFlashlight.CurrentCountDivision > 0) return;
            
            _counterBattery.Subtract();
            _runningLowFlashlight.Initialize();
        }
    }
}
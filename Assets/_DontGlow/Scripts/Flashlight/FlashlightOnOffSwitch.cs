using System;
using Zenject;

namespace _DontGlow.Scripts.Flashlight
{
    public class FlashlightOnOffSwitch : IInitializable, IDisposable
    {
        private readonly OnOffButton _onOffButton;
        private readonly RunningLowFlashlight _runningLowFlashlight;

        public FlashlightOnOffSwitch(OnOffButton onOffButton,
                                     RunningLowFlashlight runningLowFlashlight)
        {
            _onOffButton = onOffButton;
            _runningLowFlashlight = runningLowFlashlight;
        }

        public void Initialize()
        {
            _onOffButton.Oned += On;
            _onOffButton.Offed += Off;
        }

        public void Dispose()
        {
            _onOffButton.Oned -= On;
            _onOffButton.Offed -= Off;
        }
        
        private void On()
        {
            _runningLowFlashlight.OnButton();
        }
        
        private void Off()
        {
            _runningLowFlashlight.OffButton();
        }
    }
}
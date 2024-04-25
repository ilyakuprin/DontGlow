using System;
using System.Threading;
using _DontGlow.Scripts.Objects;
using _DontGlow.Scripts.Pause;
using _DontGlow.Scripts.ScriptableObj;
using Cysharp.Threading.Tasks;
using Zenject;

namespace _DontGlow.Scripts.Flashlight
{
    public class RunningLowFlashlight : IInitializable, IDisposable, IPausable
    {
        public event Action<int> DivisionChanged;
        
        private readonly FlashlightConfig _flashlightConfig;
        private readonly CancellationTokenSource _cts = new ();
        private readonly CounterBattery _counterBattery;
        private readonly FlashlightView _flashlightView;
        
        private bool _isPause;
        private float _time;
        private bool _isOn = true;

        public RunningLowFlashlight(FlashlightConfig flashlightConfig,
                                    CounterBattery counterBattery,
                                    FlashlightView flashlightView)
        {
            _flashlightConfig = flashlightConfig;
            _counterBattery = counterBattery;
            _flashlightView = flashlightView;
        }

        public int CurrentCountDivision { get; private set; }
        
        public void Initialize()
        {
            ChargeFull();
            StartCount();
        }
        
        public void Dispose()
        {
            _cts.Cancel();
            _cts.Dispose();
        }

        public void Stop()
            => _isPause = true;

        public void Continue()
        {
            _isPause = false;
            StartCount();
        }

        public void OffButton()
        {
            _isOn = false;
            _flashlightView.Flashlight.enabled = false;
        } 

        public void OnButton()
        {
            _isOn = true;
            StartCount();
        }

        private void ChargeFull()
        {
            CurrentCountDivision = FlashlightConfig.CountDivision;
            DivisionChanged?.Invoke(CurrentCountDivision);
        } 

        private void StartCount()
            => Count().Forget();
        
        private async UniTask Count()
        {
            if (IsCount())
                _flashlightView.Flashlight.enabled = true;
            
            while (IsCount())
            {
                _time += UnityEngine.Time.deltaTime;

                if (_time >= _flashlightConfig.TimeOneDivisionSec)
                {
                    _time = 0;
                    
                    CurrentCountDivision--;

                    if (CurrentCountDivision <= 0)
                    {
                        if (_counterBattery.Count > 0)
                        {
                            ChargeFull();
                            _counterBattery.Subtract();
                        }
                        else
                        {
                            _flashlightView.Flashlight.enabled = false;
                            DivisionChanged?.Invoke(CurrentCountDivision);
                        }
                    }
                    else
                    {
                        DivisionChanged?.Invoke(CurrentCountDivision);
                    }
                }
                
                await UniTask.NextFrame(_cts.Token);
            }
        }

        private bool IsCount()
            => !_isPause && !_cts.IsCancellationRequested && CurrentCountDivision > 0 && _isOn;
    }
}
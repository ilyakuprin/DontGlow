using System;
using _DontGlow.Scripts.MainHero;
using _DontGlow.Scripts.Timer;
using Unity.VisualScripting;
using YG;

namespace _DontGlow.Scripts.Saves
{
    public class TimeSaves : IInitializable, IDisposable
    {
        private readonly TimeCounter _timeCounter;
        private readonly PickingUpItems _pickingUpItems;

        public TimeSaves(TimeCounter timeCounter,
                         PickingUpItems pickingUpItems)
        {
            _timeCounter = timeCounter;
            _pickingUpItems = pickingUpItems;
        }

        public void Initialize()
            => _pickingUpItems.TakenDoorExit += Save;

        public void Dispose()
            => _pickingUpItems.TakenDoorExit -= Save;

        private void Save()
            => YandexGame.savesData.BestTimeInSec = _timeCounter.Time;
    }
}
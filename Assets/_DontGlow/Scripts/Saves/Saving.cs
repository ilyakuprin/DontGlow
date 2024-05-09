using System;
using YG;
using Zenject;

namespace _DontGlow.Scripts.Saves
{
    public class Saving : IInitializable, IDisposable
    {
        public event Action SaveDataReceived;

        public void Initialize()
        {
            DataReceived();
            YandexGame.GetDataEvent += DataReceived;
        }

        public void Save()
            => YandexGame.SaveProgress();

        public void DataReceived()
            => SaveDataReceived?.Invoke();

        public void Dispose()
        {
            YandexGame.GetDataEvent -= DataReceived;
        }
    }
}
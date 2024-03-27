using System;
using _DontGlow.Scripts.Pause;
using Zenject;

namespace _DontGlow.Scripts.Inputting
{
    public abstract class PlayerInput : ITickable, IPausable
    {
        public event Action<InputData> Inputted;
        private InputData _inputData;
        private bool _isPause;

        public void Continue()
            => _isPause = false;

        public void Stop()
            => _isPause = true;

        public void Tick()
        {
            if (_isPause) return;

            _inputData = GetInputData();
            
            Inputted?.Invoke(_inputData);
        }

        protected abstract InputData GetInputData();
    }
}

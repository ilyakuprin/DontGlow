using System;
using _DontGlow.Scripts.StringValues;
using UnityEngine;
using Zenject;

namespace _DontGlow.Scripts.Inputting
{
    public class PlayerInput : ITickable
    {
        public event Action<InputData> Inputted;
        private InputData _inputData;
        private bool _isPause;

        public void Tick()
        {
            if (_isPause) return;

            _inputData = new InputData()
            {
                Direction = new Vector2(Input.GetAxisRaw(InputName.Horizontal),
                                        Input.GetAxisRaw(InputName.Vertical))
            };

            Inputted?.Invoke(_inputData);
        }

        public void SetPause(bool value)
            => _isPause = value;
    }
}

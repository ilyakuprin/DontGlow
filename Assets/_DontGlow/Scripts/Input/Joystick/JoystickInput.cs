using Zenject;

namespace _DontGlow.Scripts.Inputting
{
    public class JoystickInput : PlayerInput, IInitializable
    {
        private readonly JoystickHandler _joystickHandler;

        public JoystickInput(JoystickHandler joystickHandler)
        {
            _joystickHandler = joystickHandler;
        }

        public void Initialize()
        {
            _joystickHandler.gameObject.SetActive(true);
        }

        protected override InputData GetInputData()
        {
            var inputData = new InputData()
            {
                Direction = _joystickHandler.GetInputVector
            };
            
            return inputData;
        }
    }
}
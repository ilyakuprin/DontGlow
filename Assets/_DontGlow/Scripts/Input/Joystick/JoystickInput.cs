namespace _DontGlow.Scripts.Inputting
{
    public class JoystickInput : PlayerInput
    {
        private readonly JoystickHandler _joystickHandler;

        public JoystickInput(JoystickHandler joystickHandler)
        {
            _joystickHandler = joystickHandler;
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
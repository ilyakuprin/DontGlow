using _DontGlow.Scripts.StringValues;
using UnityEngine;

namespace _DontGlow.Scripts.Inputting
{
    public class KeyboardInput : PlayerInput
    {
        protected override InputData GetInputData()
        {
            var inputData = new InputData()
            {
                Direction = new Vector2(Input.GetAxisRaw(InputName.Horizontal),
                                        Input.GetAxisRaw(InputName.Vertical))
            };

            return inputData;
        }
    }
}
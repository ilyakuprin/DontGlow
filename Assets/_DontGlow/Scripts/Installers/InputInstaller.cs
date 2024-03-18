using System.Linq;
using _DontGlow.Scripts.Inputting;
using UnityEngine;
using Zenject;

namespace _DontGlow.Scripts.Installers
{
    public class InputInstaller : MonoInstaller
    {
        [SerializeField] private JoystickHandler _joystickHandler;
        
        public override void InstallBindings()
        {
            if (SystemInfo.deviceType == DeviceType.Handheld)
            {
                Container.Bind<JoystickHandler>().FromInstance(_joystickHandler).AsSingle();
                
                Container.Bind(new[] { typeof(PlayerInput) }.Concat(typeof(JoystickInput).GetInterfaces()))
                    .To<JoystickInput>().AsSingle();
            }
            else
            {
                Container.Bind(new[] { typeof(PlayerInput) }.Concat(typeof(KeyboardInput).GetInterfaces()))
                    .To<KeyboardInput>().AsSingle();
            }
        }
    }
}
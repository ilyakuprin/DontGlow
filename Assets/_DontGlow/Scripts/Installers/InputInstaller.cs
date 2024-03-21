using System.Linq;
using _DontGlow.Scripts.Inputting;
using UnityEngine;
using Zenject;

namespace _DontGlow.Scripts.Installers
{
    public class InputInstaller : MonoInstaller
    {
        [SerializeField] private JoystickHandler _joystickHandler;
        [SerializeField] private CanvasInputView _canvasInputView;
        
        public override void InstallBindings()
        {
            if (SystemInfo.deviceType == DeviceType.Handheld)
            {
                Container.Bind<JoystickHandler>().FromInstance(_joystickHandler).AsSingle();
                Container.Bind<CanvasInputView>().FromInstance(_canvasInputView).AsSingle();
                
                Container.Bind(new[] { typeof(PlayerInput) }.Concat(typeof(JoystickInput).GetInterfaces()))
                    .To<JoystickInput>().AsSingle();

                Container.BindInterfacesAndSelfTo<ActivatingCanvasInput>().AsSingle();
            }
            else
            {
                Container.Bind(new[] { typeof(PlayerInput) }.Concat(typeof(KeyboardInput).GetInterfaces()))
                    .To<KeyboardInput>().AsSingle();
            }
        }
    }
}
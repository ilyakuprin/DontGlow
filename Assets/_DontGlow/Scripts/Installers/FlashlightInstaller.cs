using _DontGlow.Scripts.Flashlight;
using _DontGlow.Scripts.ScriptableObj;
using _DontGlow.Scripts.UI;
using UnityEngine;
using Zenject;

namespace _DontGlow.Scripts.Installers
{
    public class FlashlightInstaller : MonoInstaller
    {
        [SerializeField] private FlashlightConfig _flashlightConfig;
        [SerializeField] private FlashlightView _flashlightView;
        
        public override void InstallBindings()
        {
            Container.Bind<FlashlightConfig>().FromInstance(_flashlightConfig).AsSingle();
            Container.Bind<FlashlightView>().FromInstance(_flashlightView).AsSingle();

            Container.BindInterfacesAndSelfTo<RunningLowFlashlight>().AsSingle();
            Container.BindInterfacesAndSelfTo<OnOffButton>().AsSingle();
            Container.BindInterfacesAndSelfTo<ShowingCountDivisionFlashlight>().AsSingle();
            Container.BindInterfacesAndSelfTo<ChargingChargedFlashlight>().AsSingle();
            Container.BindInterfacesAndSelfTo<FlashlightOnOffSwitch>().AsSingle();
        }
    }
}
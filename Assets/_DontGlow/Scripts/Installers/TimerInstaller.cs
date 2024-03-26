using _DontGlow.Scripts.Timer;
using UnityEngine;
using Zenject;

namespace _DontGlow.Scripts.Installers
{
    public class TimerInstaller : MonoInstaller
    {
        [SerializeField] private TimerView _timerView;
        
        public override void InstallBindings()
        {
            Container.Bind<TimerView>().FromInstance(_timerView).AsSingle();
            
            Container.BindInterfacesAndSelfTo<TimeCounter>().AsSingle();
            Container.BindInterfacesAndSelfTo<TimeDisplaying>().AsSingle();
        }
    }
}
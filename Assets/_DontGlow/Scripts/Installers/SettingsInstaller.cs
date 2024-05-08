using _DontGlow.Scripts.UI.Pause;
using UnityEngine;
using Zenject;

namespace _DontGlow.Scripts.Installers
{
    public class SettingsInstaller : MonoInstaller
    {
        [SerializeField] private SettingsView _settingsView;
        
        public override void InstallBindings()
        {
            Container.Bind<SettingsView>().FromInstance(_settingsView).AsSingle();
            
            Container.BindInterfacesAndSelfTo<ShowingSettings>().AsSingle();
        }
    }
}
using _DontGlow.Scripts.Saves;
using _DontGlow.Scripts.UI.Sound;
using UnityEngine;
using Zenject;

namespace _DontGlow.Scripts.Installers
{
    public class SavingInMenu : MonoInstaller
    {
        [SerializeField] private SettingsView _settingsView;
        
        public override void InstallBindings()
        {
            Container.Bind<SettingsView>().FromInstance(_settingsView).AsSingle();
            
            Container.BindInterfacesAndSelfTo<Saving>().AsSingle();
            Container.BindInterfacesAndSelfTo<LanguageSaves>().AsSingle();
            Container.BindInterfacesAndSelfTo<SoundSettings>().AsSingle();
        }
    }
}
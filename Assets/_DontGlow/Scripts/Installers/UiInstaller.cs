using _DontGlow.Scripts.Pause;
using _DontGlow.Scripts.UI.Game;
using _DontGlow.Scripts.UI.Pause;
using UnityEngine;
using Zenject;

namespace _DontGlow.Scripts.Installers
{
    public class UiInstaller : MonoInstaller
    {
        [SerializeField] private UiInGameView _uiInGameView;
        [SerializeField] private UiPauseView _uiPauseView;
        
        public override void InstallBindings()
        {
            InstallGameUI();
            InstallPauseUI();
        }

        private void InstallGameUI()
        {
            Container.Bind<UiInGameView>().FromInstance(_uiInGameView).AsSingle();
            
            Container.BindInterfacesAndSelfTo<ShowingCountNote>().AsSingle();
            Container.BindInterfacesAndSelfTo<ShowingKey>().AsSingle();
            Container.BindInterfacesAndSelfTo<ShowingCountTrap>().AsSingle();
            Container.BindInterfacesAndSelfTo<ShowingCountBattery>().AsSingle();
            Container.BindInterfacesAndSelfTo<SwitchOnOffButton>().AsSingle();
        }

        private void InstallPauseUI()
        {
            Container.Bind<UiPauseView>().FromInstance(_uiPauseView).AsSingle();
            
            Container.BindInterfacesAndSelfTo<FadingDefeatCanvas>().AsSingle();
            Container.BindInterfacesAndSelfTo<ShowingDefeat>().AsSingle();
            Container.BindInterfacesAndSelfTo<SettingPause>().AsSingle();
            Container.BindInterfacesAndSelfTo<ShowingVictory>().AsSingle();
            Container.BindInterfacesAndSelfTo<FadingVictoryCanvas>().AsSingle();
        }
    }
}
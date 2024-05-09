using _DontGlow.Scripts.Pause;
using _DontGlow.Scripts.ScriptableObj;
using _DontGlow.Scripts.UI.Game;
using _DontGlow.Scripts.UI.GameStatus;
using _DontGlow.Scripts.UI.HeroUi;
using _DontGlow.Scripts.UI.Sound;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace _DontGlow.Scripts.Installers
{
    public class UiInstaller : MonoInstaller
    {
        [SerializeField] private UiInGameView _uiInGameView;
        [SerializeField] private UiPauseView _uiPauseView;
        [SerializeField] private HeroUiView _heroUiView;
        [SerializeField] private HeroTextConfig _heroTextConfig;
        [FormerlySerializedAs("_soundView")] [SerializeField] private SettingsView settingsView;
        
        public override void InstallBindings()
        {
            InstallGameUI();
            InstallPauseUI();
            InstallHeroUI();
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
            Container.Bind<SettingsView>().FromInstance(settingsView).AsSingle();
            
            Container.BindInterfacesAndSelfTo<FadingDefeatCanvas>().AsSingle();
            Container.BindInterfacesAndSelfTo<ShowingDefeat>().AsSingle();
            Container.BindInterfacesAndSelfTo<SettingPause>().AsSingle();
            Container.BindInterfacesAndSelfTo<ShowingVictory>().AsSingle();
            Container.BindInterfacesAndSelfTo<FadingVictoryCanvas>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingMenu>().AsSingle();
            Container.BindInterfacesAndSelfTo<SoundSettings>().AsSingle();
        }

        private void InstallHeroUI()
        {
            Container.Bind<HeroUiView>().FromInstance(_heroUiView).AsSingle();
            Container.Bind<HeroTextConfig>().FromInstance(_heroTextConfig).AsSingle();
            
            Container.BindInterfacesAndSelfTo<FadingTextHeroUi>().AsSingle();
            Container.BindInterfacesAndSelfTo<CreatingSequenceText>().AsSingle();
            Container.BindInterfacesAndSelfTo<ChangeText>().AsSingle();
        }
    }
}
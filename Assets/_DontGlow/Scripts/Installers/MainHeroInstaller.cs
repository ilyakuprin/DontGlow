using _DontGlow.Scripts.MainHero;
using _DontGlow.Scripts.ScriptableObj;
using UnityEngine;
using Zenject;

namespace _DontGlow.Scripts.Installers
{
    public class MainHeroInstaller : MonoInstaller
    {
        [SerializeField] private MainHeroConfig _mainHeroConfig;
        [SerializeField] private MainHeroView _mainHeroView;
        
        public override void InstallBindings()
        {
            Container.Bind<MainHeroConfig>().FromInstance(_mainHeroConfig).AsSingle();
            Container.Bind<MainHeroView>().FromInstance(_mainHeroView).AsSingle();

            Container.BindInterfacesAndSelfTo<Movement>().AsSingle();
            Container.BindInterfacesAndSelfTo<MovementAnim>().AsSingle();
        }
    }
}
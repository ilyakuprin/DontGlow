using _DontGlow.Scripts.UI;
using UnityEngine;
using Zenject;

namespace _DontGlow.Scripts.Installers
{
    public class UiInstaller : MonoInstaller
    {
        [SerializeField] private UiInGameView _uiInGameView;
        
        public override void InstallBindings()
        {
            Container.Bind<UiInGameView>().FromInstance(_uiInGameView).AsSingle();
            
            Container.BindInterfacesAndSelfTo<AddingNote>().AsSingle();
        }
    }
}
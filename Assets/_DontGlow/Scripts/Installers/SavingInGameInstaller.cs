using _DontGlow.Scripts.Saves;
using Zenject;

namespace _DontGlow.Scripts.Installers
{
    public class SavingInGameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Saving>().AsSingle();
            Container.BindInterfacesAndSelfTo<TimeSaves>().AsSingle();
            Container.BindInterfacesAndSelfTo<LanguageSaves>().AsSingle();
        }
    }
}
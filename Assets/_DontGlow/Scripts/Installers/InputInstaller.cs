using _DontGlow.Scripts.Inputting;
using Zenject;

namespace _DontGlow.Scripts.Installers
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerInput>().AsSingle();
        }
    }
}
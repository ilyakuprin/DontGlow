using _DontGlow.Scripts.Enemy;
using UnityEngine;
using Zenject;

namespace _DontGlow.Scripts.Installers
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private EnemyView _enemyView;
        
        public override void InstallBindings()
        {
            Container.Bind<EnemyView>().FromInstance(_enemyView).AsSingle();

            Container.BindInterfacesAndSelfTo<EnemyMovement>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyRotation>().AsSingle();
        }
    }
}
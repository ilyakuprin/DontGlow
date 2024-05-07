using _DontGlow.Scripts.Enemy;
using _DontGlow.Scripts.Enemy.Audio;
using _DontGlow.Scripts.Enemy.Trap;
using _DontGlow.Scripts.ScriptableObj;
using UnityEngine;
using Zenject;

namespace _DontGlow.Scripts.Installers
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private EnemyView _enemyView;
        [SerializeField] private EnemyConfig _enemyConfig;
        [SerializeField] private InteractingWithTrap _interactingWithTrap;
        
        public override void InstallBindings()
        {
            Container.Bind<EnemyView>().FromInstance(_enemyView).AsSingle();
            Container.Bind<EnemyConfig>().FromInstance(_enemyConfig).AsSingle();
            Container.Bind<InteractingWithTrap>().FromInstance(_interactingWithTrap).AsSingle();

            Container.BindInterfacesAndSelfTo<EnemyMovement>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyRotation>().AsSingle();
            Container.BindInterfacesAndSelfTo<DiscoveringMainHero>().AsSingle();
            Container.BindInterfacesAndSelfTo<FollowingMainHero>().AsSingle();
            Container.BindInterfacesAndSelfTo<KillingMainHero>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemySettingSpeed>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyCalculationSpeed>().AsSingle();
            Container.BindInterfacesAndSelfTo<TimerStayingInTrap>().AsSingle();
            Container.BindInterfacesAndSelfTo<TurningOnHuntingSound>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayingMonsterSound>().AsSingle();
        }
    }
}
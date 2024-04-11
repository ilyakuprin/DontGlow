using _DontGlow.Scripts.Objects;
using _DontGlow.Scripts.ScriptableObj;
using UnityEngine;
using Zenject;

namespace _DontGlow.Scripts.Installers
{
    public class ObjectsInstaller : MonoInstaller
    {
        [SerializeField] private SpawningObjectsView _spawningObjectsView;
        [SerializeField] private ObjectsConfig _objectsConfig;
        
        public override void InstallBindings()
        {
            Container.Bind<SpawningObjectsView>().FromInstance(_spawningObjectsView).AsSingle();
            Container.Bind<ObjectsConfig>().FromInstance(_objectsConfig).AsSingle();

            Container.BindInterfacesAndSelfTo<CreatingSequenceNotes>().AsSingle();
            Container.BindInterfacesAndSelfTo<CreatingObjects>().AsSingle();
        }
    }
}
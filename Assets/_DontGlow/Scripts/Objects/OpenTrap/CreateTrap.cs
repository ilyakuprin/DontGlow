using System;
using _DontGlow.Scripts.MainHero;
using Zenject;

namespace _DontGlow.Scripts.Objects.OpenTrap
{
    public class CreateTrap : IInitializable, IDisposable
    {
        private readonly SpawningObjectsView _spawningObjectsView;
        private readonly MainHeroView _mainHeroView;
        private readonly CounterTrap _counterTrap;

        public CreateTrap(SpawningObjectsView spawningObjectsView,
                          MainHeroView mainHeroView,
                          CounterTrap counterTrap)
        {
            _spawningObjectsView = spawningObjectsView;
            _mainHeroView = mainHeroView;
            _counterTrap = counterTrap;
        }

        public void Initialize()
            => _counterTrap.Reduced += Create;

        public void Dispose()
            => _counterTrap.Reduced -= Create;

        private void Create()
        {
            for (var i = 0; i < _spawningObjectsView.LengthTrap; i++)
            {
                var trap = _spawningObjectsView.GetTrap(i);

                if (trap.activeSelf) continue;
                
                trap.SetActive(true);
                trap.transform.position = _mainHeroView.Rigidbody.transform.position;
                return;
            }
        }
    }
}
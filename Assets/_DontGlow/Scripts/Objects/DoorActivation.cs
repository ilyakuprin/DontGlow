using System;
using _DontGlow.Scripts.MainHero;
using Zenject;

namespace _DontGlow.Scripts.Objects
{
    public class DoorActivation : IInitializable, IDisposable
    {
        private readonly SpawningObjectsView _spawningObjectsView;
        private readonly PickingUpItems _pickingUpItems;

        public DoorActivation(SpawningObjectsView spawningObjectsView,
                              PickingUpItems pickingUpItems)
        {
            _spawningObjectsView = spawningObjectsView;
            _pickingUpItems = pickingUpItems;
        }

        public void Initialize() 
            => _pickingUpItems.TakenKey += Activate;

        public void Dispose()
            => _pickingUpItems.TakenKey -= Activate;

        private void Activate()
            => _spawningObjectsView.Door.SetActive(true);
    }
}
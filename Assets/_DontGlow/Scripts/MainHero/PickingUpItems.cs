using System;
using System.Threading;
using _DontGlow.Scripts.StringValues;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;
using UnityEngine;
using Zenject;

namespace _DontGlow.Scripts.MainHero
{
    public class PickingUpItems : IInitializable
    {
        public event Action TakenBattery;
        public event Action TakenTrap;
        public event Action TakenNote;
        public event Action TakenKey;
        public event Action TakenDoorExit;
        
        private readonly MainHeroView _mainHeroView;
        
        private AsyncTriggerEnter2DTrigger _trigger;
        private CancellationToken _ct;

        public PickingUpItems(MainHeroView mainHeroView)
        {
            _mainHeroView = mainHeroView;
        }
        
        public void Initialize()
        {
            _trigger = _mainHeroView.FullCollider.GetAsyncTriggerEnter2DTrigger();
            _ct = _mainHeroView.FullCollider.GetCancellationTokenOnDestroy();
            
            Detect().Forget();
        }

        private async UniTaskVoid Detect()
        {
            while (!_ct.IsCancellationRequested)
            {
                var uniTask = _trigger.OnTriggerEnter2DAsync(_ct);
                await uniTask;
                InvokeEvent(uniTask.GetAwaiter().GetResult().gameObject);
            }
        }
        
        private void InvokeEvent(GameObject gameObj)
        {
            switch (gameObj.tag)
            {
                case TagName.Battery:
                    TakenBattery?.Invoke();
                    gameObj.SetActive(false);
                    break;
                case TagName.Trap:
                    TakenTrap?.Invoke();
                    gameObj.SetActive(false);
                    break;
                case TagName.Note:
                    TakenNote?.Invoke();
                    gameObj.SetActive(false);
                    break;
                case TagName.Key:
                    TakenKey?.Invoke();
                    gameObj.SetActive(false);
                    break;
                case TagName.Exit:
                    TakenDoorExit?.Invoke();
                    break;
            }
        }
    }
}
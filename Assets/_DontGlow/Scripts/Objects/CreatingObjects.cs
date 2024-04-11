using System;
using System.Collections.Generic;
using _DontGlow.Scripts.MainHero;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace _DontGlow.Scripts.Objects
{
    public class CreatingObjects : IInitializable, IDisposable
    {
        private readonly CreatingSequenceNotes _creatingSequenceNotes;
        private readonly SpawningObjectsView _spawningObjectsView;
        private readonly PickingUpItems _pickingUpItems;

        private List<int> _indexesPools;
        private int _counterObject;
        private int _indexPoolObj1 = -1;
        private int _indexPoolObj2 = -1;
        private int _indexPool;

        public CreatingObjects(CreatingSequenceNotes creatingSequenceNotes,
                               SpawningObjectsView spawningObjectsView,
                               PickingUpItems pickingUpItems)
        {
            _creatingSequenceNotes = creatingSequenceNotes;
            _spawningObjectsView = spawningObjectsView;
            _pickingUpItems = pickingUpItems;
        }

        public void Initialize()
        {
            FillPool();
            Create();

            _pickingUpItems.TakenNote += Create;
        }

        public void Dispose()
        {
            _pickingUpItems.TakenNote -= Create;
        }

        private void FillPool()
        {
            _indexesPools = new List<int>(_spawningObjectsView.LengthPools);

            for (var i = 0; i < _spawningObjectsView.LengthPools; i++)
            {
                _indexesPools.Add(i);
            }
        }

        private void Create()
        {
            if (_counterObject < _creatingSequenceNotes.Length)
            {
                var objs = GetObjs();
                SetPosition(objs.transform);
                ActivateObjs(objs);
                _counterObject++;
            }
            else
            {
                _spawningObjectsView.Key.transform.position = GetPosition();
                _spawningObjectsView.Key.SetActive(true);
            }
        }

        private void SetPosition(Transform objs)
        {
            objs.position = GetPosition();

            if (IsEvenIndex())
            {
                AddIndex(ref _indexPoolObj1);
            }
            else
            {
                AddIndex(ref _indexPoolObj2);
            }
        }

        private Vector3 GetPosition()
        {
            var randomIndex = Random.Range(0, _indexesPools.Count);
            _indexPool = _indexesPools[randomIndex];
            var pool = _spawningObjectsView.GetPool(_indexPool);
            var indexChild = Random.Range(0, pool.childCount);
            _indexesPools.RemoveAt(randomIndex);
            
            return pool.GetChild(indexChild).position;
        }

        private ObjectsView GetObjs()
            => IsEvenIndex() ? _spawningObjectsView.Objects1 : _spawningObjectsView.Objects2;

        private void AddIndex(ref int indexPoolObj)
        {
            if (indexPoolObj >= 0)
                _indexesPools.Add(indexPoolObj);
            
            indexPoolObj = _indexPool;
        }

        private bool IsEvenIndex()
            => _counterObject % 2 == 0;

        private void ActivateObjs(ObjectsView objs)
        {
            objs.Note.sprite = _creatingSequenceNotes.GetNote(_counterObject);
            objs.Note.gameObject.SetActive(true);
            objs.Battery.SetActive(true);
            objs.Junk.SetActive(true);
        }
    }
}
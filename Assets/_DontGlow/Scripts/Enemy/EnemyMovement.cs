using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using Zenject;
using Random = UnityEngine.Random;

namespace _DontGlow.Scripts.Enemy
{
    public class EnemyMovement : IInitializable
    {
        private const int CountFrameWait = 10;
        
        private readonly NavMeshAgent _agent;

        private NavMeshTriangulation _navMeshData;
        private CancellationToken _ct;

        public EnemyMovement(EnemyView enemyView)
        {
            _agent = enemyView.Agent;
        }

        public void Initialize()
        {
            _agent.updateRotation = false;
            _agent.updateUpAxis = false;
            
            _navMeshData = NavMesh.CalculateTriangulation();
            _ct = _agent.GetCancellationTokenOnDestroy();
            MoveToPoint();
        }

        private void MoveToPoint()
        {
            _agent.SetDestination(GetRandomPointNavMesh());
            WaitReachPath().Forget();
        }

        private async UniTask WaitReachPath()
        {
            while (!_agent.hasPath)
                await UniTask.DelayFrame(CountFrameWait, PlayerLoopTiming.Update, _ct);
            
            while (_agent.hasPath)
                await UniTask.DelayFrame(CountFrameWait, PlayerLoopTiming.Update, _ct);

            MoveToPoint();
        }

        private Vector3 GetRandomPointNavMesh()
        {
            //3 - number of triangle vertices.
            var triangle = Random.Range(0, _navMeshData.indices.Length - 3);
            var point = _navMeshData.vertices[_navMeshData.indices[triangle]];

            //Random point between vertices.
            point = Vector3.Lerp(point, _navMeshData.vertices[_navMeshData.indices[triangle + 1]], Random.value);
            point = Vector3.Lerp(point, _navMeshData.vertices[_navMeshData.indices[triangle + 2]], Random.value);

            return point;
        }
    }
}
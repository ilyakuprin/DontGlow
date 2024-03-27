using UnityEngine;
using UnityEngine.AI;

namespace _DontGlow.Scripts.Enemy
{
    public class GettingRandomPositionNavMesh
    {
        private NavMeshTriangulation _navMeshData;

        public void Init()
            => _navMeshData = NavMesh.CalculateTriangulation();

        public Vector3 Get()
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
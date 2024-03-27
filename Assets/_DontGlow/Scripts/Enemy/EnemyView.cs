using Spine.Unity;
using UnityEngine;
using UnityEngine.AI;

namespace _DontGlow.Scripts.Enemy
{
    public class EnemyView : MonoBehaviour
    {
        [field: SerializeField] public NavMeshAgent Agent { get; private set; }
        [field: SerializeField] public SkeletonAnimation SpineAnim { get; private set; }
        [field: SerializeField] public Transform Eyes { get; private set; }
        [field: SerializeField] public Transform AttackCollider { get; private set; }
    }
}

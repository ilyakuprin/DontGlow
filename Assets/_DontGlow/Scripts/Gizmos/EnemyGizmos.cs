using _DontGlow.Scripts.Enemy;
using _DontGlow.Scripts.MainHero;
using _DontGlow.Scripts.ScriptableObj;
using UnityEngine;

#if UNITY_EDITOR
namespace _DontGlow.Scripts.Gizmos
{
    public class EnemyGizmos : MonoBehaviour
    {
        [SerializeField] private EnemyView _enemyView;
        [SerializeField] private EnemyConfig _enemyConfig;
        [SerializeField] private MainHeroView _mainHeroView;

        private void OnDrawGizmos()
        {
            LineSightCircle();
            LineSightRay();
            AttackCircle();
        }

        private void LineSightCircle()
        {
            UnityEngine.Gizmos.color = Color.blue;
            UnityEngine.Gizmos.DrawWireSphere(_enemyView.Eyes.position, _enemyConfig.RadiusLineSight);
        }

        private void LineSightRay()
        {
            var positionEyes = _enemyView.Eyes.position;
            var direction = (_mainHeroView.Rigidbody.transform.position - positionEyes);
            
            UnityEngine.Gizmos.color = Color.red;
            UnityEngine.Gizmos.DrawRay(positionEyes,direction.normalized * _enemyConfig.RadiusLineSight);
        }

        private void AttackCircle()
        {
            UnityEngine.Gizmos.color = Color.green;
            UnityEngine.Gizmos.DrawWireSphere(_enemyView.AttackCollider.position, _enemyConfig.RadiusColliderAttack);
        }
    }
}
#endif

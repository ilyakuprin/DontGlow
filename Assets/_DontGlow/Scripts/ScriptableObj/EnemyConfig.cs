using System;
using UnityEngine;

namespace _DontGlow.Scripts.ScriptableObj
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [field: SerializeField, Range(1f, 20f)] public float RadiusLineSight { get; private set; }
        [field: SerializeField, Range(1f, 20f)] public float RadiusColliderAttack { get; private set; }
        [field: SerializeField, Range(1f, 10f)] public float PatrolSpeed { get; private set; }
        [field: SerializeField, Range(1f, 10f)] public float HuntingSpeed { get; private set; }
        [field: SerializeField, Range(0f, 1f)] public float SpeedMultiplier { get; private set; }
        [field: SerializeField, Range(1f, 50f)] public float StandingTimeTrappedInSec { get; private set; }
        
        
        [field: Space, SerializeField, Range(10f, 180f)] public float MinRandomTimeAudioInSec { get; private set; }
        [field: SerializeField, Range(10f, 180f)] public float MaxRandomTimeAudioInSec { get; private set; }
        [field: SerializeField] public AudioClip PreRun { get; private set; }
        [field: SerializeField] public AudioClip Run { get; private set; }
        [field: SerializeField] public AudioClip Walking { get; private set; }

        private void OnValidate()
        {
            if (MinRandomTimeAudioInSec > MaxRandomTimeAudioInSec)
                MinRandomTimeAudioInSec = MaxRandomTimeAudioInSec;
        }
    }
}
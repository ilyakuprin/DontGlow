using UnityEngine;

namespace _DontGlow.Scripts.StringValues
{
    public class AnimName
    {
        private const string NameMove = "Move";
        
        public int Move => Animator.StringToHash(NameMove);
    }
}
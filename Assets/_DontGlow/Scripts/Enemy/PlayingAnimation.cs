using _DontGlow.Scripts.Pause;
using Spine.Unity;

namespace _DontGlow.Scripts.Enemy
{
    public class PlayingAnimation : IPausable
    {
        private readonly SkeletonAnimation _animation;

        public PlayingAnimation(EnemyView enemyView)
        {
            _animation = enemyView.SpineAnim;
        }

        public void Stop()
            => _animation.AnimationName = "idle";

        public void Continue()
            => _animation.AnimationName = "move";
    }
}
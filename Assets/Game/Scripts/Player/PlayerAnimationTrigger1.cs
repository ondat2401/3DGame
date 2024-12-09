using UnityEngine;
namespace AnimationTrigger
{
    public class PlayerAnimationTrigger : MonoBehaviour
    {
        private Player player => GetComponentInParent<Player>();
        private void AnimationTrigger()
        {
            player.AnimationTrigger();
        }
        private void SlideStartTrigger()
        {
            player.SlideStartTrigger();
        }
        private void SlideEndTrigger()
        {
            player.SlideEndTrigger();
        }
    }
}

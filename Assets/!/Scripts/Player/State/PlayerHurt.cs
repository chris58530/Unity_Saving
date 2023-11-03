using UnityHFSM;

namespace _.Scripts.Player.State
{
    public class PlayerHurt : StateBase<PlayerState>
    {
        public PlayerHurt(bool needsExitTime, bool isGhostState = false) : base(needsExitTime, isGhostState)
        {
        }   public override void OnEnter()
        {
            AudioManager.Instance.PlaySFX("Injured");
        }

        public override void OnLogic()
        {
        }

        public override void OnExit()
        {
        }
    }
}
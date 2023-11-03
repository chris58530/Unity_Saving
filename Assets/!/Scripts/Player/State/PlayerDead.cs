using UnityHFSM;

namespace _.Scripts.Player.State
{
    public class PlayerDead : StateBase<PlayerState>
    {
        public PlayerDead(bool needsExitTime, bool isGhostState = false) : base(needsExitTime, isGhostState)
        {
        }   public override void OnEnter()
        {
            AudioManager.Instance.PlaySFX("Die");
        }

        public override void OnLogic()
        {
        }

        public override void OnExit()
        {
        }
    }
}
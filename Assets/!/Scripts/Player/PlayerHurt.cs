using UnityHFSM;

namespace _.Scripts.Player
{
    public class PlayerHurt : StateBase<PlayerState>
    {
        public PlayerHurt(bool needsExitTime, bool isGhostState = false) : base(needsExitTime, isGhostState)
        {
        }   public override void OnEnter()
        {
        }

        public override void OnLogic()
        {
        }

        public override void OnExit()
        {
        }
    }
}
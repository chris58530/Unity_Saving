using UnityEngine;
using UnityHFSM;

namespace _.Scripts.Player
{
    public class PlayerPull : StateBase<PlayerState>
    {
        public PlayerPull(bool needsExitTime, bool isGhostState = false) : base(needsExitTime, isGhostState)
        {
        }

        public override void OnEnter()
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
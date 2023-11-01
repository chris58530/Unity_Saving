using UnityEngine;
using UnityHFSM;

namespace _.Scripts.Player.State
{
    public class PlayerDash : StateBase<PlayerState>
    {
        private readonly PlayerController _controller;
        private Timer _timer;

        public PlayerDash(PlayerController controller, bool needsExitTime, bool isGhostState = false) : base(
            needsExitTime, isGhostState)
        {
            _controller = controller;
        }

        public override void OnEnter()
        {
            _timer = new Timer();

            _controller.Dash();
        }

        public override void OnLogic()
        {
            if (_timer.Elapsed > _controller.dashTime)
                fsm.StateCanExit();
        }

        public override void OnExit()
        {
            Debug.Log("exit dash");
        }
    }
}
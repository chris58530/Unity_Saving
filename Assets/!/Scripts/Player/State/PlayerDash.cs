using UnityEngine;
using UnityHFSM;

namespace _.Scripts.Player.State
{
    public class PlayerDash : StateBase<PlayerState>
    {
        private readonly PlayerController _controller;
        private Timer _timer;
        private Animator _animator;
        public PlayerDash(PlayerController controller, 
            Animator animator,
            bool needsExitTime, bool isGhostState = false) : base(
            needsExitTime, isGhostState)
        {
            _controller = controller;
            _animator = animator;

        }

        public override void OnEnter()
        {
            _timer = new Timer();
            _animator.Play("Dash");

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
using UnityEngine;
using UnityHFSM;

namespace _.Scripts.Player.State
{
    public class PlayerAttack : StateBase<PlayerState>
    {
        private Animator _animator;
        private readonly PlayerMapInput _input;
        private readonly PlayerController _controller;
        private Timer _timer;

        public PlayerAttack(PlayerMapInput playerMapInput,
            PlayerController playerController,
            bool needsExitTime,
            bool isGhostState = false) : base(needsExitTime, isGhostState)
        {
            _input = playerMapInput;
            _controller = playerController;
        }

        public override void OnEnter()
        {
            _timer = new Timer();

            _controller.Attack();
        }

        public override void OnLogic()
        {
            if (_timer.Elapsed > _controller.attackTime)
                fsm.StateCanExit();
        }

        public override void OnExit()
        {
        }
    }
}
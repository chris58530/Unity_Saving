using UnityEngine;
using UnityHFSM;

namespace _.Scripts.Player
{
    public class PlayerAttack : StateBase<PlayerState>
    {
        private Animator _animator;
        private readonly PlayerMapInput _input;
        private readonly PlayerController _controller;

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
            _controller.Attack();
        }

        public override void OnLogic()
        {
         
        }

        public override void OnExit()
        {
        }
    }
}
using UnityEngine;
using UnityHFSM;

namespace _.Scripts.Player
{
    public class PlayerPull : StateBase<PlayerState>
    {
        private Animator _animator;
        private readonly PlayerMapInput _input;
        private readonly PlayerController _controller;

        public PlayerPull(PlayerMapInput playerMapInput,
            PlayerController playerController,
            bool needsExitTime,
            bool isGhostState = false) : base(needsExitTime, isGhostState)
        {
            _input = playerMapInput;
            _controller = playerController;
        }

        public override void OnEnter()
        {
            Time.timeScale = 0;
        }

        public override void OnLogic()
        {
            _controller.SetPullTarget();
        }

        public override void OnExit()
        {
            Time.timeScale = 1;

            _controller.PullTarget();
        }
    }
}
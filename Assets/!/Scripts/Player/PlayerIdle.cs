using System;
using UnityEngine;
using UnityHFSM;
using UniRx;

namespace _.Scripts.Player
{
    public class PlayerIdle : StateBase<PlayerState>
    {
        private Animator _animator;
        private readonly PlayerMapInput _input;
        private readonly PlayerController _controller;

        public PlayerIdle(PlayerMapInput playerMapInput, 
            PlayerController playerController, 
            bool needsExitTime,
            bool isGhostState = false) : base(needsExitTime,
            isGhostState)
        {
            _input = playerMapInput;
            _controller = playerController;
        }

        public override void OnEnter()
        {
        }

        public override void OnLogic()
        {
            if (_input.IsPressedDash)
                _controller.ShowDashDirection(true);
        }

        public override void OnExit()
        {
            _controller.ShowDashDirection(false);

        }
    }
}
using UnityEngine;
using UnityHFSM;
using System;
using UniRx;

namespace _.Scripts.Player
{
    public class PlayerWalk : StateBase<PlayerState>
    {
        private readonly PlayerMapInput _input;
        private readonly PlayerController _controller;

        public PlayerWalk(
            PlayerMapInput playerMapInput,
            PlayerController controller,
            bool needsExitTime,
            bool isGhostState = false) : base(needsExitTime, isGhostState)
        {
            _input = playerMapInput;
            _controller = controller;
        }

        public override void OnEnter()
        {
        }

        public override void OnLogic()
        {
            Vector2 getInput = _input.MoveVector;
            Vector3 dir = new Vector3(getInput.x, 0, getInput.y);
            _controller.Move(dir);

            if (_input.IsPressedDash)
                _controller.ShowDashDirection(true);

            _controller.Fall();
        }

        public override void OnExit()
        {
            _controller.ShowDashDirection(false);
        }
    }
}
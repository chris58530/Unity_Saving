using System;
using UnityEngine;
using UnityHFSM;

namespace _.Scripts.Player.State
{
    public enum PlayerState
    {
        Idle,
        Walk,
        Attack,
        Pull,
        Dash,
        Hurt,
        Roll,
        Dead
    }

    public class PlayerStateMachine : MonoBehaviour
    {
        private StateMachine<PlayerState> _fsm;
        private PlayerMapInput _input;
        private PlayerController _controller;
        private Animator _animator;

        private void Awake()
        {
            _input = GetComponent<PlayerMapInput>();
            _controller = GetComponent<PlayerController>();
        }

        private void Start()
        {
            _fsm = new StateMachine<PlayerState>();

            //_fsm Add New State
            _fsm.AddState(
                PlayerState.Idle, new PlayerIdle(
                    _input, _controller, false));
            _fsm.AddState(
                PlayerState.Walk, new PlayerWalk(
                    _input, _controller, false));
            _fsm.AddState(
                PlayerState.Attack, new PlayerAttack(
                    _input, _controller, true));
            _fsm.AddState(
                PlayerState.Pull, new PlayerPull(
                    _input, _controller,false));
            _fsm.AddState(
                PlayerState.Dash, new PlayerDash(
                    _controller, true));
            _fsm.AddState(
                PlayerState.Hurt, new PlayerHurt(
                    false));
            _fsm.AddState(
                PlayerState.Roll, new PlayerRoll(
                    false));
            _fsm.AddState(
                PlayerState.Dead, new PlayerDead(
                    false));

            //_fsm Transition

            //Idle
            _fsm.AddTwoWayTransition(PlayerState.Idle, PlayerState.Walk,
                transition => _input.Move);
            _fsm.AddTransition(PlayerState.Idle, PlayerState.Dash,
                transition => _input.IsReleasedDash);
            _fsm.AddTransition(PlayerState.Idle, PlayerState.Pull,
                transition => _input.IsPressedPull);
            _fsm.AddTransition(PlayerState.Idle, PlayerState.Attack,
                transition => _input.IsPressedAttack);

            //Walk
            _fsm.AddTransition(PlayerState.Walk, PlayerState.Dash,
                transition => _input.IsReleasedDash);
            _fsm.AddTransition(PlayerState.Walk, PlayerState.Pull,
                transition => _input.IsPressedPull);
            _fsm.AddTransition(PlayerState.Walk, PlayerState.Attack,
                transition => _input.IsPressedAttack);

            //Dash
            _fsm.AddTransition(PlayerState.Dash, PlayerState.Idle);

            //Pull
            _fsm.AddTransition(PlayerState.Pull, PlayerState.Idle,
                transition => _input.IsReleasedPull);
            
            //Attack
            _fsm.AddTransition(PlayerState.Attack, PlayerState.Idle);
            
            //Initialize
            _fsm.Init();
        }

        private void Update()
        {
            _fsm.OnLogic();
        }
    }
}
using AnniePlaysGamesTestTask.Input;
using AnniePlaysGamesTestTask.Player.States;
using System.Collections;
using UnityEngine;

namespace AnniePlaysGamesTestTask.Player
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(PlayerStats))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] StateMachine _stateMachine;
        [SerializeField] PlayerInput _playerInput;
        public PlayerStats Stats;

        private void Start()
        {
            _playerInput._joystick.OnUseStarted.AddListener(Run);
            _playerInput._joystick.OnUseEnded.AddListener(Attack);
        }

        public void Run()
        {
            _stateMachine.SetState(State.Run);
            Debug.Log("Run");
        }

        public void Attack()
        {
            _stateMachine.SetState(State.Attack);
            Debug.Log("Attack");
        }

        public void TakeDamage()
        {

        }
    }
}

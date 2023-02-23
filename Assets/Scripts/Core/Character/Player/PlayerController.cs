using AnniePlaysGamesTestTask.Core.Character.Enemy;
using AnniePlaysGamesTestTask.Core.Character.States;
using AnniePlaysGamesTestTask.Core.Character.States.Player;
using AnniePlaysGamesTestTask.Core.Shooting;
using AnniePlaysGamesTestTask.Input;
using UnityEngine;

namespace AnniePlaysGamesTestTask.Core.Character.Player
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(PlayerStats))]
    [RequireComponent(typeof(PlayerShootingSystem))]
    public class PlayerController : CustomCharacterController, IKillable
    {
        [SerializeField] StateMachine _stateMachine;
        [SerializeField] PlayerInput _playerInput;
        [SerializeField] PlayerShootingSystem _shootingSystem;

        public override void Initialize()
        {
            base.Initialize();
            _playerInput.Joystick.OnUseStarted.AddListener(Run);
            _playerInput.Joystick.OnUseEnded.AddListener(Attack);
            _shootingSystem.OnNoEnemiesLeft.AddListener(Idle);
            _shootingSystem.OnNoEnemiesLeft.AddListener(StopCombat);
            Attack();
        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.LogWarning(collision.gameObject.name);
            EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
            if (enemy != null)
                TakeDamage(enemy.Stats.Damage);
        }

        public override void Idle()
        {
            base.Idle();
            _stateMachine.SetState(State.Idle);
        }

        public override void Run()
        {
            base.Idle();
            _stateMachine.SetState(State.Run);
        }

        public override void Attack()
        {
            base.Idle();
            _stateMachine.SetState(State.Attack);
        }

        private void StopCombat()
        {
            _playerInput.Joystick.OnUseEnded.RemoveListener(Attack);
            _playerInput.Joystick.OnUseEnded.AddListener(Idle);
        }
    }
}

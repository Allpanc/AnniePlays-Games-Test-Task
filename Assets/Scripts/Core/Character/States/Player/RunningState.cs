using AnniePlaysGamesTestTask.Core.Character.Player;
using AnniePlaysGamesTestTask.Core.Shooting;
using AnniePlaysGamesTestTask.Input;
using UnityEngine;

namespace AnniePlaysGamesTestTask.Core.Character.States.Player
{
    public class RunningState : BaseState
    {
        private PlayerInput _playerInput;

        public override void Initialize(PlayerController player)
        {
            base.Initialize(player);
            _playerInput = _player.GetComponent<PlayerInput>();
        }

        public override void Enter()
        {
            base.Enter();
            _animator.SetBool("isRunning", true);
            _animator.SetBool("isInCombat", true);
            _player.GetComponent<ShootingSystem>().StopShooting();
        }

        public override void Tick()
        {
            base.Tick();
            _characterController.SimpleMove(_playerInput.Direction * _player.Stats.Speed);
            _characterController.transform.rotation = Quaternion.LookRotation(_playerInput.Direction);
        }
    }
}

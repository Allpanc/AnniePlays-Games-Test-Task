using AnniePlaysGamesTestTask.Input;
using UnityEngine;

namespace AnniePlaysGamesTestTask.Player.States
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
        }

        public override void Tick()
        {
            base.Tick();
            _characterController.SimpleMove(_playerInput._direction * _player.Stats.Speed);
            _characterController.transform.rotation = Quaternion.LookRotation(_playerInput._direction);
        }
    }
}

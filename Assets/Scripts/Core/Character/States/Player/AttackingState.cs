using AnniePlaysGamesTestTask.Core.Character.Player;
using AnniePlaysGamesTestTask.Core.Shooting;
using UnityEngine;

namespace AnniePlaysGamesTestTask.Core.Character.States.Player
{
    public class AttackingState : BaseState
    {
        private ShootingSystem _shootingSystem;

        public override void Initialize(PlayerController player)
        {
            base.Initialize(player);
            _shootingSystem = _player.GetComponent<ShootingSystem>();
        }
        public override void Enter()
        {
            base.Enter();
            _animator.SetBool("isRunning", false);
            _animator.SetBool("isInCombat", true);
            _shootingSystem.StartShooting();
        }

        public override void Tick()
        {
            base.Tick();
            Vector3 lookDirection = _shootingSystem.ShootingDirection;
            _characterController.transform.rotation = Quaternion.LookRotation(lookDirection);
            _characterController.transform.rotation = Quaternion.Euler(0, _characterController.transform.rotation.eulerAngles.y, 0);
        }
    }
}

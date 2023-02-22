using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnniePlaysGamesTestTask.Player.States
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
            _shootingSystem.StartShooting();
        }

        public override void Tick()
        {
            base.Tick();
            EnemyController enemy = GameObject.FindObjectOfType<EnemyController>();
            Vector3 lookDirection = enemy.transform.position - _characterController.transform.position;
            _characterController.transform.rotation = Quaternion.LookRotation(lookDirection);
        }
    }
}

using AnniePlaysGamesTestTask.Core.Character.Enemy;
using AnniePlaysGamesTestTask.Core.Character.Player;
using UnityEngine;

namespace AnniePlaysGamesTestTask.Core.Character.States.Enemy
{
    public class RunningState : BaseState
    {
        public override void Enter()
        {
            base.Enter();
            if (_enemy is Soldier)
                _animator.SetBool("isRunning", true);
            EnemyStats stats = (EnemyStats)_enemy.Stats;
            PlayerController player = GameObject.FindObjectOfType<PlayerController>();
            Vector3 targetPosition = (player.transform.position - _agent.transform.position).normalized * stats.MovementRadius;
            targetPosition.y = _enemy.transform.position.y;
            _agent.SetDestination(targetPosition);
            _shootingSystem.StopShooting();
        }

        public override void Tick()
        {
            base.Tick();
            Vector3 lookDirection = _shootingSystem.ShootingDirection;
            lookDirection.y = 0;
            _agent.transform.rotation = Quaternion.LookRotation(lookDirection);
        }
    }
}

using AnniePlaysGamesTestTask.Core.Character.Enemy;
using UnityEngine;

namespace AnniePlaysGamesTestTask.Core.Character.States.Enemy
{
    public class AttackingState : BaseState
    {
        public override void Enter()
        {
            base.Enter();
            if (_enemy is Soldier)
                _animator.SetBool("isRunning", false);
            _shootingSystem.StartShooting();
        }

        public override void Tick()
        {
            base.Tick();
            Vector3 lookDirection = _shootingSystem.ShootingDirection;
            _enemy.transform.rotation = Quaternion.LookRotation(lookDirection);
            _enemy.transform.rotation = Quaternion.Euler(0, _enemy.transform.rotation.eulerAngles.y, 0);
        }
    }
}

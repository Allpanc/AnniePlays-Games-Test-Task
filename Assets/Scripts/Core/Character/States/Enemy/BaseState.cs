using AnniePlaysGamesTestTask.Core.Character.Enemy;
using AnniePlaysGamesTestTask.Core.Shooting;
using UnityEngine;
using UnityEngine.AI;

namespace AnniePlaysGamesTestTask.Core.Character.States.Enemy
{
    public class BaseState
    {
        protected EnemyController _enemy;
        protected Animator _animator;
        protected NavMeshAgent _agent;
        protected EnemyShootingSystem _shootingSystem;

        public virtual void Initialize(EnemyController enemy)
        {
            _enemy = enemy;
            _animator = _enemy.GetComponent<Animator>();
            _agent = _enemy.GetComponent<NavMeshAgent>();
            _shootingSystem = _enemy.GetComponent<EnemyShootingSystem>();
        }

        public virtual void Enter()
        {
            if (_enemy == null)
                Debug.LogError("Null enemy");

            if (_animator == null)
                _animator = _enemy.GetComponent<Animator>();

            if (_agent == null)
                _agent = _agent.GetComponent<NavMeshAgent>();
        }

        public virtual void Tick() { }
    }
}

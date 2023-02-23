using AnniePlaysGamesTestTask.Core.Character.States;
using AnniePlaysGamesTestTask.Core.Character.States.Enemy;
using AnniePlaysGamesTestTask.Core.Shooting;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace AnniePlaysGamesTestTask.Core.Character.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(EnemyController))]
    [RequireComponent(typeof(EnemyShootingSystem))]
    [RequireComponent(typeof(EnemyStats))]
    [RequireComponent(typeof(StateMachine))]
    public class EnemyController : CustomCharacterController, IKillable
    {
        [SerializeField] protected StateMachine _stateMachine;
        private NavMeshAgent _agent;

        public override void Initialize()
        {
            base.Initialize();
            _agent = GetComponent<NavMeshAgent>();
            _agent.speed = Stats.Speed;
            Attack();
            StartCoroutine(Activate());
        }

        public override void Run()
        {
            base.Run();
            _stateMachine.SetState(State.Run);
        }

        public override void Attack()
        {
            base.Attack();
            _stateMachine.SetState(State.Attack);
        }

        public override void Die()
        {
            base.Die();
            gameObject.SetActive(false);
        }

        private IEnumerator Activate()
        {
            EnemyStats enemyStats = (EnemyStats)Stats;
            while (true)
            {
                yield return new WaitForSeconds(3f);
                Attack();
                yield return new WaitForSeconds(enemyStats.IdleTime);
                Run();
            }
        }
    }
}

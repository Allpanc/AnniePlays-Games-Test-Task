using AnniePlaysGamesTestTask.Core.Character.Health;
using UnityEngine;
using UnityEngine.Events;

namespace AnniePlaysGamesTestTask.Core.Character
{
    [RequireComponent(typeof(HealthController))]
    public class CustomCharacterController : MonoBehaviour, IKillable
    {
        public UnityEvent OnDead = new UnityEvent();
        public UnityEvent OnDamaged = new UnityEvent();
        public Stats Stats;
        private HealthController _healthController;

        public virtual void Initialize()
        {
            _healthController = GetComponent<HealthController>();
            OnDamaged.AddListener(_healthController.UpdateHealth);
        }

        public virtual void Idle()
        {
            Debug.Log(gameObject.name + " Idle");
        }

        public virtual void Run()
        {
            Debug.Log(gameObject.name + " Run");
        }

        public virtual void Attack()
        {
            Debug.Log(gameObject.name + " Attack");
        }

        public virtual void TakeDamage(int damage)
        {
            if (Stats.Health - damage <= 0)
            {
                Stats.Health = 0;
                Die();
            }
            else
                Stats.Health -= damage;
            OnDamaged.Invoke();
        }

        public virtual void Die()
        {
            OnDead.Invoke();
            Debug.Log(gameObject.name + " + died");
        }
    }
}

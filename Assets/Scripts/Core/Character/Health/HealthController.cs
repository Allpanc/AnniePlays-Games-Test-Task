using UnityEngine;

namespace AnniePlaysGamesTestTask.Core.Character.Health
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] HealthBar _healthBar;
        private CustomCharacterController _owner;

        void Start()
        {
            _owner = GetComponent<CustomCharacterController>();
            _healthBar.Initialize(_owner.Stats.Health);
        }

        public void UpdateHealth()
        {
            _healthBar.ChangeValueTo(_owner.Stats.Health);
        }
    }
}

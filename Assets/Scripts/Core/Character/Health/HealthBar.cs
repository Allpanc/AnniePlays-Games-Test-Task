using UnityEngine;
using UnityEngine.UI;

namespace AnniePlaysGamesTestTask.Core.Character.Health
{
    public class HealthBar : MonoBehaviour
    {
        private Slider _slider;
        private float _totalHealth;

        public void Initialize(float totalHealth)
        {
            _slider = GetComponent<Slider>();
            _slider.value = 1;
            _totalHealth = totalHealth;
        }

        public void ChangeValueTo(float currentHealth)
        {
            float targetSliderValue = currentHealth / _totalHealth;

            if (targetSliderValue <= 0)
                targetSliderValue = 0;

            _slider.value = targetSliderValue;
        }
    }
}

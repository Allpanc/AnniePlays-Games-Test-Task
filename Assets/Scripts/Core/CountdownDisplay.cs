using TMPro;
using UnityEngine;

namespace AnniePlaysGamesTestTask.Core
{
    public class CountdownDisplay : MonoBehaviour
    {
        [SerializeField] TMP_Text _countdownText;

        private void Awake()
        {
            GameStateController stateController = FindObjectOfType<GameStateController>();
            stateController.OnCountdownChanged.AddListener(UpdateDisplay);
        }

        public void UpdateDisplay(int timerValue)
        {
            _countdownText.text = timerValue.ToString();
            if (timerValue == 0)
                gameObject.SetActive(false);
        }
    }
}

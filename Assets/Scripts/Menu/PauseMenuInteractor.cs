using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace AnniePlaysGamesTestTask.Menu
{
    public class PauseMenuInteractor : MenuInteractor
    {
        [SerializeField] Button _restartButton;
        [SerializeField] Button _continueButton;

        void Start()
        {
            _restartButton.onClick.AddListener(OnRestartButtonClicked);
            _continueButton.onClick.AddListener(OnContinueButtonClicked);
        }

        private void OnRestartButtonClicked()
        {
            Time.timeScale = 1;
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }

        private void OnContinueButtonClicked()
        {
            Time.timeScale = 1;
            _menuSwither.ShowRuntimeMenu();
        }
    }
}

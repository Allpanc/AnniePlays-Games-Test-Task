using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace AnniePlaysGamesTestTask.Menu
{
    public class VictoryMenuInteractor : MenuInteractor
    {
        [SerializeField] Button _restartButton;

        void Start()
        {
            _restartButton.onClick.AddListener(OnRestartButtonClicked);
        }

        private void OnRestartButtonClicked()
        {
            Time.timeScale = 1;
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

namespace AnniePlaysGamesTestTask.Menu
{
    public class RuntimeMenuInteractor : MenuInteractor
    {
        [SerializeField] Button _pauseButton;

        void Start()
        {
            _pauseButton.onClick.AddListener(OnPauseButtonClicked);
        }

        private void OnPauseButtonClicked()
        {
            Time.timeScale = 0;
            _menuSwither.ShowPauseMenu();
        }
    }
}

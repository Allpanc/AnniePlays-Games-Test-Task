using AnniePlaysGamesTestTask.Core.Character.Enemy;
using AnniePlaysGamesTestTask.Core.Character.Player;
using AnniePlaysGamesTestTask.Core.Shooting;
using AnniePlaysGamesTestTask.Finances;
using AnniePlaysGamesTestTask.Menu;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace AnniePlaysGamesTestTask.Core
{
    public class GameStateController : MonoBehaviour
    {
        public UnityEvent<int> OnCountdownChanged = new UnityEvent<int>();

        private PlayerController _player;
        private EnemyController[] _enemies;
        private MenuSwitcher _menuSwitcher;
        private Finish _finish;

        void Start()
        {
            Time.timeScale = 1;
            _menuSwitcher = FindObjectOfType<MenuSwitcher>();
            _finish = FindObjectOfType<Finish>();
            _finish.OnReached.AddListener(Win);

            _player = FindObjectOfType<PlayerController>();
            _player.OnDead.AddListener(Loose);
            _player.GetComponent<PlayerShootingSystem>().OnNoEnemiesLeft.AddListener(OpenGates);

            _enemies = FindObjectsOfType<EnemyController>();
            StartGame();
        }

        private void Win()
        {
            Time.timeScale = 0;
            _menuSwitcher.ShowVictoryMenu();
        }

        private void Loose()
        {
            Time.timeScale = 0;
            _menuSwitcher.ShowLossMenu();
        }

        private void OpenGates()
        {
            _finish.Activate();
        }

        private async void StartGame()
        {
            Balance.Refresh();
            await Countdown();

            _player.Initialize();
            for (int i = 0; i < _enemies.Length; i++)
            {
                _enemies[i].Initialize();
            }
            _menuSwitcher.ShowRuntimeMenu();
        }

        private async Task Countdown()
        {

            int timer = 3;
            while (timer > 0)
            {
                await Task.Delay(1000);
                timer--;
                OnCountdownChanged.Invoke(timer);
            }
        }
    }
}

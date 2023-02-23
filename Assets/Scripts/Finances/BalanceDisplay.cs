using AnniePlaysGamesTestTask.Core.Character.Enemy;
using TMPro;
using UnityEngine;

namespace AnniePlaysGamesTestTask.Finances
{
    public class BalanceDisplay : MonoBehaviour
    {
        [SerializeField] TMP_Text _balanceText;

        void Start()
        {
            EnemyController[] enemies = FindObjectsOfType<EnemyController>();
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].OnDead.AddListener(UpdateDisplay);
            }
        }

        private void UpdateDisplay()
        {
            Balance.Coins++;
            _balanceText.text = Balance.Coins.ToString();
        }
    }
}

using AnniePlaysGamesTestTask.Core.Character.Enemy;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace AnniePlaysGamesTestTask.Core.Shooting
{
    public class PlayerShootingSystem : ShootingSystem
    {
        private EnemyController[] _enemies;
        public UnityEvent OnNoEnemiesLeft = new UnityEvent();

        protected override void Start()
        {
            base.Start();
            _enemies = FindObjectsOfType<EnemyController>();
            for (int i = 0; i < _enemies.Length; i++)
            {
                _enemies[i].OnDead.AddListener(RecountEnemies);
            }
        }

        protected override Vector3 GetShootingDirection()
        {
            _enemies = FindObjectsOfType<EnemyController>();
            int minIndex = 0;
            float minDistance = Vector3.Distance(transform.position, _enemies[0].transform.position);
            for (int i = 1; i < _enemies.Length; i++)
            {
                float distance = Vector3.Distance(transform.position, _enemies[i].transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    minIndex = i;
                }
            }
            Vector3 shootingDirection = _enemies[minIndex].transform.position - _startBulletLocation.position;
            return shootingDirection;
        }

        private void RecountEnemies()
        {
            StartCoroutine(CountEnemies());
        }

        private IEnumerator CountEnemies()
        {
            yield return null;
            _enemies = FindObjectsOfType<EnemyController>();
            if (_enemies.Length == 0)
                OnNoEnemiesLeft.Invoke();
        }
    }
}

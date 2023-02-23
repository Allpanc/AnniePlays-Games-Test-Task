using AnniePlaysGamesTestTask.Core.Character.Enemy;
using UnityEngine;

namespace AnniePlaysGamesTestTask.Core.Spawn
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] EnemyController[] _enemies;
        [SerializeField] int _minEnemyNumber;
        [SerializeField] int _maxEnemyNumber;

        void Awake()
        {
            Spawn();
        }

        private void Spawn()
        {
            int enemyNumber = Random.Range(_minEnemyNumber, _maxEnemyNumber);
            for (int i = 0; i < enemyNumber; i++)
            {
                EnemyController enemy = _enemies[Random.Range(0, _enemies.Length)];
                float spawnHeight = 0;
                if (enemy is Soldier)
                    spawnHeight = 0.1f;
                else if (enemy is Drone)
                    spawnHeight = 5;

                Vector3 spawnPosition = PickSpawnPosition();
                spawnPosition.y = spawnHeight;

                EnemyController spawnedEnemy = Instantiate(enemy, spawnPosition, Quaternion.LookRotation(Vector3.back));
                //Debug.Log(spawnPosition);           
            }
        }

        private Vector3 PickSpawnPosition()
        {
            Vector2 viewportPosition = new Vector3(Random.Range(0.2f, 0.8f), Random.Range(2 / 3f, 1.05f), Camera.main.nearClipPlane);
            Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(viewportPosition);
            spawnPosition.y = 1f;

            if (Physics.OverlapSphere(spawnPosition, 1).Length != 0)
            {
                //Debug.Log("Pick spawn position again");
                PickSpawnPosition();
            }

            //Debug.Log("Spawn position picked");
            return spawnPosition;
        }
    }
}

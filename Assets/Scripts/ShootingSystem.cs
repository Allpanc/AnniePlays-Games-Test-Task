using AnniePlaysGamesTestTask.Pool;
using System.Collections;
using UnityEngine;

namespace AnniePlaysGamesTestTask
{
    public class ShootingSystem : MonoBehaviour
    {
        [SerializeField] float _shootingForce = 5;
        [SerializeField] Transform _startBulletLocation;
        private ObjectPool _pool;

        private Coroutine _shootingRoutine;

        private void Start()
        {
            _pool = FindObjectOfType<ObjectPool>();
        }

        public void Fire()
        {
            GameObject bullet = _pool.Get().gameObject;
            if (bullet == null)
                return;

            Vector3 shootingDirection = GetShootingDirection();
            Debug.DrawRay(_startBulletLocation.position, shootingDirection,Color.red,3f);
            bullet.SetActive(true);
            bullet.transform.position = _startBulletLocation.position;
            bullet.GetComponent<Rigidbody>().freezeRotation = false;
            bullet.transform.forward = shootingDirection.normalized;
            bullet.GetComponent<Rigidbody>().freezeRotation = true;
            bullet.GetComponent<Rigidbody>().AddForce(shootingDirection * _shootingForce, ForceMode.Impulse);
        }

        private Vector3 GetShootingDirection()
        {
            EnemyController enemy = FindObjectOfType<EnemyController>();
            Vector3 shootingDirection = enemy.transform.position - transform.position;

            return shootingDirection;

        }

        public void StartShooting()
        {
            _shootingRoutine = StartCoroutine(Shoot());
        }

        public void StopShooting()
        {
            StopCoroutine(_shootingRoutine);
        }

        private IEnumerator Shoot()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.5f);
                Fire();
            }
        }
    }
}

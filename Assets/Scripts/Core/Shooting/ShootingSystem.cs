using AnniePlaysGamesTestTask.Core.Character;
using AnniePlaysGamesTestTask.Pool;
using System.Collections;
using UnityEngine;

namespace AnniePlaysGamesTestTask.Core.Shooting
{
    public class ShootingSystem : MonoBehaviour
    {
        [SerializeField] protected float _shootingForce = 5;
        [SerializeField] protected Transform _startBulletLocation;
        protected ObjectPool _pool;

        protected Coroutine _shootingRoutine;

        public Vector3 ShootingDirection { get => GetShootingDirection(); }

        protected virtual void Start()
        {
            _pool = FindObjectOfType<ObjectPool>();
        }

        public void Fire()
        {
            Bullet bullet = _pool.Get().gameObject.GetComponent<Bullet>();
            if (bullet == null)
                return;

            bullet.gameObject.SetActive(true);
            bullet.Owner = GetComponent<CustomCharacterController>();
            bullet.Damage = bullet.Owner.Stats.Damage;
            Physics.IgnoreCollision(bullet.GetComponent<Collider>(), bullet.Owner.GetComponent<Collider>());

            Vector3 shootingDirection = GetShootingDirection();
            Debug.DrawRay(_startBulletLocation.position, shootingDirection,Color.red,3f);
     
            bullet.transform.position = _startBulletLocation.position;
            bullet.GetComponent<Rigidbody>().freezeRotation = false;
            bullet.transform.forward = shootingDirection.normalized;
            bullet.GetComponent<Rigidbody>().freezeRotation = true;
            bullet.GetComponent<Rigidbody>().AddForce(shootingDirection * _shootingForce, ForceMode.Impulse);
        }

        protected virtual Vector3 GetShootingDirection()
        {
            return Vector3.zero;
        }

        public void StartShooting()
        {
            if (_shootingRoutine == null)
                _shootingRoutine = StartCoroutine(Shoot());
            //Debug.LogWarning("Start shoting");
        }

        public void StopShooting()
        {
            if (_shootingRoutine != null)
            {
                StopCoroutine(_shootingRoutine);
                _shootingRoutine = null;
                //Debug.LogWarning("Stop shooting");
            }
            else
                Debug.LogWarning("Null routine " + gameObject.name);
        }

        protected IEnumerator Shoot()
        {
            float timeBetweenShots = GetComponent<Stats>().TimeBetweenShots;
            while (true)
            {
                yield return new WaitForSeconds(timeBetweenShots);
                Fire();
            }
        }
    }
}

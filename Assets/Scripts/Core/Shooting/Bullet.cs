using AnniePlaysGamesTestTask.Core.Character;
using AnniePlaysGamesTestTask.Pool;
using System.Collections;
using UnityEngine;

namespace AnniePlaysGamesTestTask.Core.Shooting
{
    public class Bullet : PooledObject
    {
        [SerializeField] GameObject explosionEffect;
        private Rigidbody _rb;

        public bool IsUsed;
        public int Damage;
        public CustomCharacterController Owner;

        private void Start()
        {
            _rb = GetComponentInChildren<Rigidbody>();
        }

        private void OnEnable()
        {
            if (_rb == null)
                _rb = GetComponentInChildren<Rigidbody>();
            StartCoroutine(ReturnToPoolAfterTimeout());
            _rb.velocity = Vector3.zero;
            _rb.useGravity = false;
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject == Owner)
                return;

            StartCoroutine(ReturnToPoolAfterCollision());

            _rb.useGravity = true;
            _rb.velocity = Vector3.zero;
            explosionEffect.SetActive(true);
            if (collision.gameObject.GetComponent<IKillable>() != null)
                collision.gameObject.GetComponent<IKillable>().TakeDamage(Damage);
        }

        IEnumerator ReturnToPoolAfterCollision()
        {
            yield return new WaitForSeconds(0.5f);
            IsUsed = false;
            Physics.IgnoreCollision(GetComponent<Collider>(), Owner.GetComponent<Collider>(), false);
            Pool.Release(this);
        }

        IEnumerator ReturnToPoolAfterTimeout()
        {
            yield return new WaitForSeconds(3f);
            IsUsed = false;
            Pool.Release(this);
        }
    }
}

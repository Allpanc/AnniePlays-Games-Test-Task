using System.Collections;
using UnityEngine;

namespace AnniePlaysGamesTestTask.Pool
{
    public class Bullet : PooledObject
    {
        public bool _isUsed { get; set; }
        private Rigidbody _rb;

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
            StartCoroutine(ReturnToPoolAfterCollision());
            Debug.Log("Bullet collided with " + collision.gameObject.name);
            _rb.useGravity = true;
        }

        IEnumerator ReturnToPoolAfterCollision()
        {
            yield return new WaitForSeconds(1f);
            _isUsed = false;
            Owner.Release(this);
        }

        IEnumerator ReturnToPoolAfterTimeout()
        {
            yield return new WaitForSeconds(6f);
            _isUsed = false;
            //Debug.Log("Bullet returned to pool after timeout");
            Owner.Release(this);
        }
    }
}

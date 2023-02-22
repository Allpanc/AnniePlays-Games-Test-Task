using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AnniePlaysGamesTestTask
{
    public interface IKillable
    {
        public void TakeDamage(int damage);
        public void Die();
    }
}

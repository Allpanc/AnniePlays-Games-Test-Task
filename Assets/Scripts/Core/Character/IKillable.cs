using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AnniePlaysGamesTestTask.Core.Character
{
    public interface IKillable
    {
        public void TakeDamage(int damage);
        public void Die();
    }
}

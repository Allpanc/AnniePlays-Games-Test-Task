using AnniePlaysGamesTestTask.Core.Character.Player;
using UnityEngine;

namespace AnniePlaysGamesTestTask.Core.Shooting
{
    public class EnemyShootingSystem : ShootingSystem
    {
        private PlayerController _player;

        protected override void Start()
        {
            base.Start();
            _player = FindObjectOfType<PlayerController>();
        }

        protected override Vector3 GetShootingDirection()
        {
            Vector3 shootingDirection = _player.transform.position - _startBulletLocation.position;
            return shootingDirection;
        }
    }
}

using AnniePlaysGamesTestTask.Core.Character.Player;
using Cinemachine;
using UnityEngine;

namespace AnniePlaysGamesTestTask.Core.Spawn
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] PlayerController _player;
        [SerializeField] Transform _spawn;

        void Awake()
        {
            PlayerController player = Instantiate(_player, _spawn.position, Quaternion.identity);
            CinemachineVirtualCamera camera = FindObjectOfType<CinemachineVirtualCamera>();
            camera.LookAt = player.transform;
            camera.Follow = player.transform;
        }
    }
}

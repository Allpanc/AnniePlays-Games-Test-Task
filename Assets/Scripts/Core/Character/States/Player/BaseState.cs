using AnniePlaysGamesTestTask.Core.Character.Player;
using UnityEngine;

namespace AnniePlaysGamesTestTask.Core.Character.States.Player
{
    public class BaseState
    {
        protected PlayerController _player;
        protected Animator _animator;
        protected CharacterController _characterController;

        public virtual void Initialize(PlayerController player)
        {
            _player = player;
            _animator = _player.GetComponent<Animator>();
            _characterController = _player.GetComponent<CharacterController>();
        }

        public virtual void Enter()
        {
            if (_player == null)
                Debug.LogError("Null player");

            if (_animator == null)
                _animator = _player.GetComponent<Animator>();

            if (_characterController == null)
                _characterController = _player.GetComponent<CharacterController>();
        }

        public virtual void Tick() { }
    }

}

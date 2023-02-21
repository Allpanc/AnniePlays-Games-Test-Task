using UnityEngine;

namespace AnniePlaysGamesTestTask.Input
{
    public class PlayerInput : MonoBehaviour
    {
        public Input.Joystick _joystick;
        public Vector3 _direction { get; private set; }

        void Update()
        {
            _direction = GetMovementDirection();
        }

        private Vector3 GetMovementDirection()
        {
            Vector3 direction = Vector3.forward * _joystick.Vertical + Vector3.right * _joystick.Horizontal;
            Debug.Log("Direction " + direction);
            return direction;
        }
    }
}

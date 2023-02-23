using UnityEngine;

namespace AnniePlaysGamesTestTask.Input
{
    public class PlayerInput : MonoBehaviour
    {
        public Joystick Joystick;
        public Vector3 Direction { get; private set; }

        private void Awake()
        {
            Joystick = FindObjectOfType<Joystick>();
        }

        void Update()
        {
            
            Direction = GetMovementDirection();
        }

        private Vector3 GetMovementDirection()
        {
            Vector3 direction = Vector3.forward * Joystick.Vertical + Vector3.right * Joystick.Horizontal;
            //Debug.Log("Direction " + direction);
            return direction;
        }
    }
}

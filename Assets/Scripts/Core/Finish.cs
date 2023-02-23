using AnniePlaysGamesTestTask.Core.Character.Player;
using UnityEngine;
using UnityEngine.Events;

namespace AnniePlaysGamesTestTask.Core
{
    public class Finish : MonoBehaviour
    {
        public UnityEvent OnReached = new UnityEvent();
        [SerializeField] Collider _gateBlocker;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<PlayerController>() != null)
            {
                Debug.Log("Finish");
                Time.timeScale = 0;
                OnReached.Invoke();
            }
        }

        public void Activate()
        {
            _gateBlocker.enabled = false;
        }
    }
}

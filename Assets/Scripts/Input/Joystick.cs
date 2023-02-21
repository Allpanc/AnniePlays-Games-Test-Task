using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace AnniePlaysGamesTestTask.Input
{
    public class Joystick : FloatingJoystick
    {
        public UnityEvent OnUseStarted =  new UnityEvent();
        public UnityEvent OnUseEnded = new UnityEvent();

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            OnUseStarted.Invoke();
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            OnUseEnded.Invoke();
        }
    }
}

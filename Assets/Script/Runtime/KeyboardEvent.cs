using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Grubo
{
    public sealed class KeyboardEvent : MonoBehaviour
    {
        [SerializeField] Key _key = Key.None;
        [SerializeField] UnityEvent _event = null;

        void Update()
        {
            if (_key != Key.None &&
                Keyboard.current[_key].wasPressedThisFrame) _event.Invoke();
        }
    }
}


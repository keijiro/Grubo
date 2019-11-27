using UnityEngine;
using UnityEngine.InputSystem;

namespace Grubo
{
    public sealed class ToggleSwitcher : MonoBehaviour
    {
        [SerializeField] GameObject _target = null;
        [SerializeField] Key _key = Key.None;

        public void Toggle()
        {
            if (!enabled || !gameObject.activeInHierarchy) return;
            _target.SetActive(!_target.activeSelf);
        }

        void Update()
        {
            if (_key != Key.None &&
                Keyboard.current[_key].wasPressedThisFrame) Toggle();
        }
    }
}

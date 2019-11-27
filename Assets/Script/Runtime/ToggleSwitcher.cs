using UnityEngine;
using UnityEngine.InputSystem;

namespace Grubo
{
    public sealed class ToggleSwitcher : MonoBehaviour
    {
        public enum TargetType { GameObject, Behaviour, Subtree }

        [SerializeField] TargetType _targetType = TargetType.Subtree;
        [SerializeField] GameObject _targetGameObject = null;
        [SerializeField] Behaviour _targetBehaviour = null;
        [SerializeField] Key _toggleKey = Key.None;

        void ToggleGameObject(GameObject go)
        {
            go.SetActive(!go.activeSelf);
        }

        public void Toggle()
        {
            if (!enabled || !gameObject.activeInHierarchy) return;

            if (_targetType == TargetType.GameObject && _targetGameObject != null)
            {
                ToggleGameObject(_targetGameObject);
            }
            else if (_targetType == TargetType.Behaviour && _targetBehaviour != null)
            {
                _targetBehaviour.enabled = !_targetBehaviour.enabled;
            }
            else // TargetType.Subtree
            {
                foreach (Transform t in transform) ToggleGameObject(t.gameObject);
            }
        }

        void Update()
        {
            if (_toggleKey != Key.None &&
                Keyboard.current[_toggleKey].wasPressedThisFrame) Toggle();
        }
    }
}

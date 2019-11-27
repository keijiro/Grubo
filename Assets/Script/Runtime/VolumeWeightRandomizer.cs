using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

namespace Grubo
{
    [RequireComponent(typeof(Volume))]
    public sealed class VolumeWeightRandomizer : MonoBehaviour
    {
        [SerializeField] Key _randomizeKey = Key.None;
        [SerializeField] Key _resetKey = Key.None;

        Volume _volume;

        public void Randomize()
        {
            if (!enabled || !gameObject.activeInHierarchy) return;
            _volume.weight = Random.value;
        }

        public void SetWeight(float weight)
        {
            if (!enabled || !gameObject.activeInHierarchy) return;
            _volume.weight = weight;
        }

        void Start()
        {
            _volume = GetComponent<Volume>();
        }

        void Update()
        {
            if (_randomizeKey != Key.None &&
                Keyboard.current[_randomizeKey].wasPressedThisFrame) Randomize();

            if (_resetKey != Key.None &&
                Keyboard.current[_resetKey].wasPressedThisFrame) SetWeight(0);
        }
    }
}

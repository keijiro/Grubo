using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

namespace Grubo
{
    [RequireComponent(typeof(Volume))]
    public sealed class VolumeWeightAnimation : MonoBehaviour
    {
        [SerializeField] AnimationCurve _curve = AnimationCurve.Linear(0, 1, 1, 0);
        [SerializeField] float _speed = 1;
        [SerializeField] Key _playKey = Key.None;

        public float Speed {
            get { return _speed; }
            set { _speed = value; }
        }

        Volume _volume;
        float _time = 1e+5f;

        void ApplyCurve()
        {
            _volume.weight = _curve.Evaluate(_time);
        }

        public void Play()
        {
            if (!enabled || !gameObject.activeInHierarchy) return;
            _time = 0;
            ApplyCurve();
        }

        void Start()
        {
            _volume = GetComponent<Volume>();
            ApplyCurve();
        }

        void Update()
        {
            if (_playKey != Key.None &&
                Keyboard.current[_playKey].wasPressedThisFrame) _time = 0;

            ApplyCurve();

            _time += Time.deltaTime * _speed;
        }
    }
}

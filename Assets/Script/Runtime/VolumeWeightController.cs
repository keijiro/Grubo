using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

namespace Grubo
{
    [RequireComponent(typeof(Volume))]
    public sealed class VolumeWeightController : MonoBehaviour
    {
        [SerializeField] AnimationCurve _curve = AnimationCurve.Linear(0, 0, 1, 1);
        [SerializeField] float _time = 0;

        public float Time {
            get => _time;
            set => _time = value;
        }

        Volume _volume;

        void ApplyCurve()
        {
            _volume.weight = _curve.Evaluate(_time);
        }

        void Start()
        {
            _volume = GetComponent<Volume>();
            ApplyCurve();
        }

        void Update()
        {
            ApplyCurve();
        }
    }
}

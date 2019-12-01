using UnityEngine;
using UnityEngine.Events;

namespace Grubo
{
    public sealed class EventRelay : MonoBehaviour
    {
        [SerializeField, Range(0, 1)] float _probability = 1;
        [SerializeField] int _divisor = 1;
        [SerializeField] UnityEvent _event = null;

        int _clock;

        public void Trigger()
        {
            if (++_clock < _divisor) return;
            _clock = 0;

            if (!enabled || !gameObject.activeInHierarchy) return;

            if (Random.value >= _probability) return;

            _event.Invoke();
        }
    }
}


using UnityEngine;
using UnityEngine.InputSystem;

namespace Grubo
{
    public sealed class Selector : MonoBehaviour
    {
        #region Editable attributes

        [System.Serializable]
        public class KeyTargetPair
        {
            public GameObject target = null;
            public Key key = Key.None;
        }

        [SerializeField] KeyTargetPair [] _pairs = null;
        [SerializeField] Key _randomizeKey = Key.Space;

        #endregion

        #region Public methods

        public void Select(int index)
        {
            for (var i = 0; i < _pairs.Length; i++)
                _pairs[i].target.SetActive(i == index);
        }

        public void RandomSelect()
        {
            Select(RandomIndexOtherThanCurrent());
        }

        #endregion

        #region Private members

        int RandomIndexOtherThanCurrent()
        {
            var num = _pairs.Length;
            if (num < 2) return 0;

            while (true)
            {
                var i = Random.Range(0, num);
                if (!_pairs[i].target.activeSelf) return i;
            }
        }

        #endregion

        #region MonoBehaviour implementation

        void Start()
        {
            Select(0);
        }

        void Update()
        {
            var keyboard = Keyboard.current;

            for (var i = 0; i < _pairs.Length; i++)
                if (_pairs[i].key != Key.None &&
                    keyboard[_pairs[i].key].wasPressedThisFrame) Select(i);

            if (_randomizeKey != Key.None &&
                keyboard[_randomizeKey].wasPressedThisFrame)
                RandomSelect();
        }

        #endregion
    }
}

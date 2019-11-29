using UnityEngine;

namespace Grubo
{
    class AppController : MonoBehaviour
    {
        void Start()
        {
#if !UNITY_EDITOR
            Cursor.visible = false;
#endif
        }
    }
}

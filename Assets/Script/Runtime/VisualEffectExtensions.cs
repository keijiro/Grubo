using UnityEngine.VFX;

namespace Grubo
{
    public static class VisualEffectExtensions
    {
        public static void SetFloatSafe(this VisualEffect vfx, int id, float f)
        {
            if (vfx == null) return;
            if (!vfx.HasFloat(id)) return;
            vfx.SetFloat(id, f);
        }

        public static void SetUIntSafe(this VisualEffect vfx, int id, uint i)
        {
            if (vfx == null) return;
            if (!vfx.HasUInt(id)) return;
            vfx.SetUInt(id, i);
        }
    }
}

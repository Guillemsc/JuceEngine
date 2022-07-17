using System;

namespace JuceEngine.Core.Maths.Utils
{
    public static class MathsUtils
    {
        public static float Normalize(int current, int max)
        {
            if (max <= 0)
            {
                return 0f;
            }

            current = Math.Max(0, current);
            current = Math.Min(current, max);

            return current / (float)max;
        }
    }
}

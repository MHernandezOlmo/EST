using System;
using Libtween.Equations;

public static class Easings
{
    public static float Linear(float t) => EasingEquations.Linear(t, 0f, 1f, 1f);

    public static float QuadEaseIn(float t) => EasingEquations.QuadEaseIn(t, 0f, 1f, 1f);
    public static float QuadEaseOut(float t) => EasingEquations.QuadEaseOut(t, 0f, 1f, 1f);
    public static float QuadEaseInOut(float t) => EasingEquations.QuadEaseInOut(t, 0f, 1f, 1f);
    public static float QuadEaseOutIn(float t) => EasingEquations.QuadEaseOutIn(t, 0f, 1f, 1f);

    public static float CubicEaseIn(float t) => EasingEquations.CubicEaseIn(t, 0f, 1f, 1f);
    public static float CubicEaseOut(float t) => EasingEquations.CubicEaseOut(t, 0f, 1f, 1f);
    public static float CubicEaseInOut(float t) => EasingEquations.CubicEaseInOut(t, 0f, 1f, 1f);
    public static float CubicEaseOutIn(float t) => EasingEquations.CubicEaseOutIn(t, 0f, 1f, 1f);

    public static float QuartEaseIn(float t) => EasingEquations.QuartEaseIn(t, 0f, 1f, 1f);
    public static float QuartEaseOut(float t) => EasingEquations.QuartEaseOut(t, 0f, 1f, 1f);
    public static float QuartEaseInOut(float t) => EasingEquations.QuartEaseInOut(t, 0f, 1f, 1f);
    public static float QuartEaseOutIn(float t) => EasingEquations.QuartEaseOutIn(t, 0f, 1f, 1f);

    public static float QuintEaseIn(float t) => EasingEquations.QuintEaseIn(t, 0f, 1f, 1f);
    public static float QuintEaseOut(float t) => EasingEquations.QuintEaseOut(t, 0f, 1f, 1f);
    public static float QuintEaseInOut(float t) => EasingEquations.QuintEaseInOut(t, 0f, 1f, 1f);
    public static float QuintEaseOutIn(float t) => EasingEquations.QuintEaseOutIn(t, 0f, 1f, 1f);

    public static float ExpoEaseIn(float t) => EasingEquations.ExpoEaseIn(t, 0f, 1f, 1f);
    public static float ExpoEaseOut(float t) => EasingEquations.ExpoEaseOut(t, 0f, 1f, 1f);
    public static float ExpoEaseInOut(float t) => EasingEquations.ExpoEaseInOut(t, 0f, 1f, 1f);
    public static float ExpoEaseOutIn(float t) => EasingEquations.ExpoEaseOutIn(t, 0f, 1f, 1f);

    public static float BounceEaseIn(float t) => EasingEquations.BounceEaseIn(t, 0f, 1f, 1f);
    public static float BounceEaseOut(float t) => EasingEquations.BounceEaseOut(t, 0f, 1f, 1f);
    public static float BounceEaseInOut(float t) => EasingEquations.BounceEaseInOut(t, 0f, 1f, 1f);
    public static float BounceEaseOutIn(float t) => EasingEquations.BounceEaseOutIn(t, 0f, 1f, 1f);

    public static float ElasticEaseIn(float t) => EasingEquations.ElasticEaseIn(t, 0f, 1f, 1f);
    public static float ElasticEaseOut(float t) => EasingEquations.ElasticEaseOut(t, 0f, 1f, 1f);
    public static float ElasticEaseInOut(float t) => EasingEquations.ElasticEaseInOut(t, 0f, 1f, 1f);
    public static float ElasticEaseOutIn(float t) => EasingEquations.ElasticEaseOutIn(t, 0f, 1f, 1f);

    public static float CircEaseIn(float t) => EasingEquations.CircEaseIn(t, 0f, 1f, 1f);
    public static float CircEaseOut(float t) => EasingEquations.CircEaseOut(t, 0f, 1f, 1f);
    public static float CircEaseInOut(float t) => EasingEquations.CircEaseInOut(t, 0f, 1f, 1f);
    public static float CircEaseOutIn(float t) => EasingEquations.CircEaseOutIn(t, 0f, 1f, 1f);

    public static float SineEaseIn(float t) => EasingEquations.SineEaseIn(t, 0f, 1f, 1f);
    public static float SineEaseOut(float t) => EasingEquations.SineEaseOut(t, 0f, 1f, 1f);
    public static float SineEaseInOut(float t) => EasingEquations.SineEaseInOut(t, 0f, 1f, 1f);
    public static float SineEaseOutIn(float t) => EasingEquations.SineEaseOutIn(t, 0f, 1f, 1f);

    public static float BackEaseIn(float t) => EasingEquations.BackEaseIn(t, 0f, 1f, 1f);
    public static float BackEaseOut(float t) => EasingEquations.BackEaseOut(t, 0f, 1f, 1f);
    public static float BackEaseInOut(float t) => EasingEquations.BackEaseInOut(t, 0f, 1f, 1f);
    public static float BackEaseOutIn(float t) => EasingEquations.BackEaseOutIn(t, 0f, 1f, 1f);

    public static Func<float, float> Inverse(this Func<float, float> function)
    {
        if (function == Linear) return Linear;

        else if (function == QuadEaseIn) return QuadEaseOut;
        else if (function == QuadEaseOut) return QuadEaseIn;
        else if (function == QuadEaseInOut) return QuadEaseOutIn;
        else if (function == QuadEaseOutIn) return QuadEaseInOut;

        else if (function == CubicEaseIn) return CubicEaseOut;
        else if (function == CubicEaseOut) return CubicEaseIn;
        else if (function == CubicEaseInOut) return CubicEaseOutIn;
        else if (function == CubicEaseOutIn) return CubicEaseInOut;

        else if (function == QuartEaseIn) return QuartEaseOut;
        else if (function == QuartEaseOut) return QuartEaseIn;
        else if (function == QuartEaseInOut) return QuartEaseOutIn;
        else if (function == QuartEaseOutIn) return QuartEaseInOut;

        else if (function == QuintEaseIn) return QuintEaseOut;
        else if (function == QuintEaseOut) return QuintEaseIn;
        else if (function == QuintEaseInOut) return QuintEaseOutIn;
        else if (function == QuintEaseOutIn) return QuintEaseInOut;

        else if (function == ExpoEaseIn) return ExpoEaseOut;
        else if (function == ExpoEaseOut) return ExpoEaseIn;
        else if (function == ExpoEaseInOut) return ExpoEaseOutIn;
        else if (function == ExpoEaseOutIn) return ExpoEaseInOut;

        else if (function == BounceEaseIn) return BounceEaseOut;
        else if (function == BounceEaseOut) return BounceEaseIn;
        else if (function == BounceEaseInOut) return BounceEaseOutIn;
        else if (function == BounceEaseOutIn) return BounceEaseInOut;

        else if (function == ElasticEaseIn) return ElasticEaseOut;
        else if (function == ElasticEaseOut) return ElasticEaseIn;
        else if (function == ElasticEaseInOut) return ElasticEaseOutIn;
        else if (function == ElasticEaseOutIn) return ElasticEaseInOut;

        else if (function == CircEaseIn) return CircEaseOut;
        else if (function == CircEaseOut) return CircEaseIn;
        else if (function == CircEaseInOut) return CircEaseOutIn;
        else if (function == CircEaseOutIn) return CircEaseInOut;

        else if (function == SineEaseIn) return SineEaseOut;
        else if (function == SineEaseOut) return SineEaseIn;
        else if (function == SineEaseInOut) return SineEaseOutIn;
        else if (function == SineEaseOutIn) return SineEaseInOut;

        else if (function == BackEaseIn) return BackEaseOut;
        else if (function == BackEaseOut) return BackEaseIn;
        else if (function == BackEaseInOut) return BackEaseOutIn;
        else if (function == BackEaseOutIn) return BackEaseInOut;

        else return null;
    }
}
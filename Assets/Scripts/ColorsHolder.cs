using System;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "ColorsHolder",menuName = "ColorsHolder")]
public class ColorsHolder : ScriptableObject
{
    public Color[] colors;
}

static class Extension
{
    public static bool IsEqualTo(this Color me, Color other)
    {
        return Math.Abs(me.r - other.r) < 0.01 && Math.Abs(me.g - other.g) < 0.01 && Math.Abs(me.b - other.b) < 0.01 && Math.Abs(me.a - other.a) < 0.01;
    }
}
using System;
using Microsoft.Xna.Framework;

namespace TowerDefense.Util;

/// <summary>
/// A collection of static utility relating to vectors, mostly so I 
/// don't have to type constructors all the time.
/// </summary>
public static class V
{
    public static Vector2 Zero => Vector2.Zero;

    public static Vector2 Unit => Vector2.One;

    public static Vector2 Of(float x, float y)
    {
        return new Vector2(x, y);
    }
}
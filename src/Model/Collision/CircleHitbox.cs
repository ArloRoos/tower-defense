using System;
using System.Numerics;

namespace TowerDefense.Model.Collision;

/// <summary>
/// A circular hitbox, configured with a radius value.
/// </summary>
public class CircleHitbox : Hitbox
{
    public float Radius { get; private set; }

    public CircleHitbox(Vector2 position, float radius, Vector2 offset)
        : base(position, offset)
    {
        this.Radius = radius;
    }

    /// <inheritdoc/>
    public override bool CollidesWith(Hitbox other)
    {
        if (other is CircleHitbox c)
        {
            return CollisionUtil.CircleCollidesWithCircle(this, c);
        }
        else if (other is RectHitbox r)
        {
            return CollisionUtil.RectCollidesWithCircle(r, this);
        }

        throw new NotImplementedException($"Hitbox type not recognized: {other.GetType().Name}");
    }
}
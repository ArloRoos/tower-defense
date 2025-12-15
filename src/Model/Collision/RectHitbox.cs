using System;
using Microsoft.Xna.Framework;

namespace TowerDefense.Model.Collision;

/// <summary>
/// A rectangular hitbox, configured with a size vector (width and 
/// height).
/// </summary>
public class RectHitbox : Hitbox
{
    public Vector2 Size { get; private set; }

    public Rectangle Rect => new Rectangle(
        (int)(this.Position.X - this.Size.X / 2f),
        (int)(this.Position.Y - this.Size.Y / 2f),
        (int)this.Size.X,
        (int)this.Size.Y);

    public RectHitbox(Vector2 position, Vector2 size, Vector2 offset)
        : base(position, offset)
    {
        this.Size = size;
    }

    /// <inheritdoc/>
    public override bool CollidesWith(Hitbox other)
    {
        if (other is CircleHitbox c)
        {
            return CollisionUtil.RectCollidesWithCircle(this, c);
        }
        else if (other is RectHitbox r)
        {
            return CollisionUtil.RectCollidesWithRect(this, r);
        }

        throw new NotImplementedException($"Hitbox type not recognized: {other.GetType().Name}");
    }
}
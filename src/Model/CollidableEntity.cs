using System;
using Microsoft.Xna.Framework;
using TowerDefense.Model.Collision;

namespace TowerDefense.Model;

/// <summary>
/// An entity with a hitbox which can collide with other entities.
/// </summary>
public abstract class CollidableEntity : Entity
{
    public Hitbox Hitbox { get; set; }

    protected CollidableEntity(Hitbox hitbox, float x, float y)
        : base(x, y)
    {
        this.Hitbox = hitbox;
    }

    public override void Move(Vector2 delta)
    {
        this.Position += delta;
        this.Hitbox.Position += delta;   
    }

    public bool CollidesWith(CollidableEntity other)
    {
        return this.Hitbox.CollidesWith(other.Hitbox);
    }
}
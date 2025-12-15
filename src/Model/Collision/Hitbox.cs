using System;
using Microsoft.Xna.Framework;

namespace TowerDefense.Model.Collision;

/// <summary>
/// Base class for entity hitboxes, containing a position and an 
/// offset.
/// </summary>
public abstract class Hitbox
{
    private Vector2 position;

    public Vector2 Position { 
        get 
        { 
            return this.position + this.Offset; 
        } 
        set 
        { 
            this.position = value;
        } 
    }

    public Vector2 Offset { get; set; }

    protected Hitbox(Vector2 position, Vector2 offset)
    {
        this.Offset = offset;
        this.Position = position;
    }

    /// <summary>
    /// Checks if this hitbox collides with another.
    /// </summary>
    /// <param name="other">The hitbox to check for collision 
    /// with.</param>
    /// <returns>The result of the collision check.</returns>
    /// <exception cref="NotImplementedException">If the type of the 
    /// other hitbox is not recognized.</exception>
    public abstract bool CollidesWith(Hitbox other);
}
using System;
using Microsoft.Xna.Framework;

namespace TowerDefense.Model;

/// <summary>
/// The base class for all renderable entities.
/// </summary>
public abstract class Entity
{
    public Vector2 Position { get; set; }

    protected Entity(float x, float y)
    {
        this.Position = new Vector2(x, y);
    }

    protected Entity(Vector2 position)
    {
        this.Position = position;
    }

    public virtual void Move(Vector2 delta)
    {
        this.Position += delta;   
    }
}
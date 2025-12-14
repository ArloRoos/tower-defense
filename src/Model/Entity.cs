using System;
using Microsoft.Xna.Framework;

namespace TowerDefense.Model;

public abstract class Entity
{
    public Vector2 Position { get; set; }

    protected Entity(float x, float y)
    {
        this.Position = new Vector2(x, y);
    }

    protected Entity(Vector2 initial)
    {
        this.Position = initial;
    }

    public void Move(Vector2 delta)
    {
        this.Position += delta;   
    }
}
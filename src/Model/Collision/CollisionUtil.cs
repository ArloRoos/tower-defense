using System;
using Microsoft.Xna.Framework;

namespace TowerDefense.Model.Collision;

/// <summary>
/// A collection of static utility for collision checks.
/// </summary>
public static class CollisionUtil
{
	/// <summary>
	/// Checks for collision between a rectangle and a circle.
	/// </summary>
	/// <param name="rect">The rectangular hitbox.</param>
	/// <param name="circle">The circular hitbox.</param>
	/// <returns>The result of the collision check.</returns>
    public static bool RectCollidesWithCircle(RectHitbox rect, CircleHitbox circle)
	{
		Vector2 circleCenter = circle.Position;
		Vector2 rectCenter = new Vector2(rect.Rect.Center.X, rect.Rect.Center.Y);
		Vector2 circleDistance = new Vector2(
			Math.Abs(circleCenter.X - rectCenter.X), 
			Math.Abs(circleCenter.Y - rectCenter.Y));

		// Check if the circle's center is inside the rectangle as a preliminary check
		if (rect.Rect.Contains(circleCenter))
		{
			return true;
		}

		// Check the basic cases where the circle radius intersects with an edge
		if (circleDistance.X > (rect.Size.X / 2 + circle.Radius)) { return false; }
		if (circleDistance.Y > (rect.Size.Y / 2 + circle.Radius)) { return false; }

		if (circleDistance.X <= (rect.Size.X / 2)) { return true; }
		if (circleDistance.Y <= (rect.Size.Y / 2)) { return true; }

		// Check the case where the circle might intersect with the rectangle's corner
		double cornerDistanceSquared = 
			Math.Pow(circleDistance.X - rect.Size.X / 2f, 2) + 
			Math.Pow(circleDistance.Y - rect.Size.Y / 2, 2);
		return cornerDistanceSquared <= Math.Pow(circle.Radius, 2);
	}

	/// <summary>
	/// Checks for collision between two rectangles.
	/// </summary>
	/// <param name="rect1">The first rectangular hitbox.</param>
	/// <param name="rect2">The second rectangular hitbox.</param>
	/// <returns>The result of the collision check.</returns>
	public static bool RectCollidesWithRect(RectHitbox rect1, RectHitbox rect2)
	{
		return rect1.Rect.Intersects(rect2.Rect);
	}

	/// <summary>
	/// Checks for collision between two circles.
	/// </summary>
	/// <param name="circle1">The first circular hitbox.</param>
	/// <param name="circle1">The second circular hitbox.</param>
	/// <returns>The result of the collision check.</returns>
	public static bool CircleCollidesWithCircle(CircleHitbox circle1, CircleHitbox circle2)
	{
		return Vector2.Distance(circle1.Position, circle2.Position) <= circle1.Radius + circle2.Radius;
	}
}
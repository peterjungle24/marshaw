using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Sprites
{
    public class CollisionBox
    {
        public Rect Area;

        public CollisionBox(Rect area)
        {
            Area = area;
        }

        public bool IsInside(Vector2 pos)
        {
            /*
            float top = Area.yMax;
            float bottom = Area.yMin;
            float left = Area.xMin;
            float right = Area.xMax;

            bool x_inside = pos.x > left && pos.x < right;  // checks if is inside of the point on horizontal
            bool y_inside = pos.y > bottom && pos.y < top;  // checks if is inside of the point on vertical

            return x_inside && y_inside;
            */
            return Area.Contains(pos);
        }

        /// <summary>
        /// Evaluates whether a given BodyChunk overlaps with the area of the collision rect
        /// </summary>
        public bool IntersectsChunk(BodyChunk chunk, Vector2 camOffset)
        {
            return IntersectsCircle(chunk.pos - camOffset, chunk.rad);
        }

        /// <summary>
        /// Evaluates whether a circle with a given center, and radius (diameter / 2) overlaps with the area of the collision rect
        /// </summary>
        /// <param name="center">The origin position of the circle</param>
        /// <param name="radius">The distance between the origin and the circumference of the circle</param>
        public bool IntersectsCircle(Vector2 center, float radius)
        {
            float diameter = radius * 2;
            Vector2 closestPointOnRectCircumference = Area.GetClosestInteriorPoint(center); //Code borrowed from RXRectExtensions
            return (center - closestPointOnRectCircumference).sqrMagnitude <= diameter;
        }

        public override string ToString()
        {
            return Area.ToString();
        }
    }
}

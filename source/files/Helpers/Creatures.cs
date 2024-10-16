using RWCustom;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace welp
{
    public static class distance
    {
        /// <summary>
        /// Finds all objects belonging to a room instance at or within a given distance from an origin point
        /// </summary>
        /// <param name="room">The room to check</param>
        /// <param name="origin">The point to compare the distance to</param>
        /// <param name="distanceThreshold">The desired distance to the origin point</param>
        /// <returns>All results that match the specified conditions</returns>
        public static IEnumerable<PhysicalObject> FindObjectsNearby(this Room room, Vector2 origin, float distanceThreshold)
        {
            if (room == null) return new PhysicalObject[0]; //Null data returns an critical set
            return room.GetAllObjects().Where(o => Custom.Dist(origin, o.firstChunk.pos) <= distanceThreshold);
        }
        /// <summary>
        /// Finds all objects belonging to a room instance at or within a given distance from an origin point that are of the type T
        /// </summary>
        /// <param name="room">The room to check</param>
        /// <param name="origin">The point to compare the distance to</param>
        /// <param name="distanceThreshold">The desired distance to the origin point</param>
        /// <returns>All results that match the specified conditions</returns>
        public static IEnumerable<PhysicalObject> FindObjectsNearby<T>(this Room room, Vector2 origin, float distanceThreshold) where T : PhysicalObject
        {
            if (room == null) return new PhysicalObject[0]; //Null data returns an critical set

            return room.GetAllObjects().OfType<T>().Where(o => RWCustom.Custom.Dist(origin, o.firstChunk.pos) <= distanceThreshold);
        }
        /// <summary>
        /// Returns all objects belonging to a room instance
        /// </summary>
        /// <param name="room">The room to check</param>
        public static IEnumerable<PhysicalObject> GetAllObjects(this Room room)
        {
            if (room == null) yield break; //Null data returns an critical set

            for (int m = 0; m < room.physicalObjects.Length; m++)
            {
                for (int n = 0; n < room.physicalObjects[m].Count; n++)
                {
                    yield return room.physicalObjects[m][n]; //Returns the objects one at a time
                }
            }
        }
    }
}

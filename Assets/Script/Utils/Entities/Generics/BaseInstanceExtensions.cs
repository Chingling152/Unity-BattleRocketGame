using UnityEngine;
using Entities.Generics;
using System.Collections.Generic;
using System;

namespace Utils.Entities.Generics
{
    public static class BaseInstanceExtensions
    {
        #region Search methods
        /// <summary>
        /// Gets the GameObject near to the current <see cref="BaseInstance"/>
        /// </summary>
        /// <typeparam name="T">Any MonoBehabiour GameObject</typeparam>
        /// <param name="ins">The instance searching</param>
        /// <param name="tag">The tag name of the search object</param>
        /// <param name="maxDistance">The max distance of searching</param>
        /// <returns>Returns the nearest objects that match the parameters</returns>
        public static T FindNearestByTag<T>(this BaseInstance ins, string tag, float maxDistance = float.PositiveInfinity) where T : MonoBehaviour
        {
            var objects = GameObject.FindGameObjectsWithTag(tag);

            if (objects != null)
            {
                List<T> selectedObjects = new List<T>();
                foreach (var item in objects)
                {
                    if (item.TryGetComponent<T>(out var component))
                    {
                        selectedObjects.Add(component);
                    }
                }

                return ins.FindNearests<T>(selectedObjects, maxDistance);
            }
            return null;
        }

        /// <summary>
        /// Searchs between a list of objects the nearest
        /// </summary>
        /// <typeparam name="T">Any MoneBehaviour GameObject</typeparam>
        /// <param name="ins">The instance searching</param>
        /// <param name="objects">The object lists</param>
        /// <param name="maxDistance">The max distance of searching</param>
        /// <returns>Returns the nearest objects that match the parameters</returns>
        public static T FindNearests<T>(this BaseInstance ins, List<T> objects, float maxDistance = float.PositiveInfinity) where T : MonoBehaviour
        {
            if (objects.Count == 0)
                return null;

            T nearestObject = null;
            foreach (T item in objects)
            {
                var dist = Vector2.Distance(ins.transform.position, item.transform.position);

                if (dist <= maxDistance)
                {
                    if (nearestObject == null)
                    {
                        nearestObject = item;
                    }
                    else
                    {
                        var dist2 = Vector2.Distance(ins.transform.position, nearestObject.transform.position);
                        nearestObject = dist < dist2 ? item : nearestObject;
                    }
                }
            }
            return nearestObject;
        }

        [Obsolete("Not Implemented")]
        public static T FindNearestByType<T>(this BaseInstance ins, float maxDistance = float.PositiveInfinity) where T : MonoBehaviour
        {
            var objects = GameObject.FindObjectsOfType<T>();
            return null;
        }
        #endregion
    }
}

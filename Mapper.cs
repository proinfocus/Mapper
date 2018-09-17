using System;
using System.Collections.Generic;
using System.Reflection;

namespace Basics
{
    /// <summary>
    /// Helper class for object to object mapping both single object
    /// and list of objects for matching properties.
    /// </summary>
    public static class Mapper
    {
        /// <summary>
        /// Maps single object to another object for matching properties.
        /// </summary>
        /// <typeparam name="T1">Source type</typeparam>
        /// <typeparam name="T2">Destination type</typeparam>
        /// <param name="source">Source object</param>
        /// <param name="destination">Destination object</param>
        public static void Map<T1, T2>(this T1 source, T2 destination)
        {
            // Throw exception if source is null
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            // Throw exception if destination is null
            if (destination == null)
                throw new ArgumentNullException(nameof(destination));

            // Map each property of the source object to the
            // matching property of the destination object
            foreach (var sp in source.GetType().GetProperties())
            {
                // Get value from source property
                var sourceValue = sp.GetValue(source, null);

                // Get destination property matching the source property
                // having access modifier as Public and should be an instance
                var dp = destination.GetType().GetProperty(sp.Name, BindingFlags.Public | BindingFlags.Instance);

                // If destination property is not null and can be written, set value
                if (null != dp && dp.CanWrite)
                    dp.SetValue(destination, sourceValue, null);
            }
        }

        /// <summary>
        /// Maps list of objects to another list of objects for matching properties.
        /// </summary>
        /// <typeparam name="S">Source type</typeparam>
        /// <typeparam name="D">Destination type</typeparam>
        /// <param name="source">List of source objects</param>
        /// <param name="destination">List of destination objects</param>
        public static void MapList<S,D>(this IList<S> source, IList<D> destination) where D : new()
        {
            // Throw exception if source is null
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            // Throw exception if destination is null
            if (destination == null)
                throw new ArgumentNullException(nameof(destination));

            // Iterate through each object from the list of source objects
            foreach (var s in source)
            {
                // Create new destination object
                var d = new D();

                // Map each property of the source object to the
                // matching property of the destination object
                foreach (var sp in s.GetType().GetProperties())
                {
                    // Get value from source property
                    var sourceValue = sp.GetValue(s, null);

                    // Get destination property matching the source property
                    // having access modifier as Public and should be an instance
                    var dp = d.GetType().GetProperty(sp.Name, BindingFlags.Public | BindingFlags.Instance);
                    
                    // If destination property is not null and can be written, set value
                    if (null != dp && dp.CanWrite)
                        dp.SetValue(d, sourceValue, null);
                }

                // Add newly populuated object to the list of destination object
                destination.Add(d);
            }            
        }
    }
}

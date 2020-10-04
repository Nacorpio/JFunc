using System.Collections.Generic;

using JetBrains.Annotations;

namespace JFunc
{

  public interface IReadOnlyPropertyAccessor
  {
    /// <summary>
    /// Returns a property with the specified name.
    /// </summary>
    /// <typeparam name="T">The property value type.</typeparam>
    /// <param name="propertyName">The name of the property to get.</param>
    /// <returns>The property, if found; otherwise, <c>null</c>.</returns>
    [Pure]
    INProperty<T> GetProperty<T>([NotNull] string propertyName);

    /// <summary>
    /// Returns a property with the specified name.
    /// </summary>
    /// <param name="propertyName">The name of the property to get.</param>
    /// <returns>The property, if found; otherwise, <c>null</c>.</returns>
    [Pure]
    INProperty GetProperty([NotNull] string propertyName);


    /// <summary>
    /// Returns the value of a property with the specified name.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="propertyName">The name of the property to get the value of.</param>
    /// <returns>The property, if found; otherwise, <c>default</c>.</returns>
    [Pure]
    T GetPropertyValue<T>([NotNull] string propertyName);


    /// <summary>
    /// Returns a value indicating whether the specified property exists.
    /// </summary>
    /// <param name="property">The property to find.</param>
    /// <returns><c>true</c> if the property was found; otherwise, <c>false</c>.</returns>
    [Pure]
    bool HasProperty([NotNull] INProperty property);
    
    /// <summary>
    /// Returns a value indicating whether a property with the specified name exists.
    /// </summary>
    /// <param name="propertyName">The name of the property to find.</param>
    /// <returns><c>true</c> if the property was found; otherwise, <c>false</c>.</returns>
    [Pure]
    bool HasProperty([NotNull] string propertyName);


    /// <summary>
    /// Returns a value indicating whether the specified properties exist.
    /// </summary>
    /// <param name="properties">The properties to find.</param>
    /// <returns><c>true</c> if the properties exist; otherwise, <c>false</c>.</returns>
    [Pure]
    bool HasProperties([NotNull] IEnumerable<INProperty> properties);

    /// <summary>
    /// Returns a value indicating whether the properties with the specified names exist.
    /// </summary>
    /// <param name="propertyNames">The names of the properties to find.</param>
    /// <returns><c>true</c> if the properties exist; otherwise, <c>false</c>.</returns>
    [Pure]
    bool HasProperties([NotNull] params string[] propertyNames);


    /// <summary>
    /// Finds and returns a property with the specified name.
    /// </summary>
    /// <param name="propertyName">The name of the property to find.</param>
    /// <param name="result">The resulting property.</param>
    /// <returns><c>true</c> if the property was found; otherwise, <c>false</c>.</returns>
    bool TryGetProperty([NotNull] string propertyName, out INProperty result);

    /// <summary>
    /// Finds and returns the value of a property with the specified name.
    /// </summary>
    /// <typeparam name="T">The property value type.</typeparam>
    /// <param name="propertyName">The name of the property to get the value of.</param>
    /// <param name="result">The resulting property.</param>
    /// <returns><c>true</c> if the property was found; otherwise, <c>false</c>.</returns>
    bool TryGetPropertyValue<T>([NotNull] string propertyName, out T result);


    /// <summary>
    /// Returns a collection of the existing properties.
    /// </summary>
    /// <returns>The existing properties.</returns>
    [Pure]
    IEnumerable<INProperty> GetProperties();
  }

}
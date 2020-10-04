using System.Collections.Generic;

using JetBrains.Annotations;

namespace JFunc
{

  public interface IReadOnlyCompoundAccessor
  {
    /// <summary>
    /// Finds and returns a compound with the specified name.
    /// </summary>
    /// <param name="compoundName">The name of the compound to find.</param>
    /// <returns>The compound, if found; otherwise, <c>null</c>.</returns>
    [Pure]
    INCompound GetCompound([NotNull] string compoundName);


    /// <summary>
    /// Returns a value indicating whether a compound with the specified name exists.
    /// </summary>
    /// <param name="compoundName">The name of the compound to find.</param>
    /// <returns><c>true</c> if the compound was found; otherwise, <c>false</c>.</returns>
    [Pure]
    bool HasCompound([NotNull] string compoundName);

    /// <summary>
    /// Returns a value indicating whether the specified compound exists.
    /// </summary>
    /// <param name="compound">The compound to find.</param>
    /// <returns><c>true</c> if the compound was found; otherwise, <c>false</c>.</returns>
    [Pure]
    bool HasCompound([NotNull] INCompound compound);


    /// <summary>
    /// Returns a value indicating whether the specified collection of compounds exists.
    /// </summary>
    /// <param name="compounds">The compounds to find.</param>
    /// <returns><c>true</c> if the compounds were found; otherwise, <c>false</c>.</returns>
    [Pure]
    bool HasCompounds([NotNull] IEnumerable<INCompound> compounds);

    /// <summary>
    /// Returns a value indicating whether compounds with the specified names exist.
    /// </summary>
    /// <param name="compoundNames">The names of the compounds to find.</param>
    /// <returns><c>true</c> if the compounds were found; otherwise, <c>false</c>.</returns>
    [Pure]
    bool HasCompounds([NotNull] params string[] compoundNames);


    /// <summary>
    /// Finds and returns a compound with the specified name.
    /// </summary>
    /// <param name="compoundName">The name of the compound to find.</param>
    /// <param name="result">The resulting compound.</param>
    /// <returns><c>true</c> if the compound was found; otherwise, <c>false</c>.</returns>
    bool TryGetCompound([NotNull] string compoundName, out INCompound result);


    /// <summary>
    /// Returns a collection of all existing compounds.
    /// </summary>
    /// <returns>A collection of the existing compounds.</returns>
    [Pure]
    IEnumerable<INCompound> GetCompounds();
  }

}
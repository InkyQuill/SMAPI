﻿using System;

namespace StardewModdingAPI
{
    /// <summary>Encapsulates access and changes to content being read from a data file.</summary>
    public interface IContentEventHelper
    {
        /*********
        ** Accessors
        *********/
        /// <summary>The content's locale code, if the content is localised.</summary>
        string Locale { get; }

        /// <summary>The normalised asset name being read. The format may change between platforms; see <see cref="IsAssetName"/> to compare with a known path.</summary>
        string AssetName { get; }

        /// <summary>The content data being read.</summary>
        object Data { get; }


        /*********
        ** Public methods
        *********/
        /// <summary>Get whether the asset name being loaded matches a given name after normalisation.</summary>
        /// <param name="path">The expected asset path, relative to the game's content folder and without the .xnb extension or locale suffix (like 'Data\ObjectInformation').</param>
        bool IsAssetName(string path);

        /// <summary>Get a helper to manipulate the data as a dictionary.</summary>
        /// <typeparam name="TKey">The expected dictionary key.</typeparam>
        /// <typeparam name="TValue">The expected dictionary balue.</typeparam>
        /// <exception cref="InvalidOperationException">The content being read isn't a dictionary.</exception>
        IContentEventHelperForDictionary<TKey, TValue> AsDictionary<TKey, TValue>();

        /// <summary>Get a helper to manipulate the data as an image.</summary>
        /// <exception cref="InvalidOperationException">The content being read isn't an image.</exception>
        IContentEventHelperForImage AsImage();

        /// <summary>Get the data as a given type.</summary>
        /// <typeparam name="TData">The expected data type.</typeparam>
        /// <exception cref="InvalidCastException">The data can't be converted to <typeparamref name="TData"/>.</exception>
        TData GetData<TData>();

        /// <summary>Replace the entire content value with the given value. This is generally not recommended, since it may break compatibility with other mods or different versions of the game.</summary>
        /// <param name="value">The new content value.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="value"/> is null.</exception>
        /// <exception cref="InvalidCastException">The <paramref name="value"/>'s type is not compatible with the loaded asset's type.</exception>
        void ReplaceWith(object value);
    }
}

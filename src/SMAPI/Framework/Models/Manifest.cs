using System.Collections.Generic;
using Newtonsoft.Json;
using StardewModdingAPI.Framework.Serialisation.SmapiConverters;

namespace StardewModdingAPI.Framework.Models
{
    /// <summary>A manifest which describes a mod for SMAPI.</summary>
    internal class Manifest : IManifest
    {
        /*********
        ** Accessors
        *********/
        /// <summary>The mod name.</summary>
        public string Name { get; set; }

        /// <summary>A brief description of the mod.</summary>
        public string Description { get; set; }

        /// <summary>The mod author's name.</summary>
        public string Author { get; set; }

        /// <summary>The mod version.</summary>
        public ISemanticVersion Version { get; set; }

        /// <summary>The minimum SMAPI version required by this mod, if any.</summary>
        public ISemanticVersion MinimumApiVersion { get; set; }

        /// <summary>The name of the DLL in the directory that has the <see cref="IMod.Entry"/> method. Mutually exclusive with <see cref="ContentPackFor"/>.</summary>
        public string EntryDll { get; set; }

        /// <summary>The mod which will read this as a content pack. Mutually exclusive with <see cref="IManifest.EntryDll"/>.</summary>
        [JsonConverter(typeof(ManifestContentPackForConverter))]
        public IManifestContentPackFor ContentPackFor { get; set; }

        /// <summary>The other mods that must be loaded before this mod.</summary>
        [JsonConverter(typeof(ManifestDependencyArrayConverter))]
        public IManifestDependency[] Dependencies { get; set; }

        /// <summary>The namespaced mod IDs to query for updates (like <c>Nexus:541</c>).</summary>
        public string[] UpdateKeys { get; set; }

        /// <summary>The unique mod ID.</summary>
        public string UniqueID { get; set; }

        /// <summary>Any manifest fields which didn't match a valid field.</summary>
        [JsonExtensionData]
        public IDictionary<string, object> ExtraFields { get; set; }
    }
}

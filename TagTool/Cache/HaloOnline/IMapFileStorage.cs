using TagTool.BlamFile;

namespace TagTool.Cache.HaloOnline
{
    public interface IMapFileStorage
    {
        /// <summary>
        /// Retrieves the list of map files.
        /// </summary>
        /// <returns>An array of <see cref="MapFile"/></returns>
        MapFile[] GetAll();

        /// <summary>
        /// Finds a map file by name.
        /// </summary>
        /// <param name="name">Name of the map (without the .map extension)</param>
        /// <returns>The <see cref="MapFile"/> or null if not found.</returns>
        MapFile FindByName(string name);

        /// <summary>
        /// Finds a map file by map id.
        /// </summary>
        /// <param name="mapId">The map id of the map</param>
        /// <returns>The <see cref="MapFile"/> or null if not found.</returns>
        MapFile FindByMapId(int mapId);

        /// <summary>
        /// Add a map file.
        /// </summary>
        /// <param name="mapFile">The map file to add</param>
        /// <param name="tagCacheIndex">The index of the tag cache to assign - Only applicable to <see cref="GameCacheModPackage"/></param>
        /// <param name="overwrite">If true overwrites the map file if it already exists</param>
        /// <remarks>
        /// If a map with the same map id exists and <paramref name="overwrite"/> is true, it'll be overwritten, 
        /// otherwise an <see cref="System.IO.IOException"/> will be thrown.
        /// </remarks>
        void Add(MapFile mapFile, int tagCacheIndex = -1, bool overwrite = true);

        /// <summary>
        /// Delete a map file.
        /// </summary>
        /// <param name="name">Name of the map file to delete (without the .map extension)</param>
        /// <remarks>
        /// If the map file does not exist, no exception will be thrown.
        /// </remarks>
        void Delete(string name);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using TagTool.Common;
using TagTool.Tags;

namespace TagTool.Cache
{
    public static class CacheVersionDetection
    {
        /// <summary>
        /// Detects the engine that a tags.dat was built for based on its timestamp.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        public static CacheVersion DetectFromTimestamp(string timestamp)
        {
            if (EldoradoTimestampMapping.TryGetValue(timestamp, out CacheVersion version))
                return version;
            else
                return CacheVersion.Unknown;
        }

        /// <summary>
        /// Gets the timestamp for a version.
        /// </summary>
        /// <param name="version">The version.</param>
        public static string GetTimestamp(CacheVersion version)
        {
            if (EldoradoTimestampMapping.ContainsValue(version))
                return EldoradoTimestampMapping.First(x => x.Value == version).Key;
            else 
                return null;
        }

        /// <summary>
        /// Gets the <see cref="CacheVersion"/> associated with the specified build name.
        /// </summary>
        /// <param name="buildName">The build name.</param>
        /// <param name="version"></param>
        /// <param name="cachePlatform"></param>
        /// <returns>The version, or <see cref="CacheVersion.Unknown"/> if not found.</returns>
        public static void GetFromBuildName(string buildName, ref CacheVersion version, ref CachePlatform cachePlatform)
        {
            switch (buildName)
            {
                case "01.09.25.2247":
                case "01.10.12.2276":
                    version = CacheVersion.HaloXbox;
                    cachePlatform = CachePlatform.Original;
                    break;
                case "01.00.00.0564":
                    version = CacheVersion.HaloPC;
                    cachePlatform = CachePlatform.Original;
                    break;
                case "01.00.00.0609":
                    version = CacheVersion.HaloCustomEdition;
                    cachePlatform = CachePlatform.Original;
                    break;
                case "02.01.07.4998":
                    version = CacheVersion.Halo2Alpha;
                    cachePlatform = CachePlatform.Original;
                    break;
                case "02.06.28.07902":
                    version = CacheVersion.Halo2Beta;
                    cachePlatform = CachePlatform.Original;
                    break;
                case "02.09.27.09809":
                    version = CacheVersion.Halo2Xbox;
                    cachePlatform = CachePlatform.Original;
                    break;
                case "11081.07.04.30.0934.main":
                case "11091.07.05.11.1104.main":
                case "11122.07.08.24.1808.main":
                    version = CacheVersion.Halo2PC;
                    cachePlatform = CachePlatform.Original;
                    break;
                case "09699.07.05.01.1534.delta":
                   version = CacheVersion.Halo3Beta;
                    cachePlatform = CachePlatform.Original;
                    break;
                case "11855.07.08.20.2317.halo3_ship":
                case "12065.08.08.26.0819.halo3_ship":
                    version = CacheVersion.Halo3Retail;
                    cachePlatform = CachePlatform.Original;
                    break;
                case "13895.09.04.27.2201.atlas_relea":
                    version = CacheVersion.Halo3ODST;
                    cachePlatform = CachePlatform.Original;
                    break;
                case "eldewrito":
                    version = CacheVersion.EldoradoED;
                    cachePlatform = CachePlatform.Original;
                    break;
                case "1.106708 cert_ms23":
                    version = CacheVersion.Eldorado106708;
                    cachePlatform = CachePlatform.Original;
                    break;
                case "1.155080 cert_ms23":
                    version = CacheVersion.Eldorado155080;
                    cachePlatform = CachePlatform.Original;
                    break;
                case "1.235640 cert_ms25":
                    version = CacheVersion.Eldorado235640;
                    cachePlatform = CachePlatform.Original;
                    break;
                case "Jun 12 2015 13:02:50":
                    version = CacheVersion.Eldorado301003;
                    cachePlatform = CachePlatform.Original;
                    break;
                case "0.4.1.327043 cert_MS26_new":
                    version = CacheVersion.Eldorado327043;
                    cachePlatform = CachePlatform.Original;
                    break;
                case "8.1.372731 Live":
                    version = CacheVersion.Eldorado372731;
                    cachePlatform = CachePlatform.Original;
                    break;
                case "0.0.416097 Live":
                    version = CacheVersion.Eldorado416097;
                    cachePlatform = CachePlatform.Original;
                    break;
                case "10.1.430475 Live":
                    version = CacheVersion.Eldorado430475;
                    cachePlatform = CachePlatform.Original;
                    break;
                case "10.1.454665 Live":
                    version = CacheVersion.Eldorado454665;
                    cachePlatform = CachePlatform.Original;
                    break;
                case "10.1.449175 Live":
                    version = CacheVersion.Eldorado449175;
                    cachePlatform = CachePlatform.Original;
                    break;
                case "11.1.498295 Live":
                    version = CacheVersion.Eldorado498295;
                    cachePlatform = CachePlatform.Original;
                    break;
                case "11.1.530605 Live":
                    version = CacheVersion.Eldorado530605;
                    cachePlatform = CachePlatform.Original;
                    break;
                case "11.1.532911 Live":
                    version = CacheVersion.Eldorado532911;
                    cachePlatform = CachePlatform.Original;
                    break;
                case "11.1.554482 Live":
                    version = CacheVersion.Eldorado554482;
                    cachePlatform = CachePlatform.Original;
                    break;
                case "11.1.571627 Live":
                    version = CacheVersion.Eldorado571627;
                    cachePlatform = CachePlatform.Original;
                    break;
                case "11.1.601838 Live":
                    version = CacheVersion.Eldorado604673;
                    cachePlatform = CachePlatform.Original;
                    break;
                case "12.1.700123 cert_ms30_oct19":
                    version = CacheVersion.Eldorado700123;
                    cachePlatform = CachePlatform.Original;
                    break;
                case "08516.10.02.19.1607.omaha_alpha":
                    version = CacheVersion.HaloReachAlpha;
                    cachePlatform = CachePlatform.Original;
                    break;
                case "09449.10.03.25.1545.omaha_beta":
                    version = CacheVersion.HaloReachPreBeta;
                    cachePlatform = CachePlatform.Original;
                    break;
                case "09730.10.04.09.1309.omaha_delta":
                    version = CacheVersion.HaloReachBeta;
                    cachePlatform = CachePlatform.Original;
                    break;
                case "11860.10.07.24.0147.omaha_relea":
                    version = CacheVersion.HaloReach;
                    cachePlatform = CachePlatform.Original;
                    break;
                case "15119.12.05.31.0400.e3m60":
                    version = CacheVersion.Halo4E3;
                    cachePlatform = CachePlatform.Original;
                    break;
                case "20810.12.09.22.1647.main":
                case "21122.12.11.21.0101.main":
                case "21165.12.12.12.0112.main":
                case "21339.13.02.05.0117.main":
                case "21391.13.03.13.1711.main":
                case "21401.13.04.23.1849.main":
                case "21501.13.08.06.2311.main":
                case "21522.13.10.17.1936.main":
                    version = CacheVersion.Halo4;
                    cachePlatform = CachePlatform.Original;
                    break;

                case "01.03.43.0000":
                    version = CacheVersion.HaloCustomEdition;
                    cachePlatform = CachePlatform.MCC;
                    break;

                // TODO: Handle this bullshit (FUCK U 343)
                case "":
                    version = CacheVersion.Halo2PC;
                    cachePlatform = CachePlatform.MCC;
                    break;

                case "Dec 21 2023 22:31:37":
                    version = CacheVersion.Halo3Retail;
                    cachePlatform = CachePlatform.MCC;
                    break;

                case "Oct  1 2014 16:20:07":
                case "Oct 30 2014 19:01:55":
                    version = CacheVersion.Halo3XboxOne;
                    cachePlatform = CachePlatform.MCC;
                    break;

                case "May 16 2023 11:44:41":
                    version = CacheVersion.Halo3ODST;
                    cachePlatform = CachePlatform.MCC;
                    break;

                case "May 29 2019 00:44:52":
                case "Jun 24 2019 00:36:03":
                case "Jul 30 2019 14:17:16":
                case "Oct 24 2019 15:56:32":
                    version = CacheVersion.HaloReach;
                    cachePlatform = CachePlatform.MCC;
                    break;

                case "Apr  1 2023 17:35:22":
                    version = CacheVersion.Halo4;
                    cachePlatform = CachePlatform.MCC;
                    break;

                case "Jun 13 2023 20:21:18":
                    version = CacheVersion.Halo2AMP;
                    cachePlatform = CachePlatform.MCC;
                    break;

                default:
                    version = CacheVersion.Unknown;
                    cachePlatform = CachePlatform.All;
                    break;
            }
        }

        /// <summary>
        /// Gets the version string corresponding to an <see cref="CacheVersion"/> value.
        /// </summary>
        /// <param name="version">The version.</param>
        /// <param name="platform"></param>
        /// <returns>The version string.</returns>
        public static string GetBuildName(CacheVersion version, CachePlatform platform)
        {
            if (platform == CachePlatform.MCC)
            {
                switch (version)
                {
                    case CacheVersion.HaloCustomEdition:
                        return "01.03.43.0000";
                    case CacheVersion.Halo2PC:
                        // TODO: Handle this bullshit (FUCK U 343)
                        return "";
                    case CacheVersion.Halo3Retail:
                        return "Dec 21 2023 22:31:37";
                    case CacheVersion.Halo3ODST:
                        return "May 16 2023 11:44:41";
                    case CacheVersion.HaloReach:
                        return "Jun 21 2023 15:35:31";
                    case CacheVersion.Halo4:
                        return "Apr  1 2023 17:35:22";
                    case CacheVersion.Halo2AMP:
                        return "Jun 13 2023 20:21:18";
                    default:
                        return version.ToString();
                }
            }
            else
            {
                switch (version)
                {
                    case CacheVersion.HaloXbox:
                        return "01.10.12.2276";
                    case CacheVersion.HaloPC:
                        return "01.00.00.0564";
                    case CacheVersion.HaloCustomEdition:
                        return "01.00.00.0609";
                    case CacheVersion.Halo2Alpha:
                        return "02.01.07.4998";
                    case CacheVersion.Halo2Beta:
                        return "02.06.28.07902";
                    case CacheVersion.Halo2Xbox:
                        return "02.09.27.09809";
                    case CacheVersion.Halo2PC:
                        return "11081.07.04.30.0934.main";
                    case CacheVersion.Halo3Beta:
                        return "09699.07.05.01.1534.delta";
                    case CacheVersion.Halo3Retail:
                        return "11855.07.08.20.2317.halo3_ship";
                    case CacheVersion.Halo3XboxOne:
                        return "Oct  1 2014 16:20:07";
                    case CacheVersion.Halo3ODST:
                        return "13895.09.04.27.2201.atlas_relea";
                    case CacheVersion.EldoradoED:
                        return "eldewrito";
                    case CacheVersion.Eldorado106708:
                        return "1.106708 cert_ms23";
                    case CacheVersion.Eldorado155080:
                        return "1.155080 cert_ms23";
                    case CacheVersion.Eldorado235640:
                        return "1.235640 cert_ms25";
                    case CacheVersion.Eldorado301003:
                        return "Jun 12 2015 13:02:50";
                    case CacheVersion.Eldorado327043:
                        return "0.4.1.327043 cert_MS26_new";
                    case CacheVersion.Eldorado372731:
                        return "8.1.372731 Live";
                    case CacheVersion.Eldorado416097:
                        return "0.0.416097 Live";
                    case CacheVersion.Eldorado430475:
                        return "10.1.430475 Live";
                    case CacheVersion.Eldorado454665:
                        return "10.1.454665 Live";
                    case CacheVersion.Eldorado449175:
                        return "10.1.449175 Live";
                    case CacheVersion.Eldorado498295:
                        return "11.1.498295 Live";
                    case CacheVersion.Eldorado530605:
                        return "11.1.530605 Live";
                    case CacheVersion.Eldorado532911:
                        return "11.1.532911 Live";
                    case CacheVersion.Eldorado554482:
                        return "11.1.554482 Live";
                    case CacheVersion.Eldorado571627:
                        return "11.1.571627 Live";
                    case CacheVersion.Eldorado604673:
                        return "11.1.601838 Live";
                    case CacheVersion.Eldorado700123:
                        return "12.1.700123 cert_ms30_oct19";
                    case CacheVersion.HaloReachAlpha:
                        return "08516.10.02.19.1607.omaha_alpha";
                    case CacheVersion.HaloReachPreBeta:
                        return "09449.10.03.25.1545.omaha_beta";
                    case CacheVersion.HaloReachBeta:
                        return "09730.10.04.09.1309.omaha_delta";
                    case CacheVersion.HaloReach:
                        return "11860.10.07.24.0147.omaha_relea";
                    case CacheVersion.HaloReach11883:
                        return "11883.10.10.25.1227.dlc_1_ship__tag_test";
                    case CacheVersion.Halo4E3:
                        return "15119.12.05.31.0400.e3m60";
                    case CacheVersion.Halo4:
                        return "20810.12.09.22.1647.main";
                    default:
                        return version.ToString();
                }
            }
            
        }

        /// <summary>
        /// Checks if a <see cref="CacheVersion"/> is in Little-Endian or Big-Endian.
        /// </summary>
        /// <param name="version">The <see cref="CacheVersion"/> to check the endianness of.</param>
        /// <param name="cachePlatform"></param>
        /// <returns>True if the <see cref="CacheVersion"/> is Little-Endian, false otherwise.</returns>
        public static bool IsLittleEndian(CacheVersion version, CachePlatform cachePlatform)
		{
            if (cachePlatform == CachePlatform.MCC)
                return true;

			switch (version)
			{
				case CacheVersion.Halo3Beta:
				case CacheVersion.Halo3Retail:
				case CacheVersion.Halo3ODST:
                case CacheVersion.HaloReachAlpha:
                case CacheVersion.HaloReachPreBeta:
                case CacheVersion.HaloReachBeta:
                case CacheVersion.HaloReach:
                case CacheVersion.HaloReach11883:
                case CacheVersion.Halo4220811:
                case CacheVersion.Halo4280911:
                case CacheVersion.Halo4E3:
                case CacheVersion.Halo4:
                case CacheVersion.Halo4140113:
                case CacheVersion.Halo4131113:
                    return false;

                case CacheVersion.HaloXbox:
                case CacheVersion.HaloPC:
                case CacheVersion.HaloCustomEdition:
                case CacheVersion.Halo2Alpha:
                case CacheVersion.Halo2Beta:
				case CacheVersion.Halo2Xbox:
				case CacheVersion.Halo2PC:
				case CacheVersion.EldoradoED:
                case CacheVersion.Eldorado106708:
                case CacheVersion.Eldorado155080:
                case CacheVersion.Eldorado235640:
				case CacheVersion.Eldorado301003:
				case CacheVersion.Eldorado327043:
				case CacheVersion.Eldorado372731:
				case CacheVersion.Eldorado416097:
				case CacheVersion.Eldorado430475:
				case CacheVersion.Eldorado454665:
				case CacheVersion.Eldorado449175:
				case CacheVersion.Eldorado498295:
				case CacheVersion.Eldorado530605:
				case CacheVersion.Eldorado532911:
				case CacheVersion.Eldorado554482:
                case CacheVersion.Eldorado571627:
                case CacheVersion.Eldorado604673:
                case CacheVersion.Eldorado700123:
                    return true;

				default:
					throw new NotImplementedException(version.ToString());
			}
		}

        /// <summary>
        /// Determines whether a field exists in the given CacheVersion. Defines a priority : Versions, Gen, Min/Max.
        /// </summary>
        /// <param name="attr"></param>
        /// <param name="compare"></param>
        /// <returns></returns>
        public static bool AttributeInCacheVersion(TagFieldAttribute attr, CacheVersion compare)
        {
            if (attr.Version != CacheVersion.Unknown)
                if (attr.Version != compare)
                    return false;

            if (attr.Gen != CacheGeneration.Unknown)
                if (!IsInGen(attr.Gen, compare))
                    return false;

            if (attr.MinVersion != CacheVersion.Unknown || attr.MaxVersion != CacheVersion.Unknown)
                if (!IsBetween(compare, attr.MinVersion, attr.MaxVersion))
                    return false;

            return true;
        }

        public static bool AttributeInCacheVersion(TagEnumMemberAttribute attr, CacheVersion compare)
        {
            if (attr.Version != CacheVersion.Unknown)
                if (attr.Version != compare)
                    return false;

            if (attr.Gen != CacheGeneration.Unknown)
                if (!IsInGen(attr.Gen, compare))
                    return false;

            if (attr.MinVersion != CacheVersion.Unknown || attr.MaxVersion != CacheVersion.Unknown)
                if (!IsBetween(compare, attr.MinVersion, attr.MaxVersion))
                    return false;

            return true;
        }

        public static bool AttributeInCacheVersion(TagStructureAttribute attr, CacheVersion compare)
        {
            if (attr.Version != CacheVersion.Unknown)
                if (attr.Version != compare)
                    return false;

            if (attr.Gen != CacheGeneration.Unknown)
                if (!IsInGen(attr.Gen, compare))
                    return false;

            if (attr.MinVersion != CacheVersion.Unknown || attr.MaxVersion != CacheVersion.Unknown)
                if (!IsBetween(compare, attr.MinVersion, attr.MaxVersion))
                    return false;

            return true;
        }

        public static bool AttributeInPlatform(TagFieldAttribute attr, CachePlatform compare)
        {
            return ComparePlatform(attr.Platform, compare);
        }

        public static bool AttributeInPlatform(TagEnumMemberAttribute attr, CachePlatform compare)
        {
            return ComparePlatform(attr.Platform, compare);
        }

        public static bool AttributeInPlatform(TagStructureAttribute attr, CachePlatform compare)
        {
            return ComparePlatform(attr.Platform, compare);
        }

        public static bool ComparePlatform(CachePlatform attributeCachePlatform, CachePlatform compare)
        {
            if (attributeCachePlatform == CachePlatform.All)
                return true;
            else
                return attributeCachePlatform == compare;
        }

        /// <summary>
        /// Compares two version numbers.
        /// </summary>
        /// <param name="lhs">The left-hand version number.</param>
        /// <param name="rhs">The right-hand version number.</param>
        /// <returns>A positive value if the left version is newer, a negative value if the right version is newer, and 0 if the versions are equivalent.</returns>
        public static int Compare(CacheVersion lhs, CacheVersion rhs)
        {
            // Assume the enum values are in order by release date
            return (int)lhs - (int)rhs;
        }

        /// <summary>
        /// Determines whether a version number is between two other version numbers (inclusive).
        /// </summary>
        /// <param name="compare">The version number to compare. If this is <see cref="CacheVersion.Unknown"/>, this function will always return <c>true</c>.</param>
        /// <param name="min">The minimum version number. If this is <see cref="CacheVersion.Unknown"/>, then the lower bound will be ignored.</param>
        /// <param name="max">The maximum version number. If this is <see cref="CacheVersion.Unknown"/>, then the upper bound will be ignored.</param>
        /// <returns></returns>
        public static bool IsBetween(CacheVersion compare, CacheVersion min, CacheVersion max)
        {
            if (compare == CacheVersion.Unknown)
                return true;

            if (min != CacheVersion.Unknown && Compare(compare, min) < 0)
                return false;

            return (max == CacheVersion.Unknown || Compare(compare, max) <= 0);
        }

        /// <summary>
        /// Determine whether a CacheVersion belongs to a CacheGeneration
        /// </summary>
        /// <param name="gen"></param>
        /// <param name="compare"></param>
        /// <returns></returns>
        public static bool IsInGen(CacheGeneration gen, CacheVersion compare)
        {
            if (compare == CacheVersion.Unknown || gen == CacheGeneration.Unknown)
                return true;
            else
                return GetGeneration(compare) == gen;
        }

        public static bool InCacheBuildType(CacheBuildType buildType, CacheVersion compare)
        {
            if (compare == CacheVersion.Unknown || buildType == CacheBuildType.Unknown)
                return true;
            else
                return GetCacheBuildType(compare) == buildType;
        }

        public static CacheBuildType GetCacheBuildType(CacheVersion version)
        {
            switch (version)
            {
                case CacheVersion.HaloReach11883:
                case CacheVersion.Halo4220811:
                case CacheVersion.Halo4280911:
                case CacheVersion.Halo4140113:
                case CacheVersion.Halo4131113:
                    return CacheBuildType.TagsBuild;
            }

            return CacheBuildType.ReleaseBuild;
        }

        public static bool TestAttribute(TagFieldAttribute a, CacheVersion version, CachePlatform platform)
        {
            if (!InCacheBuildType(a.BuildType, version))
                return false;
            if (!IsInGen(a.Gen, version))
                return false;
            if (!AttributeInPlatform(a, platform))
                return false;
            if (!AttributeInCacheVersion(a, version))
                return false;

            return true;
        }

        public static bool TestAttribute(TagEnumMemberAttribute a, CacheVersion version, CachePlatform platform)
        {
            if (!IsInGen(a.Gen, version))
                return false;
            if (!AttributeInPlatform(a, platform))
                return false;
            if (!AttributeInCacheVersion(a, version))
                return false;

            return true;
        }

        public static bool TestAttribute(TagStructureAttribute a, CacheVersion version, CachePlatform platform)
        {
            if (!InCacheBuildType(a.BuildType, version))
                return false;
           
            if (!AttributeInPlatform(a, platform))
                return false;
            if (!IsInGen(a.Gen, version))
                return false;
            if (!AttributeInCacheVersion(a, version))
                return false;

            return true;
        }

        /// <summary>
        /// Get CacheGeneration from CacheVersion
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public static CacheGeneration GetGeneration(this CacheVersion version)
        {
            switch (version)
            {
                case CacheVersion.HaloXbox:
                case CacheVersion.HaloPC:
                case CacheVersion.HaloCustomEdition:
                    return CacheGeneration.First;

                case CacheVersion.Halo2Alpha:
                case CacheVersion.Halo2PC:
                case CacheVersion.Halo2Xbox:
                case CacheVersion.Halo2Beta:
                    return CacheGeneration.Second;

                case CacheVersion.Halo3Beta:
                case CacheVersion.Halo3Retail:
                case CacheVersion.Halo3XboxOne:
                case CacheVersion.Halo3ODST:
                case CacheVersion.HaloReachAlpha:
                case CacheVersion.HaloReachPreBeta:
                case CacheVersion.HaloReachBeta:
                case CacheVersion.HaloReach:
                case CacheVersion.HaloReach11883:
                    return CacheGeneration.Third;

                case CacheVersion.EldoradoED:
                case CacheVersion.Eldorado106708:
                case CacheVersion.Eldorado155080:
                case CacheVersion.Eldorado235640:
                case CacheVersion.Eldorado301003:
                case CacheVersion.Eldorado327043:
                case CacheVersion.Eldorado372731:
                case CacheVersion.Eldorado416097:
                case CacheVersion.Eldorado430475:
                case CacheVersion.Eldorado454665:
                case CacheVersion.Eldorado449175:
                case CacheVersion.Eldorado498295:
                case CacheVersion.Eldorado530605:
                case CacheVersion.Eldorado532911:
                case CacheVersion.Eldorado554482:
                case CacheVersion.Eldorado571627:
                case CacheVersion.Eldorado604673:
                case CacheVersion.Eldorado700123:
                    return CacheGeneration.Eldorado;

                case CacheVersion.Halo4220811:
                case CacheVersion.Halo4280911:
                case CacheVersion.Halo4E3:
                case CacheVersion.Halo4:
                case CacheVersion.Halo4140113:
                case CacheVersion.Halo4131113:
                case CacheVersion.Halo2AMP:
                    return CacheGeneration.Fourth;

                default:
                    return CacheGeneration.Unknown;
            }
        }

        public static PlatformType GetPlatformType(CachePlatform cachePlatform)
        {
            switch (cachePlatform)
            {
                case CachePlatform.MCC:
                    return PlatformType._64Bit;
                case CachePlatform.Original:
                    return PlatformType._32Bit;
                default:
                    throw new Exception($"Unknown cache platform {cachePlatform}");
            }
        }

        public static GameTitle GetGameTitle(CacheVersion version)
        {
            switch (version)
            {
                case CacheVersion.HaloXbox:
                case CacheVersion.HaloPC:
                case CacheVersion.HaloCustomEdition:
                    return GameTitle.HaloCE;
                case CacheVersion.Halo2Alpha:
                case CacheVersion.Halo2Beta:
                case CacheVersion.Halo2Xbox:
                case CacheVersion.Halo2PC:
                    return GameTitle.Halo2;
                case CacheVersion.Halo3Beta:
                case CacheVersion.Halo3Retail:
                case CacheVersion.Halo3XboxOne:
                    return GameTitle.Halo3;
                case CacheVersion.Halo3ODST:
                    return GameTitle.Halo3ODST;
                case CacheVersion.EldoradoED:
                case CacheVersion.Eldorado106708:
                case CacheVersion.Eldorado155080:
                case CacheVersion.Eldorado235640:
                case CacheVersion.Eldorado301003:
                case CacheVersion.Eldorado327043:
                case CacheVersion.Eldorado372731:
                case CacheVersion.Eldorado416097:
                case CacheVersion.Eldorado430475:
                case CacheVersion.Eldorado454665:
                case CacheVersion.Eldorado449175:
                case CacheVersion.Eldorado498295:
                case CacheVersion.Eldorado530605:
                case CacheVersion.Eldorado532911:
                case CacheVersion.Eldorado554482:
                case CacheVersion.Eldorado571627:
                case CacheVersion.Eldorado604673:
                case CacheVersion.Eldorado700123:
                    return GameTitle.Eldorado;
                case CacheVersion.HaloReachAlpha:
                case CacheVersion.HaloReachPreBeta:
                case CacheVersion.HaloReachBeta:
                case CacheVersion.HaloReach:
                case CacheVersion.HaloReach11883:
                    return GameTitle.HaloReach;
                case CacheVersion.Halo4220811:
                case CacheVersion.Halo4280911:
                case CacheVersion.Halo4E3:
                case CacheVersion.Halo4:
                case CacheVersion.Halo4140113:
                case CacheVersion.Halo4131113:
                    return GameTitle.Halo4;
                case CacheVersion.Halo2AMP:
                    return GameTitle.Halo2AMP;
                default:
                    return GameTitle.Unknown;
            }
        }

        /// <summary>
        /// tags.dat timestamps for each halo online game version.
        /// Timestamps in here map directly to a <see cref="CacheVersion"/> value.
        /// </summary>
        private static readonly Dictionary<string, CacheVersion> EldoradoTimestampMapping = new Dictionary<string, CacheVersion>
        {
            ["2021-07-05 14:06:23.1101597"] = CacheVersion.EldoradoED,
            ["2015-03-20 14:40:23.9499012"] = CacheVersion.Eldorado106708,
            ["2015-04-10 11:37:39.234805"] = CacheVersion.Eldorado155080,
            ["2015-05-28 13:28:06.2346058"] = CacheVersion.Eldorado235640,
            ["2015-06-12 13:42:28.6445524"] = CacheVersion.Eldorado301003,
            ["2015-06-29 09:41:56.0458507"] = CacheVersion.Eldorado327043,
            ["2015-07-15 11:03:59.6118255"] = CacheVersion.Eldorado372731,
            ["2015-08-01 14:19:18.9114103"] = CacheVersion.Eldorado416097,
            ["2015-08-07 13:56:43.4159845"] = CacheVersion.Eldorado430475,
            ["2015-08-19 09:47:11.625466"] = CacheVersion.Eldorado454665,
            ["2015-08-27 15:51:04.5809862"] = CacheVersion.Eldorado449175,
            ["2015-09-04 13:36:11.6879375"] = CacheVersion.Eldorado498295,
            ["2015-09-16 14:59:54.5946004"] = CacheVersion.Eldorado530605,
            ["2015-09-17 11:53:39.8634503"] = CacheVersion.Eldorado532911,
            ["2015-09-29 10:14:31.9550501"] = CacheVersion.Eldorado554482,
            ["2015-10-01 16:02:13.0693956"] = CacheVersion.Eldorado571627,
            ["2015-10-15 10:57:15.1772672"] = CacheVersion.Eldorado604673,
            ["2015-11-26 10:26:02.8935939"] = CacheVersion.Eldorado700123
        };
    }

    public enum CacheVersion : int
    {
        Unknown = -1,
        HaloXbox,
        HaloPC,
        HaloCustomEdition,
        Halo2Alpha,
        Halo2Beta,
        Halo2Xbox,
        Halo2PC,
        Halo3Beta,
        Halo3Retail,
        Halo3XboxOne,
        Halo3ODST,
        EldoradoED,
        Eldorado106708,
        Eldorado155080,
        Eldorado235640,
        Eldorado301003,
        Eldorado327043,
        Eldorado372731,
        Eldorado416097,
        Eldorado430475,
        Eldorado454665,
        Eldorado449175,
        Eldorado498295,
        Eldorado530605,
        Eldorado532911,
        Eldorado554482,
        Eldorado571627,
        Eldorado604673,
        Eldorado700123,
        HaloReachAlpha,
        HaloReachPreBeta,
        HaloReachBeta,
        HaloReach,
        HaloReach11883,
        Halo4220811,
        Halo4280911,
        Halo4E3,
        Halo4,
        Halo4140113,
        Halo4131113,
        Halo2AMP
    }

    public enum CacheGeneration : int
    {
        Unknown = -1,
        First = 1,
        Second = 2,
        Third = 3,
        Eldorado = 4,
        Fourth = 5
    }

    public enum CachePlatform : byte
    {
        /// <summary>
        /// Belongs to both the original version and the MCC version
        /// </summary>
        All = 0,

        /// <summary>
        /// Belongs only to the original version (xbox, xbox 360, PC (not MCC))
        /// </summary>
        Original = 1,

        /// <summary>
        /// Belongs only to the MCC version
        /// </summary>
        MCC = 2
    }

    public enum PlatformType : byte
    {
        _32Bit = 0,
        _64Bit = 1
    }

    public enum CacheBuildType
    {
        Unknown,
        TagsBuild,
        ReleaseBuild
    }
}
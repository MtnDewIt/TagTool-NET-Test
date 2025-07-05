using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagTool.Cache;
using TagTool.Tags.Definitions;

namespace TagTool.Porting.Gen3
{
    public partial class PortingContextGen3
    {
        private ObjectTypeFlags ConvertObjectTypeFlags(ObjectTypeFlags flags)
        {
            switch (BlamCache.Version)
            {
                case CacheVersion.Halo2Vista:
                case CacheVersion.Halo2Xbox:
                    if (!Enum.TryParse(flags.Halo2.ToString(), out flags.Halo3ODST))
                        throw new FormatException(BlamCache.Version.ToString());
                    break;

                case CacheVersion.Halo3Retail:
                    if (!Enum.TryParse(flags.Halo3Retail.ToString(), out flags.Halo3ODST))
                        throw new FormatException(BlamCache.Version.ToString());
                    break;
            }

            return flags;
        }
    }
}

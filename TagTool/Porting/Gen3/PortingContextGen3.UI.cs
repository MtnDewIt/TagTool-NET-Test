using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagTool.Tags.Definitions.Common;

namespace TagTool.Porting.Gen3
{
    public partial class PortingContextGen3
    {
        public object RescaleGUIDef(GuiDefinition GUIdef, float scalefactor)
        {
            GUIdef.Bounds480i.Top = (short)(GUIdef.Bounds480i.Top * scalefactor);
            GUIdef.Bounds480i.Left = (short)(GUIdef.Bounds480i.Left * scalefactor);
            GUIdef.Bounds480i.Bottom = (short)(GUIdef.Bounds480i.Bottom * scalefactor);
            GUIdef.Bounds480i.Right = (short)(GUIdef.Bounds480i.Right * scalefactor);
            GUIdef.Bounds720p.Top = (short)(GUIdef.Bounds720p.Top * scalefactor);
            GUIdef.Bounds720p.Left = (short)(GUIdef.Bounds720p.Left * scalefactor);
            GUIdef.Bounds720p.Bottom = (short)(GUIdef.Bounds720p.Bottom * scalefactor);
            GUIdef.Bounds720p.Right = (short)(GUIdef.Bounds720p.Right * scalefactor);
            return GUIdef;
        }
    }
}

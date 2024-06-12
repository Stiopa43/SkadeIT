using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public enum Stage:byte
    {
        [Description("Planning")]
        Plan = 0,
        [Description("Prototyping")]
        Prototyping =1,
        [Description("Implementation")]
        Implementation =2,
        [Description("Testing")]
        Testing =3
    }
}

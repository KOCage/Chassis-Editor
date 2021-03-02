using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChassisTek
{
    // It's (poly)morhin' time!
    public abstract class ChassisContainer
    {
        // I can feed any of the ChassisContainers a filed name and then, knowing what type of field it is, I can use the appropriate value
        public abstract bool GetField(string field, ref string textValue, ref float floatValue, ref bool boolValue);
        public abstract bool SetField(string field, string textValue, float floatValue, bool boolValue);

    }
}

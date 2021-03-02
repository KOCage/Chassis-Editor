using System;
using System.Collections.Generic;
using System.Text;

namespace ChassisTek
{
    /*
     * "LOSSourcePositions": [
    {
      "x": 0,
      "y": 17,
      "z": 0
    },
     */
    public class LOSSourcePositions : ChassisContainer
    {
        public float x = 0;
        public float y = 0;
        public float z = 0;

        public LOSSourcePositions()
        {
        }

        public override bool GetField(string field, ref string textValue, ref float floatValue, ref bool boolValue)
        {
            switch (field)
            {
                case "x":
                    floatValue = x;
                    return true;
                case "y":
                    floatValue = y;
                    return true;
                case "z":
                    floatValue = z;
                    return true;
            }
            return false;
        }

        public override bool SetField(string field, string textValue, float floatValue, bool boolValue)
        {
            switch (field)
            {
                case "x":
                    x = floatValue;
                    return true;
                case "y":
                    y = floatValue;
                    return true;
                case "z":
                    z = floatValue;
                    return true;
            }
            return false;
        }
        public override string ToString()
        {
            return "LOSSourcePosition";
        }
    }
}

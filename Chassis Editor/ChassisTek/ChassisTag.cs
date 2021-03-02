using System;
using System.Collections.Generic;
using System.Text;

namespace ChassisTek
{
    /*
     * "ChassisTags": {
    "items": [
      "mech_case_left",
      "mech_case_right"
    ],
    "tagSetSourceFile": ""
  },
     */
   public class ChassisTag : ChassisContainer
    {
        public string[] items;
        public string tagSetSourceFile;

        public ChassisTag()
        {
            items = new string[0];
        }

        public override bool GetField(string field, ref string textValue, ref float floatValue, ref bool boolValue)
        {
            switch (field)
            {
                case "tagSetSourceFile":
                    textValue = tagSetSourceFile;
                    return true;
            }
            return false;
        }

        public override bool SetField(string field, string textValue, float floatValue, bool boolValue)
        {
            switch (field)
            {
                case "tagSetSourceFile":
                    tagSetSourceFile = textValue;
                    return true;
            }
            return false;
        }
        public override string ToString()
        {
            return "ChassisTag";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ChassisTek
{
    /*
     * "Hardpoints": [
        {
          "WeaponMount": "Energy",
          "Omni": false
        },
     */
    public class Hardpoint : ChassisContainer
    {
        public string WeaponMount = "";
        public bool Omni = false;

        public Hardpoint()
        {

        }
        public override bool GetField(string field, ref string textValue, ref float floatValue, ref bool boolValue)
        {
            switch (field)
            {
                case "WeaponMount":
                    textValue = WeaponMount;
                    return true;
                case "Omni":
                    boolValue = Omni;
                    return true;
            }
            return false;
        }

        public override bool SetField(string field, string textValue, float floatValue, bool boolValue)
        {
            switch (field)
            {
                case "WeaponMount":
                    WeaponMount = textValue;
                    return true;
                case "Omni":
                    Omni = boolValue;
                    return true;
            }
            return false;
        }

        public override string ToString()
        {
            return "Hardpoint";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ChassisTek
{
    /*
     * "Locations": [
    {
      "Location": "Head",
      "Hardpoints": [],
      "Tonnage": 0,
      "InventorySlots": 1,
      "MaxArmor": 45,
      "MaxRearArmor": -1,
      "InternalStructure": 16
    },
     */
    public class Locations : ChassisContainer
    {
        // Can Edit
        public float Tonnage = 0;
        public float InventorySlots = 0;
        public float MaxArmor = 0;
        public float MaxRearArmor = 0;
        public float InternalStructure = 0;

        // Cannot edit yet
        public string Location;
        public Hardpoint[] Hardpoints;

        public Locations(string loc)
        {
            Location = loc;
            Hardpoints = new Hardpoint[0];
        }

        public override bool GetField(string field, ref string textValue, ref float floatValue, ref bool boolValue)
        {
            switch (field)
            {
                case "Tonnage":
                    floatValue = Tonnage;
                    return true;
                case "InventorySlots":
                    floatValue = InventorySlots;
                    return true;
                case "MaxArmor":
                    floatValue = MaxArmor;
                    return true;
                case "MaxRearArmor":
                    floatValue = MaxRearArmor;
                    return true;
                case "InternalStructure":
                    floatValue = InternalStructure;
                    return true;
            }
            return false;
        }

        public override bool SetField(string field, string textValue, float floatValue, bool boolValue)
        {
            switch (field)
            {
                case "Tonnage":
                    Tonnage = floatValue;
                    return true;
                case "InventorySlots":
                    InventorySlots = floatValue;
                    return true;
                case "MaxArmor":
                    MaxArmor = floatValue;
                    return true;
                case "MaxRearArmor":
                    MaxRearArmor = floatValue;
                    return true;
                case "InternalStructure":
                    InternalStructure = floatValue;
                    return true;
            }
            return false;
        }
        public override string ToString()
        {
            return Location;
        }
    }
}

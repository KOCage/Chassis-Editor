using System;
using System.Collections.Generic;
using System.Text;

namespace ChassisTek
{
    /*
     * "FixedEquipment": [
    {
      "MountedLocation": "LeftTorso",
      "ComponentDefID": "Gear_XL_Engine",
      "SimGameUID": "",
      "ComponentDefType": "Upgrade",
      "HardpointSlot": -1,
      "IsFixed": true,
      "GUID": null,
      "DamageLevel": "Functional",
      "prefabName": null,
      "hasPrefabName": false
    },
     */
    public class FixedEquipment : ChassisContainer
    {
        public string MountedLocation = "";
        public string ComponentDefID = "";
        public string SimGameUID = "";
        public string ComponentDefType = "";
        public float HardpointSlot = 0;
        public bool IsFixed = false;
        public string GUID = "";
        public string DamageLevel = "";
        public string prefabName = "";
        public bool hasPrefabName = false;

        public FixedEquipment()
        {

        }
        public override bool GetField(string field, ref string textValue, ref float floatValue, ref bool boolValue)
        {
            switch (field)
            {
                case "MountedLocation":
                    textValue = MountedLocation;
                    return true;
                case "ComponentDefID":
                    textValue = ComponentDefID;
                    return true;
                case "SimGameUID":
                    textValue = SimGameUID;
                    return true;
                case "ComponentDefType":
                    textValue = ComponentDefType;
                    return true;
                case "HardpointSlot":
                    floatValue = HardpointSlot;
                    return true;
                case "IsFixed":
                    boolValue = IsFixed;
                    return true;
                case "GUID":
                    textValue = GUID;
                    return true;
                case "DamageLevel":
                    textValue = DamageLevel;
                    return true;
                case "prefabName":
                    textValue = prefabName;
                    return true;
                case "hasPrefabName":
                    boolValue = hasPrefabName;
                    return true;
            }
            return false;
        }

        public override bool SetField(string field, string textValue, float floatValue, bool boolValue)
        {
            switch (field)
            {
                case "MountedLocation":
                    MountedLocation = textValue;
                    return true;
                case "ComponentDefID":
                    ComponentDefID = textValue;
                    return true;
                case "SimGameUID":
                    SimGameUID = textValue;
                    return true;
                case "ComponentDefType":
                    ComponentDefType = textValue;
                    return true;
                case "HardpointSlot":
                    HardpointSlot = floatValue;
                    return true;
                case "IsFixed":
                    IsFixed = boolValue;
                    return true;
                case "GUID":
                    GUID = textValue;
                    return true;
                case "DamageLevel":
                    DamageLevel = textValue;
                    return true;
                case "prefabName":
                    prefabName = textValue;
                    return true;
                case "hasPrefabName":
                    hasPrefabName = boolValue;
                    return true;
            }
            return false;
        }
        public override string ToString()
        {
            return "FixedEquipment";
        }
    }


}

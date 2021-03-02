using System;
using System.Collections.Generic;
using System.Text;

namespace ChassisTek
{
    /*
     * "Description": {
    "Cost": 28650000,
    "Rarity": 5,
    "Purchasable": true,
    "Manufacturer": "",
    "Model": "",
    "UIName": "Atlas",
    "Id": "chassisdef_atlas_AS7-CM",
    "Name": "Atlas",
    "Details": "Another modification of the K model of the Atlas introduced in 3050, the CM Atlas was designed to carry a C3 Master Computer into battle. In order to do this one of the ER Large Lasers was removed and in its place a C3 Master computer was installed, allowing it to coordinate allies with C3 targeting data.",
    "Icon": "uixTxrIcon_atlas"
  },
     */
    public class Description : ChassisContainer
    {
        // Can be edited
        public float Cost = 0;
        public float Rarity = 0;
        public bool Purchasable = true;
        public string Manufacturer = "";
        public string Model = "";
        public string Name = "";
        public string Details = "";
        public string UIName = "";
        public string Id = "";
        public string Icon = "";

        public Description()
        {

        }

        public override bool GetField(string field, ref string textValue, ref float floatValue, ref bool boolValue)
        {
            switch (field)
            {
                case "Cost":
                    floatValue = Cost;
                    return true;
                case "Rarity":
                    floatValue = Rarity;
                    return true;
                case "Purchasable":
                    boolValue = Purchasable;
                    return true;
                case "Manufacturer":
                    textValue = Manufacturer;
                    return true;
                case "Model":
                    textValue = Model;
                    return true;
                case "Name":
                    textValue = Name;
                    return true;
                case "Details":
                    textValue = Details;
                    return true;
                case "UIName":
                    textValue = UIName;
                    return true;
                case "Id":
                    textValue = Id;
                    return true;
                case "Icon":
                    textValue = Icon;
                    return true;
            }
            return false;
        }

        public override bool SetField(string field, string textValue, float floatValue, bool boolValue)
        {
            switch (field)
            {
                case "Cost":
                    Cost = floatValue;
                    return true;
                case "Rarity":
                    Rarity = floatValue;
                    return true;
                case "Purchasable":
                    Purchasable = boolValue;
                    return true;
                case "Manufacturer":
                    Manufacturer = textValue;
                    return true;
                case "Model":
                    Model = textValue;
                    return true;
                case "Name":
                    Name = textValue;
                    return true;
                case "Details":
                    Details = textValue;
                    return true;
                case "UIName":
                    UIName = textValue;
                    return true;
                case "Id":
                    Id = textValue;
                    return true;
                case "Icon":
                    Icon = textValue;
                    return true;
            }
            return false;
        }
        public override string ToString()
        {
            return "Description";
        }
    }
}

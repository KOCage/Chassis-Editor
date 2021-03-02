using System;
using System.Collections.Generic;
using System.Text;

namespace ChassisTek
{

    /*
     * {
  "Description": {
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
  "MovementCapDefID": "movedef_atlas_AS7-D",
  "PathingCapDefID": "pathingdef_assault",
  "HardpointDataDefID": "hardpointdatadef_atlas",
  "PrefabIdentifier": "chrPrfMech_atlasBase-001",
  "PrefabBase": "atlas",
  "Tonnage": 100,
  "InitialTonnage": 0,
  "weightClass": "ASSAULT",
  "BattleValue": 10581000,
  "Heatsinks": 0,
  "TopSpeed": 60,
  "TurnRadius": 90,
  "MaxJumpjets": 9,
  "Stability": 200,
  "StabilityDefenses": [
    0,
    0,
    0,
    0,
    0,
    0
  ],
  "SpotterDistanceMultiplier": 1,
  "VisibilityMultiplier": 1,
  "SensorRangeMultiplier": 1,
  "Signature": 0,
  "Radius": 8,
  "PunchesWithLeftArm": false,
  "MeleeDamage": 140,
  "MeleeInstability": 100,
  "MeleeToHitModifier": 0,
  "DFADamage": 125,
  "DFAToHitModifier": 0,
  "DFASelfDamage": 125,
  "DFAInstability": 125,
  "Locations": [
    {
      "Location": "Head",
      "Hardpoints": [],
      "Tonnage": 0,
      "InventorySlots": 1,
      "MaxArmor": 45,
      "MaxRearArmor": -1,
      "InternalStructure": 16
    },
    {
      "Location": "LeftArm",
      "Hardpoints": [
        {
          "WeaponMount": "Energy",
          "Omni": false
        },
        {
          "WeaponMount": "AntiPersonnel",
          "Omni": false
        }
      ],
      "Tonnage": 0,
      "InventorySlots": 8,
      "MaxArmor": 170,
      "MaxRearArmor": -1,
      "InternalStructure": 85
    },
    {
      "Location": "LeftTorso",
      "Hardpoints": [
        {
          "WeaponMount": "Missile",
          "Omni": false
        },
        {
          "WeaponMount": "Missile",
          "Omni": false
        }
      ],
      "Tonnage": 0,
      "InventorySlots": 10,
      "MaxArmor": 210,
      "MaxRearArmor": 105,
      "InternalStructure": 105
    },
    {
      "Location": "CenterTorso",
      "Hardpoints": [
        {
          "WeaponMount": "Energy",
          "Omni": false
        },
        {
          "WeaponMount": "Energy",
          "Omni": false
        }
      ],
      "Tonnage": 0,
      "InventorySlots": 4,
      "MaxArmor": 310,
      "MaxRearArmor": 155,
      "InternalStructure": 155
    },
    {
      "Location": "RightTorso",
      "Hardpoints": [
        {
          "WeaponMount": "Ballistic",
          "Omni": false
        },
        {
          "WeaponMount": "Ballistic",
          "Omni": false
        }
      ],
      "Tonnage": 0,
      "InventorySlots": 10,
      "MaxArmor": 210,
      "MaxRearArmor": 105,
      "InternalStructure": 105
    },
    {
      "Location": "RightArm",
      "Hardpoints": [
        {
          "WeaponMount": "Energy",
          "Omni": false
        },
        {
          "WeaponMount": "AntiPersonnel",
          "Omni": false
        }
      ],
      "Tonnage": 0,
      "InventorySlots": 8,
      "MaxArmor": 170,
      "MaxRearArmor": -1,
      "InternalStructure": 85
    },
    {
      "Location": "LeftLeg",
      "Hardpoints": [],
      "Tonnage": 0,
      "InventorySlots": 4,
      "MaxArmor": 210,
      "MaxRearArmor": -1,
      "InternalStructure": 105
    },
    {
      "Location": "RightLeg",
      "Hardpoints": [],
      "Tonnage": 0,
      "InventorySlots": 4,
      "MaxArmor": 210,
      "MaxRearArmor": -1,
      "InternalStructure": 105
    }
  ],
  "LOSSourcePositions": [
    {
      "x": 0,
      "y": 17,
      "z": 0
    },
    {
      "x": 5,
      "y": 16,
      "z": -1
    },
    {
      "x": -5,
      "y": 16,
      "z": -1
    }
  ],
  "LOSTargetPositions": [
    {
      "x": 0,
      "y": 17,
      "z": 0
    },
    {
      "x": 5,
      "y": 16,
      "z": -1
    },
    {
      "x": -5,
      "y": 16,
      "z": -1
    },
    {
      "x": 3.5,
      "y": 5.5,
      "z": 1
    },
    {
      "x": -3.5,
      "y": 5.5,
      "z": 1
    }
  ],
  "VariantName": "AS7-CM",
  "ChassisTags": {
    "items": [
      "mech_case_left",
      "mech_case_right"
    ],
    "tagSetSourceFile": ""
  },
  "StockRole": "Juggernaut & C3 Command Unit",
  "YangsThoughts": "The Atlas CM is variant on the Atlas K, including a C3 Command Unit. With the loss of a Single ER Large Laser the Atlas CM is able to share radar and targeting data allowing allies weapons to be fired further with accuracy.",
  "FixedEquipment": [
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
    {
      "MountedLocation": "RightTorso",
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
    {
      "MountedLocation": "LeftArm",
      "ComponentDefID": "Weapon_TAG_C3-STOCK",
      "SimGameUID": "",
      "ComponentDefType": "Weapon",
      "HardpointSlot": 0,
      "IsFixed": true,
      "GUID": null,
      "DamageLevel": "Functional",
      "prefabName": null,
      "hasPrefabName": false
    },
    {
      "MountedLocation": "LeftArm",
      "ComponentDefID": "Gear_C3_Master",
      "SimGameUID": "",
      "ComponentDefType": "Upgrade",
      "HardpointSlot": -1,
      "IsFixed": true,
      "GUID": null,
      "DamageLevel": "Functional",
      "prefabName": null,
      "hasPrefabName": false
    }
  ]
}
     */

    public class Chassis : ChassisContainer
    {
        // All the fields that can be modified
        // UI Grouping: Description 
        public Description description;
        public string VariantName = "";
        public string StockRole = "";
        public string YangsThoughts = "";

        // UI Grouping: General
        public float Tonnage = 0;
        public float InitialTonnage = 0;
        public string weightClass = "";
        public float Heatsinks = 0;
        public float MaxJumpjets = 0;
        public float Stability = 0;
        public float SpotterDistanceMultiplier = 0;
        public float VisibilityMultiplier = 0;
        public float SensorRangeMultiplier = 0;
        public float Signature = 0;
        public float Radius = 0;
        public string HardpointDataDefID = "";
        public string PrefabIdentifier = "";
        public string PrefabBase = "";
        public float BattleValue = 0;

        // UI Grouping: Movement
        public float TopSpeed = 0;
        public float TurnRadius = 0;
        public string MovementCapDefID = "";
        public string PathingCapDefID = "";

        // UI Grouping: Combat
        public float MeleeDamage = 0;
        public float MeleeInstability = 0;
        public float MeleeToHitModifier = 0;
        public float DFADamage = 0;
        public float DFAToHitModifier = 0;
        public float DFASelfDamage = 0;
        public float DFAInstability = 0;
        public bool PunchesWithLeftArm = false;

        // UI Grouping: Locations
        public Locations[] Locations;

        // All of the fields that cannot be modified - I have not determined a good way to modify these. I don't know the limitations or impacts, 
        // so I cannot implement code to safely change them. 
        public FixedEquipment[] FixedEquipment;
        public ChassisTag ChassisTags = new ChassisTag();
        public LOSSourcePositions[] LOSSourcePositions;
        public LOSTargetPositions[] LOSTargetPositions;
        public float[] StabilityDefenses = { 0, 0, 0, 0, 0, 0 };

        // Batch editing uses a blank chassis to start. Need to establish a blank chassis
        public Chassis()
        {
            description = new Description();
            string[] locationsLocations = { "Head", "CenterTorso", "LeftTorso", "RightTorso", "LeftArm", "RightArm", "LeftLeg", "RightLeg" };
            int length = locationsLocations.Length;
            Locations = new Locations[length];
            for(int i = 0; i < length; i++)
            {
                Locations[i] = new Locations(locationsLocations[i]);
            }
            FixedEquipment = new FixedEquipment[0];
            LOSSourcePositions = new LOSSourcePositions[3];
            LOSTargetPositions = new LOSTargetPositions[5];
        }

        public override bool GetField(string field, ref string textValue, ref float floatValue, ref bool boolValue)
        {
            switch (field)
            {
                case "VariantName":
                    textValue = VariantName;
                    return true;
                case "StockRole":
                    textValue = StockRole;
                    return true;
                case "YangsThoughts":
                    textValue = YangsThoughts;
                    return true;
                case "Tonnage":
                    floatValue = Tonnage;
                    return true;
                case "InitialTonnage":
                    floatValue = InitialTonnage;
                    return true;
                case "weightClass":
                    textValue = weightClass;
                    return true;
                case "Heatsinks":
                    floatValue = Heatsinks;
                    return true;
                case "MaxJumpjets":
                    floatValue = MaxJumpjets;
                    return true;
                case "Stability":
                    floatValue = Stability;
                    return true;
                case "SpotterDistanceMultiplier":
                    floatValue = SpotterDistanceMultiplier;
                    return true;
                case "VisibilityMultiplier":
                    floatValue = VisibilityMultiplier;
                    return true;
                case "SensorRangeMultiplier":
                    floatValue = SensorRangeMultiplier;
                    return true;
                case "Signature":
                    floatValue = Signature;
                    return true;
                case "Radius":
                    floatValue = Radius;
                    return true;
                case "HardpointDataDefID":
                    textValue = HardpointDataDefID;
                    return true;
                case "PrefabIdentifier":
                    textValue = PrefabIdentifier;
                    return true;
                case "PrefabBase":
                    textValue = PrefabBase;
                    return true;
                case "BattleValue":
                    floatValue = BattleValue;
                    return true;
                case "TopSpeed":
                    floatValue = TopSpeed;
                    return true;
                case "TurnRadius":
                    floatValue = TurnRadius;
                    return true;
                case "MovementCapDefID":
                    textValue = MovementCapDefID;
                    return true;
                case "PathingCapDefID":
                    textValue = PathingCapDefID;
                    return true;
                case "MeleeDamage":
                    floatValue = MeleeDamage;
                    return true;
                case "MeleeInstability":
                    floatValue = MeleeInstability;
                    return true;
                case "MeleeToHitModifier":
                    floatValue = MeleeToHitModifier;
                    return true;
                case "DFADamage":
                    floatValue = DFADamage;
                    return true;
                case "DFAToHitModifier":
                    floatValue = DFAToHitModifier;
                    return true;
                case "DFASelfDamage":
                    floatValue = DFASelfDamage;
                    return true;
                case "DFAInstability":
                    floatValue = DFAInstability;
                    return true;
                case "PunchesWithLeftArm":
                    boolValue = PunchesWithLeftArm;
                    return true;
            }
            return false;
        }

        public override bool SetField(string field, string textValue, float floatValue, bool boolValue)
        {
            switch (field)
            {
                case "VariantName":
                    VariantName = textValue;
                    return true;
                case "StockRole":
                    StockRole = textValue;
                    return true;
                case "YangsThoughts":
                    YangsThoughts = textValue;
                    return true;
                case "Tonnage":
                    Tonnage = floatValue;
                    return true;
                case "InitialTonnage":
                    InitialTonnage = floatValue;
                    return true;
                case "weightClass":
                    weightClass = textValue;
                    return true;
                case "Heatsinks":
                    Heatsinks = floatValue;
                    return true;
                case "MaxJumpjets":
                    MaxJumpjets = floatValue;
                    return true;
                case "Stability":
                    Stability = floatValue;
                    return true;
                case "SpotterDistanceMultiplier":
                    SpotterDistanceMultiplier = floatValue;
                    return true;
                case "VisibilityMultiplier":
                    VisibilityMultiplier = floatValue;
                    return true;
                case "SensorRangeMultiplier":
                    SensorRangeMultiplier = floatValue;
                    return true;
                case "Signature":
                    Signature = floatValue;
                    return true;
                case "Radius":
                    Radius = floatValue;
                    return true;
                case "HardpointDataDefID":
                    HardpointDataDefID = textValue;
                    return true;
                case "PrefabIdentifier":
                    PrefabIdentifier = textValue;
                    return true;
                case "PrefabBase":
                    PrefabBase = textValue;
                    return true;
                case "BattleValue":
                    BattleValue = floatValue;
                    return true;
                case "TopSpeed":
                    TopSpeed = floatValue;
                    return true;
                case "TurnRadius":
                    TurnRadius = floatValue;
                    return true;
                case "MovementCapDefID":
                    MovementCapDefID = textValue;
                    return true;
                case "PathingCapDefID":
                    PathingCapDefID = textValue;
                    return true;
                case "MeleeDamage":
                    MeleeDamage = floatValue;
                    return true;
                case "MeleeInstability":
                    MeleeInstability = floatValue;
                    return true;
                case "MeleeToHitModifier":
                    MeleeToHitModifier = floatValue;
                    return true;
                case "DFADamage":
                    DFADamage = floatValue;
                    return true;
                case "DFAToHitModifier":
                    DFAToHitModifier = floatValue;
                    return true;
                case "DFASelfDamage":
                    DFASelfDamage = floatValue;
                    return true;
                case "DFAInstability":
                    DFAInstability = floatValue;
                    return true;
                case "PunchesWithLeftArm":
                    PunchesWithLeftArm = boolValue;
                    return true;
            }
            return false;
        }

        public override string ToString()
        {
            return "Chassis";
        }
    }
}
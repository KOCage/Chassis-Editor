using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChassisTek;
using System.IO;
using Newtonsoft.Json;

namespace Chassis_Editor
{
    // First we must create the world
    // The world contains a chassis file
    // The world contains a chassis object, derived from a chassis file

    public class Model
    {
        public Chassis chassis;
        public string chassisFile;
        public string chassisFileName;
        public string chassisFileDirectory;
        public Chassis batchChassis = new Chassis();
        public string batchDirectory = "";

        public void LoadChassisFile(string fileName)
        {
            Program.updateLog(Log.LogType.FILELOAD, "Attempting to load chassis file: " + fileName);
            try
            {
                string fileText = File.ReadAllText(fileName);
                chassis = JsonConvert.DeserializeObject<Chassis>(fileText);
                chassisFile = fileName;
                Log.updateLog(Log.LogType.FILELOAD, "Successfully loaded chassis file");
                UpdateChassisLocations();
                SplitChassisFile();
                // Unroll the entire chassis file to the log. This can be disabled in the Log class (enableUnrollLogging = false)
                UnrollChassis();
            }
            catch (Exception ex)
            {
                string newException = "In Model.LoadChassisFile encountered exception using file: " + fileName + "\nException: " + ex.Message;
                Log.updateLog(Log.LogType.EXCEPTION, newException);
                throw new Exception(newException);
            }
        }

        public bool FileLoaded()
        {
            if (chassis != null)
                return true;
            else
                return false;
        }

        public void WriteChassisFile()
        {
            Log.updateLog(Log.LogType.FILEWRITE, "Attempting to write to the chassis file: " + chassisFile);
            try
            {
                string fileText = JsonConvert.SerializeObject(chassis, Formatting.Indented);
                File.WriteAllText(chassisFile, fileText);
                Log.updateLog(Log.LogType.FILEWRITE, "Successfully wrote file");
            } catch (Exception ex)
            {
                Log.updateLog(Log.LogType.EXCEPTION, "Encountered exception: " + ex.Message);
                throw new Exception("Encountered exception while writing to " + chassisFile + " : " + ex.Message);
            }
        }

        public void UpdateChassisFile(string newChassisFile)
        {
            chassisFileName = newChassisFile;
            string fullPath = chassisFileDirectory + chassisFileName;
            Log.updateLog(Log.LogType.MODELUPDATE, "Updating the fullpath in the chassisFile to " + fullPath);
            chassisFile = fullPath;
        }

        public void UpdateModel(string group, string selectedItem, string newText)
        {
            // Rather than type a conversion for each case, I'll just do all conversions at once. 
            float newFloat;
            bool newBool;

            // Some of the longer strings threw exceptions during conversion. But, if it was a longer string, then it isn't meant to be converted anyways
            try
            {
                newFloat = float.Parse(newText);
            }
            // I don't like warnings when the code compiles, and apparently you can just right click and "Supress" error messages like this. 
            // So that's why this is just here and I don't do anything like it elsewhere. I didn't actually mean to do it, but now it is kinda nice.
            // So the new code stays instead of storing ex.Message just so I don't have to hear about not using it. 
#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                newFloat = 0;
                Log.updateLog(Log.LogType.EXCEPTION, "Unable to convert '" + newText + "' to a float. Using 0");
            }

            newBool = newText.ToUpper().Equals("TRUE");

            if (group.Equals("Description"))
            {
                /* Current items
                    Cost
                    Details
                    Manufacturer
                    Model
                    Name
                    Purchasable
                    Rarity
                    StockRole
                    VariantName
                    YangsThoughts
                */
                switch (selectedItem)
                {
                    case "Cost":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating Description.Cost to " + newFloat);
                        chassis.description.Cost = newFloat;
                        break;
                    case "Details":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating Description.Details to " + newText);
                        chassis.description.Details = newText;
                        break;
                    case "Manufacturer":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating Description.Manufacturer to " + newText);
                        chassis.description.Manufacturer = newText;
                        break;
                    case "Model":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating Description.Model to " + newText);
                        chassis.description.Model = newText;
                        break;
                    case "Name":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating Description.Name to " + newText);
                        chassis.description.Name = newText;
                        break;
                    case "Purchasable":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating Description.Purchasable to " + newBool.ToString());
                        chassis.description.Purchasable = newBool;
                        break;
                    case "Rarity":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating Description.Rarity to " + newFloat);
                        chassis.description.Rarity = newFloat;
                        break;
                    case "StockRole":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating StockRole to " + newText);
                        chassis.StockRole = newText;
                        break;
                    case "VariantName":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating VariantName to " + newText);
                        chassis.VariantName = newText;
                        break;
                    case "YangsThoughts":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating YangsThoughts to " + newText);
                        chassis.YangsThoughts = newText;
                        break;
                    default:
                        Log.updateLog(Log.LogType.MODELUPDATE, "Unable to make update for " + group + " field " + selectedItem.ToString() + " with value " + newText);
                        break;
                }
            }
            if (group.Equals("General"))
            {
                /* Current items
                    Tonnage
                    InitialTonnage
                    weightClass
                    Heatsinks
                    MaxJumpjets
                    Stability
                    SpotterDistanceMultiplier
                    VisibilityMultiplier
                    SensorRangeMultiplier
                    Signature
                    Radius
                    HardpointDataDefID
                    PrefabIdentifier
                    PrefabBase
                    BattleValue
                */

                switch (selectedItem)
                {
                    case "Tonnage":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating General.Tonnage to " + newFloat);
                        chassis.Tonnage = newFloat;
                        break;
                    case "InitialTonnage":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating General.InitialTonnage to " + newFloat);
                        chassis.InitialTonnage = newFloat;
                        break;
                    case "weightClass":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating General.WeightClass to " + newText);
                        chassis.weightClass = newText;
                        break;
                    case "Heatsinks":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating General.Heatsinks to " + newFloat);
                        chassis.Heatsinks = newFloat;
                        break;
                    case "MaxJumpjets":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating General.Heatsinks to " + newFloat);
                        chassis.MaxJumpjets = newFloat;
                        break;
                    case "Stability":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating General.Heatsinks to " + newFloat);
                        chassis.Stability = newFloat;
                        break;
                    case "SpotterDistanceMultiplier":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating General.SpotterDistanceMultiplier to " + newFloat);
                        chassis.SpotterDistanceMultiplier = newFloat;
                        break;
                    case "VisibilityMultiplier":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating General.VisibilityMultiplier to " + newFloat);
                        chassis.VisibilityMultiplier = newFloat;
                        break;
                    case "SensorRangeMultiplier":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating General.SensorRangeMultiplier to " + newFloat);
                        chassis.SensorRangeMultiplier = newFloat;
                        break;
                    case "Signature":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating General.Signature to " + newFloat);
                        chassis.Signature = newFloat;
                        break;
                    case "Radius":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating General.Radius to " + newFloat);
                        chassis.Radius = newFloat;
                        break;
                    case "HardpointDataDefID":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating General.HardpointDataDefID to " + newText);
                        chassis.HardpointDataDefID = newText;
                        break;
                    case "PrefabIdentifier":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating General.PrefabIdentifier to " + newText);
                        chassis.PrefabIdentifier = newText;
                        break;
                    case "PrefabBase":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating General.PrefabBase to " + newText);
                        chassis.PrefabBase = newText;
                        break;
                    case "BattleValue":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating General.BattleValue to " + newFloat);
                        chassis.BattleValue = newFloat;
                        break;
                    default:
                        Log.updateLog(Log.LogType.MODELUPDATE, "Unable to make update for " + group + " field " + selectedItem.ToString() + " with value " + newText);
                        break;
                }
            }
            if (group.Equals("Movement"))
            {
                /* Current items
                    TopSpeed
                    TurnRadius
                */

                switch (selectedItem)
                {
                    case "TopSpeed":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating Movement.TopSpeed to " + newFloat);
                        chassis.TopSpeed = newFloat;
                        break;
                    case "TurnRadius":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating Movement.TurnRadius to " + newFloat);
                        chassis.TurnRadius = newFloat;
                        break;
                    case "MovementCapDefID":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating Movement.MovementCapDefID to " + newText);
                        chassis.MovementCapDefID = newText;
                        break;
                    case "PathingCapDefID":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating Movement.PathingCapDefID to " + newText);
                        chassis.PathingCapDefID = newText;
                        break;
                    default:
                        Log.updateLog(Log.LogType.MODELUPDATE, "Unable to make update for " + group + " field " + selectedItem.ToString() + " with value " + newText);
                        break;
                }
            }
            if (group.Equals("Combat"))
            {
                /* Current items
                    MeleeDamage
                    MeleeInstability
                    MeleeToHitModifier
                    DFADamage
                    DFAToHitModifier
                    DFASelfDamage
                    DFAInstability
                */

                switch (selectedItem)
                {
                    case "MeleeDamage":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating Combat.MeleeDamage to " + newFloat);
                        chassis.MeleeDamage = newFloat;
                        break;
                    case "MeleeInstability":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating Combat.MeleeInstability to " + newFloat);
                        chassis.MeleeInstability = newFloat;
                        break;
                    case "MeleeToHitModifier":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating Combat.MeleeToHitModifier to " + newFloat);
                        chassis.MeleeToHitModifier = newFloat;
                        break;
                    case "DFADamage":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating Combat.DFADamage to " + newFloat);
                        chassis.DFADamage = newFloat;
                        break;
                    case "DFAToHitModifier":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating Combat.DFAToHitModifier to " + newFloat);
                        chassis.DFAToHitModifier = newFloat;
                        break;
                    case "DFASelfDamage":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating Combat.DFASelfDamage to " + newFloat);
                        chassis.DFASelfDamage = newFloat;
                        break;
                    case "DFAInstability":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating Combat.DFAInstability to " + newFloat);
                        chassis.DFAInstability = newFloat;
                        break;
                    case "PunchesWithLeftArm":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating Combat.PunchesWithLeftArm to " + newBool.ToString());
                        chassis.PunchesWithLeftArm = newBool;
                        break;
                    default:
                        Log.updateLog(Log.LogType.MODELUPDATE, "Unable to make update for " + group + " field " + selectedItem.ToString() + " with value " + newText);
                        break;
                }
            }

            // Since locations consist of elements that are not changed (head, center torso,...), we will expect that location to be sent in as the group
            if (group.Equals("Head") ||
                group.Equals("CenterTorso") ||
                group.Equals("LeftTorso") ||
                group.Equals("RightTorso") ||
                group.Equals("LeftArm") ||
                group.Equals("RightArm") ||
                group.Equals("LeftLeg") ||
                group.Equals("RightLeg"))
            {
                Locations location = GetLocation(group, MainWindow.ProcessMode.SINGLE);

                // if the location's Location is an empty string, that means it was never assigned in the loop
                if (location.Location.Equals("FAILED"))
                {
                    string exception = "Unable to find matching location for group '" + group + "'";
                    Log.updateLog(Log.LogType.EXCEPTION, exception);
                    throw new Exception(exception);
                }

                /* Current items for each location
                    Tonnage;
                    InventorySlots;
                    MaxArmor;
                    MaxRearArmor; -- Only for the torso set
                    InternalStructure;
                */

                // now we can just update location's value 
                switch (selectedItem)
                {
                    case "Tonnage":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating " + location.Location + ".Tonnage to " + newFloat);
                        location.Tonnage = newFloat;
                        break;
                    case "InventorySlots":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating " + location.Location + ".InventorySlots to " + newFloat);
                        location.InventorySlots = newFloat;
                        break;
                    case "MaxArmor":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating " + location.Location + ".MaxArmor to " + newFloat);
                        location.MaxArmor = newFloat;
                        break;

                    // Some locations have MaxRearArmor, but most do not. 
                    case "MaxRearArmor":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating " + location.Location + "MaxRearArmor.Tonnage to " + newFloat);
                        try
                        {
                            location.MaxRearArmor = newFloat;
                        } catch (Exception ex)
                        {
                            Log.updateLog(Log.LogType.EXCEPTION, "FAILED TO UPDATE: " + ex.Message);
                            throw new Exception("Encountered exception attempting to update MaxRearArmor for location " + group + ": " + ex.Message);
                        }
                        break;
                    case "InternalStructure":
                        Log.updateLog(Log.LogType.MODELUPDATE, "Updating " + location.Location + "InternalStructure.Tonnage to " + newFloat);
                        location.InternalStructure = newFloat;
                        break;
                    default:
                        Log.updateLog(Log.LogType.MODELUPDATE, "Unable to make update for " + group + " field " + selectedItem.ToString() + " with value " + newText);
                        break;
                }
            }
        }

        // splits the chassisFile (fullpath) in to the directory and file name
        private void SplitChassisFile()
        {
            string[] splitFile = chassisFile.Split('\\');
            int numSegments = splitFile.Length;
            chassisFileName = splitFile[numSegments - 1];
            chassisFileDirectory = chassisFile.Replace(chassisFileName, "");
        }

        // Function will Log the entire Chassis File
        public void UnrollChassis()
        {
            string delimiter = " : ";
            Log.LogType l = Log.LogType.UNROLL;
            Log.updateLog(l, "Starting unroll of " + chassisFileName);

            /* Template and values to unroll
                Log.updateLog(l, "" + );
                public Description description;
                        public int Cost;
                        public int Rarity;
                        public bool Purchasable;
                        public string Manufacturer;
                        public string Model;
                        public string Name;
                        public string Details;
                        public string UIName;
                        public string Id;
                        public string Icon;
                public string VariantName;
                public string StockRole;
                public string YangsThoughts;

                public int Tonnage;
                public int InitialTonnage;
                public string weightClass;
                public int Heatsinks;
                public int MaxJumpjets;
                public int Stability;
                public float SpotterDistanceMultiplier;
                public float VisibilityMultiplier;
                public float SensorRangeMultiplier;
                public int Signature;
                public int Radius;

                public int TopSpeed;
                public int TurnRadius;

                public int MeleeDamage;
                public int MeleeInstability;
                public int MeleeToHitModifier;
                public int DFADamage;
                public int DFAToHitModifier;
                public int DFASelfDamage;
                public int DFAInstability;

                public Locations[] Locations;
                            public int Tonnage;
                            public int InventorySlots;
                            public int MaxArmor;
                            public int MaxRearArmor;
                            public int InternalStructure;
                            public Hardpoint[] Hardpoints;
                                        public string WeaponMount;
                                        public bool Omni;


                public FixedEquipment[] FixedEquipment;
                            public string MountedLocation;
                            public string ComponentDefID;
                            public string SimGameUID;
                            public string ComponentDefType;
                            public int HardpointSlot;
                            public bool IsFixed;
                            public string GUID;
                            public string DamageLevel;
                            public string prefabName;
                            public bool hasPrefabName;

                public ChassisTag ChassisTags;
                            public string[] items;
                            public string tagSetSourceFile;

                public LOSSourcePositions[] LOSSourcePositions;
                            public float x;
                            public float y;
                            public float z;

                public LOSTargetPositions[] LOSTargetPositions;
                            public float x;
                            public float y;
                            public float z;
                public string MovementCapDefID;
                public string PathingCapDefID;
                public string HardpointDataDefID;
                public string PrefabIdentifier;
                public string PrefabBase;
                public int BattleValue;
                public int[] StabilityDefenses;
                public bool PunchesWithLeftArm;
            */

            // All the Description values
            Log.updateLog(l, "Name" + delimiter + chassis.description.Name);
            Log.updateLog(l, "Cost" + delimiter + chassis.description.Cost);
            Log.updateLog(l, "Rarity" + delimiter + chassis.description.Rarity);
            Log.updateLog(l, "Purchasable" + delimiter + chassis.description.Purchasable);
            Log.updateLog(l, "Manufacturer" + delimiter + chassis.description.Manufacturer);
            Log.updateLog(l, "Model" + delimiter + chassis.description.Model);
            Log.updateLog(l, "Details" + delimiter + chassis.description.Details);
            Log.updateLog(l, "UIName" + delimiter + chassis.description.UIName);
            Log.updateLog(l, "Id" + delimiter + chassis.description.Id);
            Log.updateLog(l, "Icon" + delimiter + chassis.description.Icon);
            // All the Chassis values
            Log.updateLog(l, "VariantName" + delimiter + chassis.VariantName);
            Log.updateLog(l, "StockRole" + delimiter + chassis.StockRole);
            Log.updateLog(l, "YangsThoughts" + delimiter + chassis.YangsThoughts);
            Log.updateLog(l, "Tonnage" + delimiter + chassis.Tonnage);
            Log.updateLog(l, "InitialTonnage" + delimiter + chassis.InitialTonnage);
            Log.updateLog(l, "weightClass" + delimiter + chassis.weightClass);
            Log.updateLog(l, "Heatsinks" + delimiter + chassis.Heatsinks);
            Log.updateLog(l, "MaxJumpjets" + delimiter + chassis.MaxJumpjets);
            Log.updateLog(l, "Stability" + delimiter + chassis.Stability);
            Log.updateLog(l, "SpotterDistanceMultiplier" + delimiter + chassis.SpotterDistanceMultiplier);
            Log.updateLog(l, "VisibilityMultiplier" + delimiter + chassis.VisibilityMultiplier);
            Log.updateLog(l, "SensorRangeMultiplier" + delimiter + chassis.SensorRangeMultiplier);
            Log.updateLog(l, "Signature" + delimiter + chassis.Signature);
            Log.updateLog(l, "Radius" + delimiter + chassis.Radius);
            Log.updateLog(l, "TopSpeed" + delimiter + chassis.TopSpeed);
            Log.updateLog(l, "TurnRadius" + delimiter + chassis.TurnRadius);
            Log.updateLog(l, "MeleeDamage" + delimiter + chassis.MeleeDamage);
            Log.updateLog(l, "MeleeInstability" + delimiter + chassis.MeleeInstability);
            Log.updateLog(l, "MeleeToHitModifier" + delimiter + chassis.MeleeToHitModifier);
            Log.updateLog(l, "DFADamage" + delimiter + chassis.DFADamage);
            Log.updateLog(l, "DFAToHitModifier" + delimiter + chassis.DFAToHitModifier);
            Log.updateLog(l, "DFASelfDamage" + delimiter + chassis.DFASelfDamage);
            Log.updateLog(l, "DFAInstability" + delimiter + chassis.DFAInstability);
            Log.updateLog(l, "MovementCapDefID" + delimiter + chassis.MovementCapDefID);
            Log.updateLog(l, "PathingCapDefID" + delimiter + chassis.PathingCapDefID);
            Log.updateLog(l, "HardpointDataDefID" + delimiter + chassis.HardpointDataDefID);
            Log.updateLog(l, "PrefabIdentifier" + delimiter + chassis.PrefabIdentifier);
            Log.updateLog(l, "PrefabBase" + delimiter + chassis.PrefabBase);
            Log.updateLog(l, "BattleValue" + delimiter + chassis.BattleValue);
            Log.updateLog(l, "PunchesWithLeftArm" + delimiter + chassis.PunchesWithLeftArm);

            Log.updateLog(l, "Preparing to unroll " + chassis.Locations.Length + " Locations");
            foreach (Locations loc in chassis.Locations)
            {
                Log.updateLog(l, "Location" + delimiter + loc.Location);
                Log.updateLog(l, "Tonnage" + delimiter + loc.Tonnage);
                Log.updateLog(l, "InventorySlots" + delimiter + loc.InventorySlots);
                Log.updateLog(l, "MaxArmor" + delimiter + loc.MaxArmor);
                Log.updateLog(l, "MaxRearArmor" + delimiter + loc.MaxRearArmor);
                Log.updateLog(l, "InternalStructure" + delimiter + loc.InternalStructure);
                Log.updateLog(l, "Preparing to unroll " + loc.Hardpoints.Length + " Hardpoints");
                foreach (Hardpoint h in loc.Hardpoints)
                {
                    Log.updateLog(l, "WeaponMount" + delimiter + h.WeaponMount);
                    Log.updateLog(l, "Omni" + delimiter + h.Omni);
                }
            }
            if (chassis.FixedEquipment == null)
            {
                Log.updateLog(l, "No FixedEquipment array to unroll");
            }
            else
            {
                Log.updateLog(l, "Preparing to unroll " + chassis.FixedEquipment.Length + " FixedEquipment");
                foreach (FixedEquipment f in chassis.FixedEquipment)
                {
                    Log.updateLog(l, "MountedLocation" + delimiter + f.MountedLocation);
                    Log.updateLog(l, "ComponentDefID" + delimiter + f.ComponentDefID);
                    Log.updateLog(l, "SimGameUID" + delimiter + f.SimGameUID);
                    Log.updateLog(l, "ComponentDefType" + delimiter + f.ComponentDefType);
                    Log.updateLog(l, "HardpointSlot" + delimiter + f.HardpointSlot);
                    Log.updateLog(l, "IsFixed" + delimiter + f.IsFixed);
                    Log.updateLog(l, "GUID" + delimiter + f.GUID);
                    Log.updateLog(l, "DamageLevel" + delimiter + f.DamageLevel);
                    Log.updateLog(l, "prefabName" + delimiter + f.prefabName);
                    Log.updateLog(l, "hasPrefabName" + delimiter + f.hasPrefabName);
                }
            }

            Log.updateLog(l, "ChassisTags.tagSetSourceFile" + delimiter + chassis.ChassisTags.tagSetSourceFile);

            if (chassis.ChassisTags.items == null)
            {
                Log.updateLog(l, "No ChassisTag items array to unroll");
            }
            else
            {
                Log.updateLog(l, "Preparing to unroll " + chassis.ChassisTags.items.Length + " ChassisTag.items");
                foreach (string s in chassis.ChassisTags.items)
                {
                    Log.updateLog(l, "ChassisTags.item " + s);
                }
            }

            if (chassis.LOSSourcePositions == null)
            {
                Log.updateLog(l, "No LOSSourcePositions array to unroll");
            }
            else
            {
                Log.updateLog(l, "Preparing to unroll " + chassis.LOSSourcePositions.Length + " LOSSourcePositions");
                foreach (LOSSourcePositions s in chassis.LOSSourcePositions)
                {
                    Log.updateLog(l, "x" + delimiter + s.x);
                    Log.updateLog(l, "y" + delimiter + s.y);
                    Log.updateLog(l, "z" + delimiter + s.z);
                }
            }

            if (chassis.LOSTargetPositions == null)
            {
                Log.updateLog(l, "No LOSTargetPositions array to unroll");
            }
            else
            {
                Log.updateLog(l, "Preparing to unroll " + chassis.LOSTargetPositions.Length + " LOSTargetPositions");
                foreach (LOSTargetPositions s in chassis.LOSTargetPositions)
                {
                    Log.updateLog(l, "x" + delimiter + s.x);
                    Log.updateLog(l, "y" + delimiter + s.y);
                    Log.updateLog(l, "z" + delimiter + s.z);
                }
            }

            if (chassis.StabilityDefenses == null)
            {
                Log.updateLog(l, "No StabilityDefenses array to unroll");
            }
            else
            {
                Log.updateLog(l, "Preparing to unroll " + chassis.StabilityDefenses.Length + " StabilityDefenses");
                foreach (int i in chassis.StabilityDefenses)
                {
                    Log.updateLog(l, i.ToString());
                }
            }

            Log.updateLog(l, "Unroll completed");

        }

        // If the file is loaded, loop through the chassis.Locations to find the location with the matching name. 
        // If the file is not loaded or no match is found, throw an exception
        public Locations GetLocation(string locationName, MainWindow.ProcessMode mode)
        {
            switch (mode)
            {
                case MainWindow.ProcessMode.SINGLE:
                    return GetLocationForSingle(locationName);
                case MainWindow.ProcessMode.BATCH:
                    return GetLocationForBatch(locationName);
            }
            return null;
        }

        private Locations GetLocationForSingle(string locationName)
        {
            if (!FileLoaded())
            {
                string exception = "Cannot find location '" + locationName + " because chassis file not loaded";
                Log.updateLog(Log.LogType.EXCEPTION, exception);
                throw new Exception(exception);
            }

            if (chassis.Locations == null || chassis.Locations.Length == 0)
            {
                string exception = "Cannot find location '" + locationName + " because no locations found in this chassis";
                Log.updateLog(Log.LogType.EXCEPTION, exception);
                throw new Exception(exception);
            }

            Locations loc = new Locations("FAILED");

            foreach (Locations l in chassis.Locations)
            {
                if (l.Location.Equals(locationName))
                {
                    loc = l;
                }
            }

            if (loc.Location.Equals("FAILED"))
            {
                string exception = "Unable to find a Locations with the Location '" + locationName + "'";
                Log.updateLog(Log.LogType.EXCEPTION, exception);
                throw new Exception(exception);
            }

            return loc;
        }

        private Locations GetLocationForBatch(string locationName)
        {
            if (batchChassis.Locations == null || batchChassis.Locations.Length == 0)
            {
                string exception = "Cannot find location '" + locationName + " because no locations found in this chassis";
                Log.updateLog(Log.LogType.EXCEPTION, exception);
                throw new Exception(exception);
            }

            Locations loc = new Locations("FAILED");

            foreach (Locations l in batchChassis.Locations)
            {
                if (l.Location.Equals(locationName))
                {
                    loc = l;
                }
            }

            if (loc.Location.Equals("FAILED"))
            {
                string exception = "Unable to find a Locations with the Location '" + locationName + "'";
                Log.updateLog(Log.LogType.EXCEPTION, exception);
                throw new Exception(exception);
            }

            return loc;
        }

        public void AddHardpoint(string locationName, Hardpoint inHardpoint, MainWindow.ProcessMode mode)
        {
            Log.updateLog(Log.LogType.HARDPOINT, "Adding hardpoint: " + inHardpoint.WeaponMount + ":" + inHardpoint.Omni.ToString());
            Locations location = GetLocation(locationName, mode);
            Log.updateLog(Log.LogType.HARDPOINT, "Location match - " + location.Location);
            if (location.Hardpoints == null)
            {
                Log.updateLog(Log.LogType.HARDPOINT, "Location has no hardpoint array, creating one now");
                location.Hardpoints = new Hardpoint[0];
            }
            Hardpoint[] hardpoints = location.Hardpoints;
            Hardpoint[] newHardpoints = new Hardpoint[hardpoints.Length + 1];

            for (int i = 0; i < hardpoints.Length; i++)
            {
                newHardpoints[i] = hardpoints[i];
            }

            newHardpoints[hardpoints.Length] = inHardpoint;
            location.Hardpoints = newHardpoints;
            Log.updateLog(Log.LogType.HARDPOINT, "Hardpoint added");
        }

        public void RemoveHardpoint(string locationName, Hardpoint inHardpoint, MainWindow.ProcessMode mode)
        {
            Log.updateLog(Log.LogType.HARDPOINT, "Removing hardpoint from " + locationName);
            Locations location = GetLocation(locationName, mode);
            Log.updateLog(Log.LogType.HARDPOINT, "Location match - " + location.Location);
            if (location.Hardpoints == null)
            {
                Log.updateLog(Log.LogType.HARDPOINT, "Location has no hardpoint array");
                return;
            }
            Hardpoint[] hardpoints = location.Hardpoints;
            Log.updateLog(Log.LogType.HARDPOINT, "Stored location's hardpoints");
            if (hardpoints.Length == 0)
                return;

            Log.updateLog(Log.LogType.HARDPOINT, "Number of hardpoints: " + hardpoints.Length);

            Hardpoint[] newHardpoints = new Hardpoint[hardpoints.Length - 1];
            bool removed = false;

            int newIndex = 0;
            // Loop through the array of hardpoints
            for (int index = 0; index < hardpoints.Length; index++)
            {
                // if we have not yet removed one, then check each entry against the inHardpoint
                if (!removed)
                {
                    if (hardpoints[index].WeaponMount.ToUpper().Equals(inHardpoint.WeaponMount.ToUpper())
                        && hardpoints[index].Omni == inHardpoint.Omni)
                    {
                        Log.updateLog(Log.LogType.HARDPOINT, "Found hardpoint to remove");
                        // If we find a match, we flip the removed bool and continue to the next item in hardpoints
                        removed = true;
                        continue;
                    }
                    else
                    {
                        // if we haven't removed one, yet, and this one does not match the input hardpoint, then add it to newHardpoints and increment newIndex
                        newHardpoints[newIndex] = hardpoints[index];
                        newIndex++;
                    }
                }
                else
                {
                    // if we have already removed a hardpoint, we don't want to remove any more. We just keep moving the remaining items from hardpoints to newHardpoints
                    newHardpoints[newIndex] = hardpoints[index];
                    newIndex++;
                }
            }

            // if we removed a hardpoint, then the location needs to be updated
            if (removed)
            {
                Log.updateLog(Log.LogType.HARDPOINT, "Hardpoint removed");
                location.Hardpoints = newHardpoints;
            }
        }

        public void UpdateChassisLocations()
        {
            Log.updateLog(Log.LogType.FILELOAD, "Updating locations");
            foreach (Locations l in chassis.Locations)
            {
                Log.updateLog(Log.LogType.FILELOAD, "Initializing Hardpoint for location " + l.Location);
                if (l.Hardpoints == null)
                    l.Hardpoints = new Hardpoint[0];
            }
        }

        public bool DirectoryLoaded()
        {
            return !batchDirectory.Equals("");
        }

        public void ClearBatchChanges()
        {
            batchChassis = new Chassis();
        }

        public void PerformBatchChanges(BatchChange[] changes, bool writeLog, string logFileName)
        {
            Log.updateLog(Log.LogType.MODELUPDATE, "Preparing to perform batch changes");
            if (changes == null ||
                changes.Length == 0)
                return;

            string[] files = Directory.GetFiles(batchDirectory, "chassisdef*.json", SearchOption.AllDirectories);
            if (files.Length == 0)
            {
                string exception = "No chassisdef json files found in " + batchDirectory;
                Log.updateLog(Log.LogType.EXCEPTION, exception);
                throw new Exception(exception);
            }
            string log = "";
            foreach (string fileName in files)
            {
                Log.updateLog(Log.LogType.MODELUPDATE, "preparing to process " + fileName);
                if (writeLog)
                    log += fileName + ": ";
                try
                {
                    Log.updateLog(Log.LogType.MODELUPDATE, "Reading in " + fileName);
                    string fileText = File.ReadAllText(fileName);
                    Log.updateLog(Log.LogType.MODELUPDATE, "storing to batchChassis");
                    batchChassis = JsonConvert.DeserializeObject<Chassis>(fileText);
                    PerformChanges(changes);
                    Log.updateLog(Log.LogType.MODELUPDATE, "Serializing batchChassis");
                    fileText = JsonConvert.SerializeObject(batchChassis, Formatting.Indented);
                    Log.updateLog(Log.LogType.MODELUPDATE, "Writing to " + fileName);
                    File.WriteAllText(fileName, fileText);
                    if (writeLog)
                        log += "Success!" + "\n";
                } catch (Exception ex)
                {
                    if (writeLog)
                        log += "Failed - " + ex.Message + "\n";
                }
            }
            if (writeLog)
            {
                logFileName = batchDirectory + "\\" + logFileName;
                Log.updateLog(Log.LogType.FILEWRITE, "Writing the log file to " + logFileName);
                File.WriteAllText(logFileName, log);
            }
        }

        public void PerformChanges(BatchChange[] changes)
        {

            Log.updateLog(Log.LogType.MODELUPDATE, "Performing " + changes.Length + " changes");
            foreach (BatchChange change in changes)
            {
                Log.updateLog(Log.LogType.MODELUPDATE, "Attempting " + change.GetLabelText(BatchChangeGroupBox.maxLabelLength));
                string field = "";
                string group = "";
                Locations location = new Locations("FAILED");

                // the dot splits the source between the group (or the location) and the field (variable)
                string[] sourceParts = change.source.Split('.');
                group = sourceParts[0];
                field = sourceParts[1];
                Log.updateLog(Log.LogType.MODELUPDATE, "Performing change on " + group + " " + field);
                ChassisContainer holder = batchChassis;

                if (!FieldIsHardpoint(field))
                {
                    Log.updateLog(Log.LogType.MODELUPDATE, "Not a hardpoint");
                    // break down by group and get the holder
                    switch (group)
                    {
                        case "Description":
                            switch (field)
                            {
                                case "VariantName":
                                    holder = batchChassis;
                                    break;
                                case "StockRole":
                                    holder = batchChassis;
                                    break;
                                case "YangsThoughts":
                                    holder = batchChassis;
                                    break;
                                default:
                                    holder = batchChassis.description;
                                    break;
                            }
                            break;
                        case "General":
                            holder = batchChassis;
                            break;
                        case "Movement":
                            holder = batchChassis;
                            break;
                        case "Combat":
                            holder = batchChassis;
                            break;
                        case "Head":
                            holder = GetLocation("Head", MainWindow.ProcessMode.BATCH);
                            break;
                        case "CenterTorso":
                            holder = GetLocation("CenterTorso", MainWindow.ProcessMode.BATCH);
                            break;
                        case "LeftTorso":
                            holder = GetLocation("LeftTorso", MainWindow.ProcessMode.BATCH);
                            break;
                        case "RightTorso":
                            holder = GetLocation("RightTorso", MainWindow.ProcessMode.BATCH);
                            break;
                        case "LeftArm":
                            holder = GetLocation("LeftArm", MainWindow.ProcessMode.BATCH);
                            break;
                        case "RightArm":
                            holder = GetLocation("RightArm", MainWindow.ProcessMode.BATCH);
                            break;
                        case "LeftLeg":
                            holder = GetLocation("LeftLeg", MainWindow.ProcessMode.BATCH);
                            break;
                        case "RightLeg":
                            holder = GetLocation("RightLeg", MainWindow.ProcessMode.BATCH);
                            break;
                    }
                    Log.updateLog(Log.LogType.MODELUPDATE, "holder = " + holder.ToString());
                    /*
                    To update the field I must break this down in to operations (plus, minus, equal)
                    Then I must perform that operation based on the type
                    plus string is append
                    minus string is replace with ''
                    equal string is set

                    plus float is add
                    minus float is subtract
                    equal float is set

                    plus bool is toggle
                    minus bool is toggle
                    equal bool is set
                    */
                    string textValue = "";
                    float floatValue = 0;
                    bool boolValue = false;
                    if (!holder.GetField(field, ref textValue, ref floatValue, ref boolValue))
                    {
                        // Failed to get the field from the holder
                        throw new Exception("Failed to get the " + field + " field from the holder " + holder.ToString());
                    }
                    Log.updateLog(Log.LogType.MODELUPDATE, "Got these values for " + field +
                        " t-" + textValue + " | " +
                        "f-" + floatValue.ToString() + " | " +
                        "b-" + boolValue.ToString());

                    // break it down by operation and type, then perform the change
                    switch (change.operation)
                    {
                        case BatchChange.Operator.PLUS:
                            Log.updateLog(Log.LogType.MODELUPDATE, "Performing addition");
                            switch (change.type)
                            {
                                case BatchChange.Type.STRING:
                                    textValue = textValue + " " + change.textValue;
                                    break;
                                case BatchChange.Type.FLOAT:
                                    floatValue += change.floatValue;
                                    break;
                                case BatchChange.Type.BOOL:
                                    boolValue = !boolValue;
                                    break;
                            }
                            break;
                        case BatchChange.Operator.MINUS:
                            Log.updateLog(Log.LogType.MODELUPDATE, "Performing subtraction");
                            switch (change.type)
                            {
                                case BatchChange.Type.STRING:
                                    textValue = textValue.Replace(change.textValue, "");
                                    break;
                                case BatchChange.Type.FLOAT:
                                    floatValue -= change.floatValue;
                                    break;
                                case BatchChange.Type.BOOL:
                                    boolValue = !boolValue;
                                    break;
                            }
                            break;
                        case BatchChange.Operator.EQUALS:
                            Log.updateLog(Log.LogType.MODELUPDATE, "Performing equal");
                            switch (change.type)
                            {
                                case BatchChange.Type.STRING:
                                    textValue = change.textValue;
                                    break;
                                case BatchChange.Type.FLOAT:
                                    floatValue = change.floatValue;
                                    break;
                                case BatchChange.Type.BOOL:
                                    boolValue = change.boolValue;
                                    break;
                            }
                            break;
                    }
                    Log.updateLog(Log.LogType.MODELUPDATE, "After Updating " + field +
                        " t-" + textValue + " | " +
                        "f-" + floatValue.ToString() + " | " +
                        "b-" + boolValue.ToString());
                    // Set the change back in the holder
                    holder.SetField(field, textValue, floatValue, boolValue);
                }
                else
                {
                    // Performing a hardpoint change is different. 
                    // First I have to make the appropriate hardpoint
                    // then I have to perform the operation a number of times
                    Hardpoint h = new Hardpoint();
                    h.WeaponMount = field.Replace("Omni", "").Replace("True", "").Replace("False", "");
                    h.Omni = field.Replace("Omni", "").Replace(h.WeaponMount, "").Equals("True");
                    Log.updateLog(Log.LogType.MODELUPDATE, "Created Hardpoint " + h.WeaponMount + " Omni " + h.Omni.ToString());
                    switch (change.operation)
                    {
                        case BatchChange.Operator.EQUALS:
                            // To set a number of hardpoints, we need to know how many we have
                            // Then we compare to how many we need
                            // Then we add/remove as necessary
                            location = GetLocationForBatch(group);
                            int numHardpoints = CountHardpoints(location, h);

                            // if there are less than desired, loop adding
                            if (numHardpoints < change.floatValue)
                            {
                                for (int i = 0; i < (change.floatValue - numHardpoints); i++)
                                {
                                    AddHardpoint(location.Location, h, MainWindow.ProcessMode.BATCH);
                                }
                            }
                            // if there are more than desired, loop removing
                            else if (numHardpoints > change.floatValue)
                            {
                                for (int i = 0; i < (numHardpoints - change.floatValue); i++)
                                {
                                    RemoveHardpoint(location.Location, h, MainWindow.ProcessMode.BATCH);
                                }
                            }
                            break;
                        case BatchChange.Operator.MINUS:
                            // To remove hardpoints, we need to know how many we have
                            // if we count less than we change, 
                            // set count to count, else set count to change
                            // loop removing

                            location = GetLocationForBatch(group);
                            numHardpoints = CountHardpoints(location, h);
                            int numRemove = 0;
                            if (numHardpoints < change.floatValue)
                            {
                                numRemove = numHardpoints;
                            }
                            else
                                numRemove = Convert.ToInt32(change.floatValue);

                            for(int i = 0; i < numRemove; i++)
                            {
                                RemoveHardpoint(location.Location, h, MainWindow.ProcessMode.BATCH);
                            }
                            break;
                        case BatchChange.Operator.PLUS:
                            // To add hardpoints, we just loop over the change adding the hardpoint

                            location = GetLocationForBatch(group);
                            for (int i = 0; i < change.floatValue; i++)
                            {
                                AddHardpoint(location.Location, h, MainWindow.ProcessMode.BATCH);
                            }
                            break;
                    }
                }
            }
        }

        public bool FieldIsHardpoint(string field)
        {
            Log.updateLog(Log.LogType.MODELUPDATE, "Is this a hardpoint: " + field);
            switch (field)
            {
                case "EnergyOmniTrue":
                    return true;
                case "EnergyOmniFalse":
                    return true;
                case "BallisticOmniTrue":
                    return true;
                case "BallisticOmniFalse":
                    return true;
                case "AntiPersonnelOmniTrue":
                    return true;
                case "AntiPersonnelOmniFalse":
                    return true;
                case "MissileOmniTrue":
                    return true;
                case "MissileOmniFalse":
                    return true;
            }
            return false;
        }

        public int CountHardpoints(Locations location, Hardpoint hIn)
        {
            int numHardpoints = 0;

            foreach(Hardpoint h in location.Hardpoints)
            {
                if (h.WeaponMount.Equals(hIn.WeaponMount) &&
                    h.Omni == hIn.Omni)
                    numHardpoints++;
            }


            return numHardpoints;
        }
    }
}
 
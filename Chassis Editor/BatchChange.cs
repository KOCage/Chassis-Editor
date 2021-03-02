using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chassis_Editor
{
    // A BatchChange is a group, Location, or other data source with an operation and a value.
    // BatchController will maintain an array of BatchChanges created by the user
    public class BatchChange
    {
        public string source = "";
        public enum Operator { EQUALS, PLUS, MINUS };
        public Operator operation = Operator.EQUALS;

        public enum Type { STRING, FLOAT, BOOL };
        public Type type = Type.STRING;

        public string textValue = "";
        public float floatValue = 0;
        public bool boolValue = false;

        public void SetValue(string value)
        {
            textValue = value;
            type = Type.STRING;
        }

        public void SetValue(float value)
        {
            floatValue = value;
            type = Type.FLOAT;
        }

        public void SetValue(bool value)
        {
            boolValue = value;
            type = Type.BOOL;
        }

        public bool Equals(BatchChange other)
        {
            // if we don't have the same source, we are not equal
            if (!other.source.Equals(source))
                return false;
            // if not the same operation
            if (other.operation != operation)
                return false;
            // if not the same type
            if (other.type != type)
                return false;
            // if a string value and not the same string value
            if (type == Type.STRING &&
                textValue.ToUpper().Equals(other.textValue.ToUpper()))
                return false;
            // if a float value and not the same float value
            if (type == Type.FLOAT &&
                floatValue != other.floatValue)
                return false;
            // if a bool value and not the same bool value
            if (type == Type.BOOL &&
                boolValue != other.boolValue)
                return false;

            // if all is the same, return true
            return true;
        }

        public string GetLabelText(int maxLength)
        {
            string[] sourceParts = source.Split('.');
            string field = sourceParts[1];

            string labelText = source + " ";
            switch (operation)
            {
                case Operator.EQUALS:
                    labelText += "= ";
                    break;
                case Operator.MINUS:
                    labelText += "- ";
                    break;
                case Operator.PLUS:
                    labelText += "+ ";
                    break;
            }

            switch (type)
            {
                case Type.STRING:
                    labelText += textValue;
                    break;
                case Type.FLOAT:
                    labelText += floatValue.ToString();
                    break;
                case Type.BOOL:
                    labelText += boolValue.ToString();
                    break;
            }

            if (labelText.Length > maxLength)
            {
                labelText = labelText.Substring(0, maxLength - 3);
                labelText += "...";
            }       
            return labelText;
        }
    }
}

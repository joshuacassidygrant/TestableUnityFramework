﻿using System.Collections.Generic;

namespace TofuCore.Configuration
{
    /*
     * A Configuration object is consumed by an IConfigurable to generate a properties dictionary
     */
    [System.Serializable]
    public class Configuration
    {
        public List<ConfigurationProperty> Properties = new List<ConfigurationProperty>();

        public void AddProperty(string id, dynamic value)
        {
            Properties.Add(new ConfigurationProperty(id, value.ToString()));
        }

        public List<ConfigurationProperty>.Enumerator GetEnumerator()
        {
            return Properties.GetEnumerator();
        } 
    }

    [System.Serializable]
    public class ConfigurationProperty
    {
        public string Key; 
        public string Value;

        public ConfigurationProperty(string id, string value)
        {
            Key = id;
            Value = value;
        }

        public int ValueAsInt(int def)
        {
            int result;

            if (int.TryParse(Value, out result))
            {
                return result;
            }

            return def;
        }

        public float ValueAsFloat(float def)
        {
            float result;

            if (float.TryParse(Value, out result))
            {
                return result;
            }
            return def;
        }

        public bool ValueAsBool(bool def)
        {
            bool result;

            if (bool.TryParse(Value, out result)) {
                return result;
            }

            return def;
        }
    }
}

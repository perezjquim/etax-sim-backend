using System;
using System.Collections.Generic;

namespace eTaxSim.Simulation.SimulationStrategies.LiquidSalary.Util
{
    public class Parameters
    {
        private readonly IDictionary<string, object> MapParameters;

        public Parameters(IDictionary<string, object> aParameters)
        {
            this.MapParameters = aParameters;
        }

        public bool GetBool(string aKey)
        {
            dynamic mapValue = MapParameters[aKey];
            bool value;

            if (mapValue.GetType() is bool)
            {
                return mapValue;
            }

            try
            {
                value = bool.Parse(mapValue);
            }
            catch (Exception)
            {
                value = mapValue.Equals("0");
            }

            return value;
        }

        public double GetDouble(string aKey)
        {
            dynamic mapValue = MapParameters[aKey];

            if (mapValue.GetType() is double)
            {
                return mapValue;
            }
            double value = double.Parse(mapValue);
            return value;
        }

        public int GetInt(string aKey)
        {
            dynamic mapValue = MapParameters[aKey];

            if (mapValue.GetType() is int)
            {
                return mapValue;
            }
            int value = int.Parse(mapValue);
            return value;
        }

        public string GetString(string aKey)
        {
            dynamic mapValue = MapParameters[aKey];

            if (mapValue.GetType() is string)
            {
                return mapValue;
            }
            string value = mapValue.ToString();
            return value;
        }

        public Twelfths GeTwelfths(string aKey)
        {
            dynamic mapValue = MapParameters[aKey];
            Twelfths myEnum;

            if (mapValue.GetType() is string)
            {
                myEnum = convertToTwelfths(mapValue);
                return myEnum;
            }
            myEnum = convertToTwelfths(mapValue.ToString());
            return myEnum;

        }

        private Twelfths convertToTwelfths(string value)
        {
            Twelfths myEnum = (Twelfths)Enum.Parse(typeof(Twelfths), value, true);
            return myEnum;
        }
    }
}
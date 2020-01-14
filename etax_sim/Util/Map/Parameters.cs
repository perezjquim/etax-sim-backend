using System.Collections.Generic;

namespace eTaxSim.Util.Map
{
    public class Parameters : IMapHelper
    {
        private readonly IDictionary<string, object> MapParameters;

        public Parameters(IDictionary<string, object> aParameters)
        {
            this.MapParameters = aParameters;
        }

        public bool GetBool(string aKey)
        {
            dynamic mapValue = MapParameters[aKey];

            if (mapValue.GetType() is bool)
            {
                return mapValue;
            }
            bool value = bool.Parse(mapValue);
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
    }
}
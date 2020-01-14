namespace eTaxSim.Util.Map
{
    public interface IMapHelper
    {
        string GetString(string aKey);
        bool GetBool(string aKey);
        int GetInt(string aKey);
        double GetDouble(string aKey);
    }
}
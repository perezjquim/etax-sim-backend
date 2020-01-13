using System.Collections;

namespace eTaxSim.Simulation.Model
{
    public class ResponseResult
    {
        public object Parameters { get; set; }
        public int ErrorCode { get; set; }
        public ArrayList ErrorMessage { get; set; }
    }
}

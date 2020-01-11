using System;
using System.Collections;
using System.Collections.Generic;

namespace eTaxSim.Simulation
{
    public class ResponseResult
    {
        public object Parameters { get; set; }
        public int ErrorCode { get; set; }
        public ArrayList ErrorMessage { get; set; }
    }
}

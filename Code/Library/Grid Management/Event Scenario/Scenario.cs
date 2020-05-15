using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Scenario : EventArgs
    {
        public EScenario scenario { get; private set; }
        public bool isSuccess;
        public Scenario(EScenario scenario, bool isSuccess) : base()
        {
            this.scenario = scenario;
            this.isSuccess = isSuccess;
        }
    }
}

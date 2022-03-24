using System;
using System.Collections.Generic;
using System.Text;

namespace Threading
{
    public class Accident
    {
        public int ID { get; set; }
        public string Cause { get; set; }

        public Accident(int id, string cause)
        {
            this.ID = id;
            this.Cause = cause;
                
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Threading
{
    public class Car
    {
        public int ID { get; set; }
        public string Model { get; set; }
        public int Speed { get; set; }
        public Car(int id, string model, int speed )
        {
            this.ID = id;
            this.Model = model;
            this.Speed = speed;

        }
    }
}

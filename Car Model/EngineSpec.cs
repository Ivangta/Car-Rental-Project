using System;
using System.Collections.Generic;
using System.Text;

namespace Car_Model
{
    public class EngineSpec 
    {
        public EngineSpec(EngineSpec engineSpecification)
        {
            Capacity = engineSpecification.Capacity;
            HorsePower = engineSpecification.HorsePower;
            FuelType = engineSpecification.FuelType;
        }

        public EngineSpec(float capacity, int horsePower, FuelTypeEnum fuelType)
        {
            this.Capacity = capacity;
            this.HorsePower = horsePower;
            this.FuelType = fuelType;
        }
        
        public float Capacity { get; set; }
        public int HorsePower { get; set; }
        public FuelTypeEnum FuelType { get; set; }
    }
}

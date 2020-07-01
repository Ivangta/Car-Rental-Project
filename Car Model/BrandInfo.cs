using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Car_Model
{
    public class BrandInfo : IEquatable<BrandInfo>
    {
        public BrandInfo(string brand, string model) 
        {
            this.Brand = brand;
            this.Model = model;
        }

        public string Brand { get; }
        public string Model { get; }

        public bool Equals([AllowNull] BrandInfo other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Brand == other.Brand && this.Model == other.Model;
        }

        public void MyMethod()
        {
            var brandInfo1 = new BrandInfo("Audi", "A3");
            var brandInfo2 = new BrandInfo("Audi", "A3");

            Console.WriteLine(brandInfo1.Equals(brandInfo2));
        }


    }
}

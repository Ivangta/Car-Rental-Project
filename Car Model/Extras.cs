using System;
using System.Collections.Generic;
using System.Text;

namespace Car_Model
{
    public class Extras 
    {
        public Extras(string extraType)
        {
            this.ExtraType = extraType;
        }
        public string ExtraType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Car_Model
{
    public class Extra
    {
        public Extra(List<string> extras)
        {
            this.Extras = extras;
        }
        public List<string> Extras { get; set; }
    }
}

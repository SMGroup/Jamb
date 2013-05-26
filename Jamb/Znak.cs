using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jamb
{
    public class Znak
    {
        public int value;
        public string ime;
        public Znak(int value=0, string ime=" ")
        {
            this.value = value;
            this.ime = ime;
        }
        public Znak() 
        {
            value = 0;
            ime = " ";
        }
        
        public override string ToString()
        {
            return String.Format("{0} - {1}",ime, value);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jamb
{
    public class Najava
    {
        int value;
        string ime;

        public Najava(int value = 0, string ime= "" )
        {
            this.value = value;
            this.ime = ime;
        }

        public Najava(int value = 0)
        {
            this.value = value;
        }

        public Najava()
        {
            value = 0;
            ime = " ";
        }

        public int Value
        {
            get { return value; }

        }

        public string Ime
        {
            set { ime = value; }
            get { return ime; }
        }

        public override string ToString()
        {
            return String.Format("{0}", ime);
        }
    }
}

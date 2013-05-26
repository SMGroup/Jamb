using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jamb
{
    public class Dice
    {
        int value;
        bool isHeld;

        public int Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public bool IsHeld
        {
            get { return isHeld; }
            set { isHeld = value; }
        }

        public Dice(int diceValue)
        {
            value = diceValue;
            isHeld = false;
        }
    }
}

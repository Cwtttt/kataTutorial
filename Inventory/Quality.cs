using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.Inventory
{
    public class Quality
    {
        public int Amount { get; internal set; }
        public Quality(int amount)
        {
            Amount = amount;
        }

        public void Degrade()
        {
            Amount--;
        }
        public void Increase()
        {
            Amount++;
        }

        public void Reset()
        {
            Amount = 0;
        }

        public bool LessThan50()
        {
            return Amount < 50;
        }

        public bool GreaterThan0()
        {
            return Amount > 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rogalik.Models
{
    public class Armor : Item
    {
        public int Defense { get; set; }

        public override string ToString()
        {
            return $"{Name} (+{Defense} защиты)";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rogalik.Models
{
    public class Weapon : Item
    {
        public int Attack {  get; set; }

        public override string ToString()
        {
            return $"{Name} (+{Attack} атаки)";
        }
    }
}

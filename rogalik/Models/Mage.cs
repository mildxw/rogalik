using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rogalik.Models
{
    public class Mage : Enemy
    {
        public Mage() 
        {
            Name = "Маг";
            HP = 25;
            Attack = 15;
            Defense = 2;
        }

        public override int FreezeChance => 15;
    }
}

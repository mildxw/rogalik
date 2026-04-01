using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rogalik.Models
{
    public class VVG : Goblin
    {
        public VVG()
        {
            Name = "ВВГ";
            HP = 60;
            Attack = 18;
            Defense = 3;
        }

        public override int CritChance => 30;
    }
}

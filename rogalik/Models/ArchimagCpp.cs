using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rogalik.Models
{
    public class ArchimagCpp : Mage
    {
        public ArchimagCpp()
        {
            Name = "Архимаг С++";
            HP = 45;
            Attack = 24;
            Defense = 2;
        }

        public override int FreezeChance => 25;
    }
}

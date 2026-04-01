using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rogalik.Models
{
    public class Skeleton : Enemy
    {
        public Skeleton() 
        {
            Name = "Скелет";
            HP = 40;
            Attack = 10;
            Defense = 5;
        }

        public override bool IgnoresArmor => true;
    }
}

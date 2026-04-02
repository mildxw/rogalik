using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rogalik.Models;

namespace rogalik.Factories
{
    public static class EnemyFactory
    {
        public static Enemy CreateRandomEnemy(Random random)
        {
            int type = random.Next(3);

            switch (type)
            { 
                case 0:
                    return new Goblin();
                case 1:
                    return new Skeleton();
                case 2:
                    return new Mage();
                default:
                    return new Goblin();
            }
        }
    }
}

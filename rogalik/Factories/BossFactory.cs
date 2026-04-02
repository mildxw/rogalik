using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rogalik.Models;

namespace rogalik.Factories
{
    public static class BossFactory
    {
        public static Enemy CreateRandomBoss(Random random)
        {
            int type = random.Next(4);

            switch (type)
            {
                case 0:
                    return new VVG();
                case 1:
                    return new Kovalskiy();
                case 2:
                    return new ArchimagCpp();
                case 3:
                    return new PestovMinusMinus();
                default:
                    return new VVG();
            }
        }
    }
}

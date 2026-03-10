using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace robot_11_3_Storchevaya
{
    partial class GameRobot
    {
        public int kollife;
        public int getlife()
        {
            return kollife;
        }
        public void Min(int a)
        {
            kollife = a;
            kollife = kollife / 2;
        }
        public void Kol(int a, int k)
        {
            if (a / 2 == k)
            {
                kollife = kollife + 30;
            }
            else if (a * 0.7 == k)
            {
                kollife = kollife + 20;
            }
        }
    }
}

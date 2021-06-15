using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPR_Projekt
{
    class Level
    {

        public int LevelSpielfeldX;
        public int LevelSpielfeldY;
        private int _LevelLayout;
        public int LevelLayout
        {
            get { return _LevelLayout; }
            set { _LevelLayout = value; }
        }

        //public Array[] sammlung;

        public Level()
        {


        }

        public int Hindernisse(int levelLayout)
        {

            switch (levelLayout)
            {
                case 1:
                    LevelSpielfeldX = 4;
                    LevelSpielfeldY = 5;

                    break;
                case 2:
                    LevelSpielfeldX = 8;
                    LevelSpielfeldY = 6;
                    int[,] hindernisse = new int[6, 8] {
                        { 0, 0, 0, 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0, 0, 0, 0 } };
                    break;
            }
            return LevelSpielfeldX & LevelSpielfeldY;
        }
    }
}

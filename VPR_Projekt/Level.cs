using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPR_Projekt
{
    class Level
    {
        private int _LevelLayout;
        public int LevelLayout
        {
            get { return _LevelLayout; }
            set { _LevelLayout = value; }
        }
        //public int[,] hindernisse;
        //public Array[] sammlung;

        public Level()
        {
            

        }

        public int Hindernisse(int levelLayout)
        {
            Spiel test = new Spiel();
            
            switch (levelLayout)
            {
                case 1:
                    test.spielfeldX = 6;
                    test.spielfeldY = 4;
                    //sammlung[0] = hindernisse;
                    break;
            }
            return test.spielfeldX & test.spielfeldY;
        }
    }
}

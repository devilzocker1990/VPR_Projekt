using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace VPR_Projekt
{
    class Level
    {

        public int LevelSpielfeldX;
        public int LevelSpielfeldY;

        StreamReader streamReader;
        string[] zeilen = new string[10];



        //public Array[] sammlung;

        public Level()
        {

        }
        public void ArraysAuslesen()
        {
            streamReader = File.OpenText(@"Levelstrings.txt");
            int counter = 0;
            while (!streamReader.EndOfStream)
            {
                zeilen[counter] = streamReader.ReadLine();
                counter++;
            }
        }

        public string[] SplitAuslese(int level)
        {
            string[] charakter = zeilen[level].Split(',');
            return charakter;
        }

        public Bloecke[,] Hindernisse(int levelLayout)
        {
            Bloecke[,] hindernisse = new Bloecke[0, 0];
            string[] array;
            int counter;
            switch (levelLayout + 1)
            {
                case 1:
                    LevelSpielfeldX = 4;
                    LevelSpielfeldY = 5;
                    ArraysAuslesen();
                    hindernisse = new Bloecke[4, 5];
                    array = SplitAuslese(0);
                    counter = 0;
                    for (int y = 0; y < hindernisse.GetLength(1); y++)
                    {
                        for (int x = 0; x < hindernisse.GetLength(0); x++)
                        {
                            Bloecke bloecke = new Bloecke();
                            hindernisse[x, y] = bloecke.BlockErstellung(1);
                            hindernisse[x, y].wert = Convert.ToInt32(array[counter].ToString());
                            counter++;
                        }
                    }

                    return hindernisse;
                case 2:
                    hindernisse = new Bloecke[6, 8];
                    ArraysAuslesen();
                    array = SplitAuslese(1);
                    counter = 0;
                    for (int y = 0; y < hindernisse.GetLength(1); y++)
                    {
                        for (int x = 0; x < hindernisse.GetLength(0); x++)
                        {
                            hindernisse[x, y].wert = Convert.ToInt32(array[counter]);
                            counter++;
                        }
                    }

                    return hindernisse;



                    /*{
                    { 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0 } }*/
                    ;
                    
            }
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace VPR_Projekt
{
    /// <summary>
    /// Diese Klasse erstellt einen Modifizierten button
    /// </summary>
    public class Bloecke : Button
    {
        private int _wert;


        public int wert
        {
            get { return _wert; }
            set { _wert = value; }
        }


        /// <summary>
        /// Gibt einen der 5 verschiedenen Blöcke zurück, je nachdem welche Ganzzahl(int) bei Methodenaufruf übergeben wurde.
        /// </summary>
        /// <param name="wert">Eine Ganzzahl</param>
        /// <returns>Ein objekt der Klasse Bloecke</returns>
        public Bloecke BlockErstellung(int wert)
        {
            Bloecke blockart = new Bloecke();
            switch (wert)
            {
                case 1:
                    blockart.wert = 1;
                    blockart.Background = Brushes.Red;
                    return blockart;
                case 2:
                    blockart.wert = 2;
                    blockart.Background = Brushes.Blue;
                    return blockart;
                case 3:
                    blockart.wert = 3;
                    blockart.Background = Brushes.Green;
                    return blockart;
                case 4:
                    blockart.wert = 4;
                    blockart.Background = Brushes.Yellow;
                    return blockart;
                case 5:
                    blockart.wert = 5;
                    blockart.Background = Brushes.Black;
                    return blockart;
                case 69:
                    blockart.wert = 69;
                    blockart.Background = Brushes.HotPink;
                    return blockart;
            }
            return blockart;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VPR_Projekt
{
    /// <summary>
    /// Diese Klasse erstellt einen Modifizierten button
    /// </summary>
    public class Bloecke : Button
    {
        private int _wert;

        public ImageBrush bansaiBrush;
        public ImageBrush foxBrush;
        public ImageBrush oniBrush;
        public ImageBrush ramenBrush;          
        public ImageBrush sakeBrush;

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
            GetBrushes();
            Bloecke blockart = new Bloecke();
            switch (wert)
            {
                case 1:
                    bansaiBrush.Stretch = Stretch.Uniform;
                    blockart.wert = 1;
                    blockart.Background = bansaiBrush;
                    return blockart;
                case 2:
                    foxBrush.Stretch = Stretch.Uniform;
                    blockart.wert = 2;
                    blockart.Background = foxBrush;
                    return blockart;
                case 3:
                    oniBrush.Stretch = Stretch.Uniform;
                    blockart.wert = 3;
                    blockart.Background = oniBrush;
                    return blockart;
                case 4:
                    ramenBrush.Stretch = Stretch.Uniform;
                    blockart.wert = 4;
                    blockart.Background = ramenBrush;
                    return blockart;
                case 5:
                    sakeBrush.Stretch = Stretch.Uniform;
                    blockart.wert = 5;
                    blockart.Background = sakeBrush;
                    return blockart;
                case 69:
                    blockart.wert = 69;
                    blockart.Background = Brushes.Black;
                    return blockart;
            }
            return blockart;
        }
        public void GetBrushes()
        {
            bansaiBrush = new ImageBrush();
            bansaiBrush.ImageSource = new BitmapImage(new Uri(@"Media\Blöcke\Bansai.png", UriKind.Relative));
            foxBrush = new ImageBrush();
            foxBrush.ImageSource = new BitmapImage(new Uri(@"Media\Blöcke\FoxMask.png", UriKind.Relative));
            oniBrush = new ImageBrush();
            oniBrush.ImageSource = new BitmapImage(new Uri(@"Media\Blöcke\OniMask.png", UriKind.Relative));
            ramenBrush = new ImageBrush();
            ramenBrush.ImageSource = new BitmapImage(new Uri(@"Media\Blöcke\Ramen.png", UriKind.Relative));
            sakeBrush = new ImageBrush();
            sakeBrush.ImageSource = new BitmapImage(new Uri(@"Media\Blöcke\Sake.png", UriKind.Relative));
        }
    }
}

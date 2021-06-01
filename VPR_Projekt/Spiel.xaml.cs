using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VPR_Projekt
{
    /// <summary>
    /// Interaktionslogik für Spiel.xaml
    /// </summary>
    public partial class Spiel : Window
    {
        //Erstellt ein Bloecke Array
        public Bloecke[,] block;

        //2 Int Werte welche die Spielfeldgröße festlegen
        public int spielfeldY;
        public int spielfeldX;

        //Ein Array welches x,y für das Verschieben Speichert
        public int[] blockposition;

        //Ein Bool welcher angibt ob bereits ein Stein für den Tausch ausgewählt wurde
        public bool firstPick;

        // ein objekt der Klasse Bloecke welcher als zwischenspeicher für den Tausch fungiert
        private Bloecke btnToSwitch;

        //2 Int Werte welche die X und Y position des Angeklickten buttons Spreichern
        int X;
        int Y;

        /// <summary>
        /// Der Konstruktor welcher für den Start die werte Festlegt und beim start des Programms
        /// ausgewählte Methoden aufruft.
        /// </summary>
        public Spiel()
        {
            InitializeComponent();
            firstPick = false;
            spielfeldX = 10;
            spielfeldY = 10;
            block = new Bloecke[spielfeldX, spielfeldY];
            blockposition = new int[2];
            Spielfeld();
        }

        /// <summary>
        /// Erstellt das Spielfeld, in dem ein grid mit Bloecke elementen gefüllt wird.
        /// </summary>
        public void Spielfeld()
        {
            Random ran = new Random();
            for (int y = 0; y < spielfeldY; y++)
            {
                for (int x = 0; x < spielfeldX; x++)
                {
                    Bloecke bloecke = new Bloecke();
                    block[x, y] = bloecke.BlockErstellung(ran.Next(1, 6));
                    block[x, y].Click += new RoutedEventHandler(OnClick);
                    Grid.SetColumn(block[x, y], x);
                    Grid.SetRow(block[x, y], y);
                    spielfeldGrid.Children.Add(block[x, y]);
                }
            }
        }

        /// <summary>
        /// eine Methode welche festlegt, was bei einem Click passieren soll.
        /// </summary>
        /// <param name="sender">Das Ausgewählter objekt</param>
        /// <param name="e"></param>
        void OnClick(object sender, RoutedEventArgs e)
        {
            Bloecke btn = (Bloecke)sender;
            X = GetColum(btn);
            Y = GetRow(btn);
            if (!firstPick)
            {
                blockposition[0] = X;
                blockposition[1] = Y;
                btnToSwitch = (Bloecke)sender;
                firstPick = true;
            }
            else if (X - 1 == blockposition[0] && Y == blockposition[1] || X + 1 == blockposition[0] && Y == blockposition[1] || Y - 1 == blockposition[1] && X == blockposition[0] || Y + 1 == blockposition[1] && X == blockposition[0])
            {
                firstPick = false;
                block[X, Y] = btnToSwitch;
                block[blockposition[0], blockposition[1]] = (Bloecke)sender;
                spielfeldGrid.Children.Clear();

                for (int y = 0; y < spielfeldY; y++)
                {
                    for (int x = 0; x < spielfeldX; x++)
                    {
                        Grid.SetColumn(block[x, y], x);
                        Grid.SetRow(block[x, y], y);
                        spielfeldGrid.Children.Add(block[x, y]);
                    }
                }
            }
            else
            {
                blockposition[0] = X;
                blockposition[1] = Y;
                btnToSwitch = (Bloecke)sender;
            }

        }

        /// <summary>
        /// Lässt leere felder nach oben wandern indem es ein leeres feld mit einem befüllten feld tauscht.
        /// </summary>
        private void FeldEinrückung()
        {
            Random ran = new Random();
            for (int i = Y; i > 0; i--)
            {
                for (int j = X; j > 0; j--)
                {
                    if (block[X, Y].wert == 0)
                    {
                        if (block[X, Y - 1].wert == 0)
                        {
                            int counter = 1;
                            for (int k = 1; k > block.GetLength(0) - 1; k++)
                            {
                                if (block[X, Y - 1].wert == 0)
                                {
                                    counter++;
                                }
                                else
                                {
                                    block[X, Y].wert = block[X, Y - counter].wert;
                                    block[X, Y - counter].wert = 0;
                                }
                            }
                        }
                        else
                        {
                            block[X, Y].wert = block[X, Y - 1].wert;
                            block[X, Y - 1].wert = 0;
                        }
                    }
                    if (block[X, 0].wert == 0)
                    {
                        block[X, 0].BlockErstellung(ran.Next(1, 6));
                    }
                }
            }
        }
        /// <summary>
        /// Gibt den Wert der Spallte in welcher sich der Button befindet zurück
        /// </summary>
        /// <param name="btn">button objekt</param>
        /// <returns>Ganzzahl(int)</returns>
        private int GetColum(Bloecke btn)
        {
            return (int)btn.GetValue(Grid.ColumnProperty);
        }
        /// <summary>
        /// Gibt den Wert der Reihe in welcher sich der Button befindet zurück
        /// </summary>
        /// <param name="btn">button objekt</param>
        /// <returns>Ganzzahl(int)</returns>
        private int GetRow(Bloecke btn)
        {
            return (int)btn.GetValue(Grid.RowProperty);
        }
    }
}

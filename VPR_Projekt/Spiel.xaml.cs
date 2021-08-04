using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;


namespace VPR_Projekt
{
    /// <summary>
    /// Interaktionslogik für Spiel.xaml
    /// </summary>
    public partial class Spiel : Window
    {
        SqlConnection database = new SqlConnection();

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

        int[] roundx = { 0, 1, 0, -1 };
        int[] roundy = { -1, 0, 1, 0 };
        int[] duoblock = new int[4];

        /// <summary>
        /// Der Konstruktor welcher für den Start die werte Festlegt und beim start des Programms
        /// ausgewählte Methoden aufruft.
        /// </summary>
        public Spiel()
        {
            try
            {
                database.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;" + "AttachDbFilename=|DataDirectory|\\scoresToReach.mdf;" + "Integrated Security=True";
                database.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("Database not found");
            }
            InitializeComponent();
            firstPick = false;
            spielfeldX = 10;
            spielfeldY = 10;
            block = new Bloecke[spielfeldX, spielfeldY];
            blockposition = new int[2];
            Spielfeld();
            QuestTextBlock.Text = String.Format("\t Aufgabe: \n \t Erreiche {0} Combos \n \t in {1} Zügen!",X,X);
            Points.Content = "0";
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
                ComboFirstBlock();
                spielfeldGrid.Children.Clear();

                for (int y = 0; y < spielfeldY; y++)
                {
                    for (int x = 0; x < spielfeldX; x++)
                    {
                        Bloecke bloecke = new Bloecke();
                        block[x, y] = bloecke.BlockErstellung(block[x, y].wert);
                        block[x, y].Click += new RoutedEventHandler(OnClick);
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
            for (int i = spielfeldY - 1; i > 0; i--)
            {
                for (int j = spielfeldX - 1; j > 0; j--)
                {
                    if (block[i, j].wert == 69)
                    {
                        if (block[i, j - 1].wert == 69)
                        {
                            int counter = 1;
                            for (int k = 1; k > block.GetLength(0) - 1; k++)
                            {
                                if (block[i, j - 1].wert == 69)
                                {
                                    counter++;
                                }
                                else
                                {
                                    block[i, j].wert = block[i, j - counter].wert;
                                    block[i, j - counter].wert = 0;
                                }
                            }
                        }
                        else
                        {
                            block[i, j].wert = block[i, j - 1].wert;
                            block[i, j - 1].wert = 0;
                        }
                    }
                    if (block[j, 0].wert == 69)
                    {
                        block[j, 0].BlockErstellung(ran.Next(1, 6));
                    }
                }
            }
        }


        /*
                int[] roundx = { 0, 1, 0, -1 };
                int[] roundy = { -1, 0, 1, 0 };*/

        bool top = false;
        bool right = false;
        bool bot = false;
        bool left = false;
        void ComboFirstBlock()
        {
            for (int g = 0; g < spielfeldY; g++)
            {
                for (int t = 0; t < spielfeldX; t++)
                {
                    blockposition[0] = g; // braucht man eigentlich
                    blockposition[1] = t;
                    for (int i = 0; i < 4; i++) 
                    {
                
                        if (blockposition[1] + roundy[i] >= 0 && blockposition[1] + roundy[i] < spielfeldY  && blockposition[0] + roundx[i] >= 0 && blockposition[0] + roundy[i] < spielfeldX - 1)
                        {


                            if (block[blockposition[0], blockposition[1]].wert == block[blockposition[0] + roundx[i], blockposition[1] + roundy[i]].wert)
                            {
                                switch (i + 1)
                                {
                                    case 1:
                                        if (blockposition[1] - 2 > 0 && block[blockposition[0], blockposition[1] - 1].wert == block[blockposition[0], blockposition[1] - 2].wert)
                                        {
                                            top = true;
                                        }
                                        break;
                                    case 2:
                                        if (blockposition[0] + 2 < spielfeldX && block[blockposition[0] + 1, blockposition[1]].wert == block[blockposition[0] + 2, blockposition[1]].wert)
                                        {
                                            right = true;
                                        }
                                        break;
                                    case 3:
                                        if (blockposition[1] + 2 < spielfeldY && block[blockposition[0], blockposition[1] + 1].wert == block[blockposition[0], blockposition[1] + 2].wert)
                                        {
                                            bot = true;
                                        }
                                        break;
                                    case 4:
                                        if (blockposition[0] - 2 > 0 && block[blockposition[0] - 1, blockposition[1]].wert == block[blockposition[0] - 2, blockposition[1]].wert)
                                        {
                                            left = true;
                                        }
                                        break;
                                };
                            }
                        }
                    }
                    if (top)
                    {
                        for (int yyy = 1; yyy < spielfeldY; yyy++)
                        {
                            if (blockposition[1] - yyy >= 0 && block[blockposition[0], blockposition[1]].wert == block[blockposition[0], blockposition[1] - yyy].wert)
                            {
                                if (block[blockposition[0], blockposition[1] - yyy].wert != 69)
                                {
                                    Points.Content = Convert.ToInt32(Points.Content) + 50;
                                    block[blockposition[0], blockposition[1] - yyy].wert = 69;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    if (right)
                    {
                        for (int xxx = 1; xxx < spielfeldX; xxx++)
                        {
                            if (blockposition[0] + xxx < spielfeldX && block[blockposition[0], blockposition[1]].wert == block[blockposition[0] + xxx, blockposition[1]].wert)
                            {
                                if (block[blockposition[0] + xxx, blockposition[1]].wert != 69)
                                {
                                    Points.Content = Convert.ToInt32(Points.Content) + 50;
                                    block[blockposition[0] + xxx, blockposition[1]].wert = 69;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    if (bot)
                    {
                        for (int yy = 1; yy < spielfeldY; yy++)
                        {
                            if (blockposition[1] + yy < spielfeldY && block[blockposition[0], blockposition[1]].wert == block[blockposition[0], blockposition[1] + yy].wert)
                            {
                                if (block[blockposition[0], blockposition[1] + yy].wert != 69)
                                {
                                    Points.Content = Convert.ToInt32(Points.Content) + 50;
                                    block[blockposition[0], blockposition[1] + yy].wert = 69;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    if (left)
                    {
                        for (int xx = 1; xx < spielfeldX; xx++)
                        {
                            if (blockposition[0] - xx >= 0 && block[blockposition[0], blockposition[1]].wert == block[blockposition[0] - xx, blockposition[1]].wert)
                            {
                                if (block[blockposition[0] - xx, blockposition[1]].wert != 69)
                                {
                                    Points.Content = Convert.ToInt32(Points.Content) + 50;
                                    block[blockposition[0] - xx, blockposition[1]].wert = 69;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    if (top || right || bot || left)
                    {
                        block[blockposition[0], blockposition[1]].wert = 69;
                        top = false;
                        right = false;
                        bot = false;
                        left = false;
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

        private void BackBtn(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void OptionBtn(object sender, RoutedEventArgs e)
        {

        }
    }
}

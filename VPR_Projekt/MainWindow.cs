using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VPR_Projekt
{
    /// <summary>
    /// Erstellt das Hauptmenü
    /// </summary>
    public partial class MainWindow : Window
    {
        int fontSize = 36;
        ImageBrush brush;
        SqlConnection database;
        string connectionString;

        public MainWindow()
        {
            
            brush = new ImageBrush();
            InitializeComponent();
            GenerateMainMenu();
            string connectionPath = System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\scoresToReach.mdf";
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFileName=" + connectionPath + ";Integrated Security=True";
            database = new SqlConnection(connectionString);
        }
        /// <summary>
        /// Generiert das Hauptmenü, mit einem Label und drei Buttons.
        /// </summary>
        private void GenerateMainMenu()
        {
            Image image = new Image();
            StackPanel.Children.Clear();
            Label label = new Label();
            label.Content = "Bansai Crush";
            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.FontSize = fontSize;
            label.FontFamily = new FontFamily("Segoe Print");
            label.FontWeight = FontWeights.Bold;
            label.Margin = new Thickness(0, 50, 0, 50);
            StackPanel.Children.Add(label);
            for (int i = 1; i < 4; i++)
            {
                Button button = new Button();
                int fontsize = 24;
                int widthsize = 130;
                int marginsize = 10;
                button.HorizontalAlignment = HorizontalAlignment.Center;
                button.Margin = new Thickness(marginsize);
                button.FontFamily = new FontFamily("Segoe Print");
                button.Background = Brushes.Transparent;
                button.FontSize = fontsize;
                button.Width = widthsize;
                if (i == 1)
                {
                    button.Content = "Spielen";
                    button.Click += new RoutedEventHandler(PlayBtn_Click);
                }
                if (i == 2)
                {
                    button.Content = "Optionen";
                    button.Click += new RoutedEventHandler(OptionBtn_Click);
                    button.IsEnabled = false;
                }
                if (i == 3)
                {
                    button.Content = "Verlassen";
                    button.Click += new RoutedEventHandler(ExitBtn_Click);
                }
                StackPanel.Children.Add(button);
            }
        }

        /// <summary>
        /// Generiert die Levelauswahl mit neun Buttons.
        /// </summary>
        private void Levelauswahl()
        {
            StackPanel.Children.Clear();
            Label label = new Label();
            label.Content = "Levelauswahl";
            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.FontSize = fontSize;
            label.FontFamily = new FontFamily("Segoe Print");
            label.Margin = new Thickness(0, 0, 0, 50);
            StackPanel.Children.Add(label);
            Grid grid = new Grid();

            for (int i = 0; i < 2; i++)
            {
                ColumnDefinition gridCol = new ColumnDefinition();
                grid.ColumnDefinitions.Add(gridCol);
            }

            for (int i = 0; i < 4; i++)
            {
                RowDefinition gridRow = new RowDefinition();
                grid.RowDefinitions.Add(gridRow);
            }

            StackPanel.Children.Add(grid);
            for (int i = 1; i < 9; i++)
            {
                Button button = new Button();
                Image image = new Image();
                string btnName = "Level " + i;
                int fontSize = 23;
                int btnWidthSize = 180;
                int btnnHeightSize = 56;
                button.HorizontalAlignment = HorizontalAlignment.Center;
                button.Margin = new Thickness(0, 0, 0, 10);
                button.FontSize = fontSize;
                button.FontFamily = new FontFamily("Segoe Print");
                button.Width = btnWidthSize;
                button.Height = btnnHeightSize;

                switch (i)
                {
                    case 1:
                        
                        button.Content = btnName;
                        button.Background = Brushes.Transparent;
                        button.Click += new RoutedEventHandler(Level1Btn_Click);
                        Grid.SetRow(button, 0);
                        Grid.SetColumn(button, 0);
                        break;

                    case 2:
                        button.Content = btnName;
                        button.Click += new RoutedEventHandler(Level2Btn_Click);
                        Grid.SetRow(button, 0);
                        Grid.SetColumn(button, 1);
                        SqlCommand getLevel2Need = new SqlCommand("SELECT (oneStar) FROM scoresToReach WHERE levelID = 2", database);
                        SqlCommand getLevel1Score = new SqlCommand("SELECT (high) FROM Highscore WHERE levelID = 1", database);
                        database.Open();
                        string lvl1high = getLevel1Score.ExecuteScalar().ToString();
                        int lvl1highscore = Convert.ToInt32(lvl1high);
                        string lvl2 = getLevel2Need.ExecuteScalar().ToString();
                        int lvl2NeededPoints = Convert.ToInt32(lvl2);
                        MessageBox.Show("lvl1highscore: " + lvl1highscore + "  ... you need for lvl2" + lvl2NeededPoints);
                        database.Close();
                        if (lvl1highscore >= lvl2NeededPoints)
                        {
                            button.IsEnabled = true;
                        }
                        else
                        {
                            button.IsEnabled = false;
                        }

                        break;
                    case 3:
                        button.Content = btnName;
                        button.Click += new RoutedEventHandler(Level3Btn_Click);
                        Grid.SetRow(button, 1);
                        Grid.SetColumn(button, 0);
                        SqlCommand getLevel3Need = new SqlCommand("SELECT (oneStar) FROM scoresToReach WHERE levelID = 3", database);
                        SqlCommand getLevel2Score = new SqlCommand("SELECT (high) FROM Highscore WHERE levelID = 2", database);
                        database.Open();
                        string lvl2high = getLevel2Score.ExecuteScalar().ToString();
                        int lvl2highscore = Convert.ToInt32(lvl2high);
                        string lvl3 = getLevel3Need.ExecuteScalar().ToString();
                        int lvl3NeededPoints = Convert.ToInt32(lvl3);
                        database.Close();
                        if (lvl2highscore >= lvl3NeededPoints)
                        {
                            button.IsEnabled = true;
                        }
                        else
                        {
                            button.IsEnabled = false;
                        }

                        break;
                    case 4:
                        button.Content = btnName;
                        button.Click += new RoutedEventHandler(Level4Btn_Click);
                        Grid.SetRow(button, 1);
                        Grid.SetColumn(button, 1);
                        SqlCommand getLevel4Need = new SqlCommand("SELECT (oneStar) FROM scoresToReach WHERE levelID = 4", database);
                        SqlCommand getLevel3Score = new SqlCommand("SELECT (high) FROM Highscore WHERE levelID = 3", database);
                        database.Open();
                        string lvl3high = getLevel3Score.ExecuteScalar().ToString();
                        int lvl3highscore = Convert.ToInt32(lvl3high);
                        string lvl4 = getLevel4Need.ExecuteScalar().ToString();
                        int lvl4NeededPoints = Convert.ToInt32(lvl4);
                        database.Close();
                        if (lvl3highscore >= lvl4NeededPoints)
                        {
                            button.IsEnabled = true;
                        }
                        else
                        {
                            button.IsEnabled = false;
                        }
                        break;
                    case 5:
                        button.Content = btnName;
                        button.Click += new RoutedEventHandler(Level5Btn_Click);
                        Grid.SetRow(button, 2);
                        Grid.SetColumn(button, 0);
                        SqlCommand getLevel5Need = new SqlCommand("SELECT (oneStar) FROM scoresToReach WHERE levelID = 5", database);
                        SqlCommand getLevel4Score = new SqlCommand("SELECT (high) FROM Highscore WHERE levelID = 4", database);
                        database.Open();
                        string lvl4high = getLevel4Score.ExecuteScalar().ToString();
                        int lvl4highscore = Convert.ToInt32(lvl4high);
                        string lvl5 = getLevel5Need.ExecuteScalar().ToString();
                        int lvl5NeededPoints = Convert.ToInt32(lvl5);
                        database.Close();
                        if (lvl4highscore >= lvl5NeededPoints)
                        {
                            button.IsEnabled = true;
                        }
                        else
                        {
                            button.IsEnabled = false;
                        }
                        break;
                    case 6:
                        button.Content = btnName;
                        button.Click += new RoutedEventHandler(Level6Btn_Click);
                        Grid.SetRow(button, 2);
                        Grid.SetColumn(button, 1);
                        SqlCommand getLevel6Need = new SqlCommand("SELECT (oneStar) FROM scoresToReach WHERE levelID = 6", database);
                        SqlCommand getLevel5Score = new SqlCommand("SELECT (high) FROM Highscore WHERE levelID = 5", database);
                        database.Open();
                        string lvl5high = getLevel5Score.ExecuteScalar().ToString();
                        int lvl5highscore = Convert.ToInt32(lvl5high);
                        string lvl6 = getLevel6Need.ExecuteScalar().ToString();
                        int lvl6NeededPoints = Convert.ToInt32(lvl6);
                        database.Close();
                        if (lvl5highscore >= lvl6NeededPoints)
                        {
                            button.IsEnabled = true;
                        }
                        else
                        {
                            button.IsEnabled = false;
                        }
                        break;
                    case 7:
                        button.Content = btnName;
                        button.Click += new RoutedEventHandler(Level7Btn_Click);
                        Grid.SetRow(button, 3);
                        Grid.SetColumn(button, 0);
                        SqlCommand getLevel7Need = new SqlCommand("SELECT (oneStar) FROM scoresToReach WHERE levelID = 7", database);
                        SqlCommand getLevel6Score = new SqlCommand("SELECT (high) FROM Highscore WHERE levelID = 6", database);
                        database.Open();
                        string lvl6high = getLevel6Score.ExecuteScalar().ToString();
                        int lvl6highscore = Convert.ToInt32(lvl6high);
                        string lvl7 = getLevel7Need.ExecuteScalar().ToString();
                        int lvl7NeededPoints = Convert.ToInt32(lvl7);
                        database.Close();
                        if (lvl6highscore >= lvl7NeededPoints)
                        {
                            button.IsEnabled = true;
                        }
                        else
                        {
                            button.IsEnabled = false;
                        }
                        break;
                    case 8:
                        button.Content = btnName;
                        button.Click += new RoutedEventHandler(Level8Btn_Click);
                        Grid.SetRow(button, 3);
                        Grid.SetColumn(button, 1);
                        SqlCommand getLevel8Need = new SqlCommand("SELECT (oneStar) FROM scoresToReach WHERE levelID = 8", database);
                        SqlCommand getLevel7Score = new SqlCommand("SELECT (high) FROM Highscore WHERE levelID = 7", database);
                        database.Open();
                        string lvl7high = getLevel7Score.ExecuteScalar().ToString();
                        int lvl7highscore = Convert.ToInt32(lvl7high);
                        string lvl8 = getLevel8Need.ExecuteScalar().ToString();
                        int lvl8NeededPoints = Convert.ToInt32(lvl8);
                        database.Close();
                        if (lvl7highscore >= lvl8NeededPoints)
                        {
                            button.IsEnabled = true;
                        }
                        else
                        {
                            button.IsEnabled = false;
                        }
                        break;

                }
                grid.Children.Add(image);
                grid.Children.Add(button);

            }
            Button backbtn = new Button();
            backbtn.Content = "Zurück";
            backbtn.HorizontalAlignment = HorizontalAlignment.Center;
            backbtn.Margin = new Thickness(0, 50, 0, 0);
            backbtn.FontSize = 23;
            backbtn.Width = 100;
            backbtn.FontFamily = new FontFamily("Segoe Print");
            backbtn.Click += new RoutedEventHandler(BackBtn_Click);
            StackPanel.Children.Add(backbtn);
        }

        /// <summary>
        /// Generiert das Optionsmenü.
        /// </summary>
        private void OptionsMenu()
        {
            
        }

        /// <summary>
        /// Generiert die Levelauswahlmenü und schließt das Hauptmenü.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayBtn_Click(object sender, RoutedEventArgs e)
        {
            Levelauswahl();
        }

        /// <summary>
        /// Generiert das Optionsmenü und schließt das Hauptmenü.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptionBtn_Click(object sender, RoutedEventArgs e)
        {
            OptionsMenu();
        }

        /// <summary>
        ///  Generiert das Level 1 und schließt die Levelauswahl.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Level1Btn_Click(object sender, RoutedEventArgs e)
        {
            Spiel level1 = new Spiel();
            level1.Show();
            this.Close();
        }

        /// <summary>
        ///  Generiert das Level 2 und schließt die Levelauswahl.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Level2Btn_Click(object sender, RoutedEventArgs e)
        {
            Spiel level2 = new Spiel();
            level2.Show();
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Level3Btn_Click(object sender, RoutedEventArgs e)
        {
            //Level3 level3 = new Level3();
            //level3.Show();
            this.Close();
        }

        /// <summary>
        ///  Generiert das Level 4 und schließt die Levelauswahl.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Level4Btn_Click(object sender, RoutedEventArgs e)
        {
            //Level4 level4 = new Level4();
            //level4.Show();
            this.Close();
        }

        /// <summary>
        ///  Generiert das Level 5 und schließt die Levelauswahl.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Level5Btn_Click(object sender, RoutedEventArgs e)
        {
            //Level5 level5 = new Level5();
            //level5.Show();
            this.Close();
        }

        /// <summary>
        ///  Generiert das Level 6 und schließt die Levelauswahl.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Level6Btn_Click(object sender, RoutedEventArgs e)
        {
            //Level6 level6 = new Level6();
            //level6.Show();
            this.Close();
        }

        /// <summary>
        ///  Generiert das Level 7 und schließt die Levelauswahl.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Level7Btn_Click(object sender, RoutedEventArgs e)
        {
            //Level7 level7 = new Level7();
            //level7.Show();
            this.Close();
        }

        /// <summary>
        ///  Generiert das Level 8 und schließt die Levelauswahl.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Level8Btn_Click(object sender, RoutedEventArgs e)
        {
            //Level8 level8 = new Level8();
            //level8.Show();
            this.Close();
        }

        /// <summary>
        ///  Generiert das Hauptmenü und schließt die Levelauswahl.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            GenerateMainMenu();
        }

        /// <summary>
        /// Scließt das Programm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

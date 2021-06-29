using System;
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
        BitmapImage brush;
        public MainWindow()
        {
            brush = new BitmapImage();
            InitializeComponent();
            GenerateMainMenu();
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
                image.Width = 200;
                image.Stretch = Stretch.UniformToFill;

                switch (i)
                {
                    case 1:
                        brush.UriSource = new Uri(@"Media\Level\NoLotusLevel.png", UriKind.Relative);
                        image.Source = brush;
                        button.Content = btnName;
                        button.Background = Brushes.Transparent;
                        button.Click += new RoutedEventHandler(Level1Btn_Click);
                        Grid.SetRow(image, 0);
                        Grid.SetColumn(image, 0);
                        Grid.SetRow(button, 0);
                        Grid.SetColumn(button, 0);
                        break;

                    case 2:
                        button.Content = btnName;
                        button.Click += new RoutedEventHandler(Level2Btn_Click);
                        button.IsEnabled = false;
                        Grid.SetRow(button, 0);
                        Grid.SetColumn(button, 1);

                        break;
                    case 3:
                        button.Content = btnName;
                        button.Click += new RoutedEventHandler(Level3Btn_Click);
                        button.IsEnabled = false;
                        Grid.SetRow(button, 1);
                        Grid.SetColumn(button, 0);

                        break;
                    case 4:
                        button.Content = btnName;
                        button.Click += new RoutedEventHandler(Level4Btn_Click);
                        button.IsEnabled = false;
                        Grid.SetRow(button, 1);
                        Grid.SetColumn(button, 1);
                        break;
                    case 5:
                        button.Content = btnName;
                        button.Click += new RoutedEventHandler(Level5Btn_Click);
                        button.IsEnabled = false;
                        Grid.SetRow(button, 2);
                        Grid.SetColumn(button, 0);
                        break;
                    case 6:
                        button.Content = btnName;
                        button.Click += new RoutedEventHandler(Level6Btn_Click);
                        button.IsEnabled = false;
                        Grid.SetRow(button, 2);
                        Grid.SetColumn(button, 1);
                        break;
                    case 7:
                        button.Content = btnName;
                        button.Click += new RoutedEventHandler(Level7Btn_Click);
                        button.IsEnabled = false;
                        Grid.SetRow(button, 3);
                        Grid.SetColumn(button, 0);
                        break;
                    case 8:
                        button.Content = btnName;
                        button.Click += new RoutedEventHandler(Level8Btn_Click);
                        button.IsEnabled = false;
                        Grid.SetRow(button, 3);
                        Grid.SetColumn(button, 1);
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
            //Level2 level2 = new Level2();
            //level2.Show();
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

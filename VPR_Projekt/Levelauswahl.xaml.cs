using System.Windows;

namespace VPR_Projekt
{
    /// <summary>
    /// Erstellt die Levelauswahl
    /// </summary>
    public partial class Levelauswahl : Window
    {
        public Levelauswahl()
        {
            InitializeComponent();
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
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}

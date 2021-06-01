using System.Windows;

namespace VPR_Projekt
{
    /// <summary>
    /// Erstellt das Hauptmenü
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //GenerateMenu();
        }
        //private void GenerateMenu()
        //{
        //    StackPanel stackPanel = new StackPanel();
        //    stackPanel.Name = "Stacker";
        //    Label label = new Label();
        //    Button playbtn = new Button();
        //    label.Content = "Placeholder";
        //    label.HorizontalAlignment = HorizontalAlignment.Center;
        //    label.FontSize = 36;
        //    label.Margin = new Thickness(0, 0, 0, 50);
        //    playbtn.Content = "Spielen";
        //    playbtn.HorizontalAlignment = HorizontalAlignment.Center;
        //    playbtn.Margin = new Thickness(10);
        //    playbtn.FontSize = 24;
        //    playbtn.Width = 100;
        //    playbtn.Click += new RoutedEventHandler(Button_Click);
        //    stackPanel.Orientation = Orientation.Vertical;
        //}
        /// <summary>
        /// Generiert die Levelauswahlmenü und schließt das Hauptmenü.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayBtn_Click(object sender, RoutedEventArgs e)
        {
            Levelauswahl levelauswahl = new Levelauswahl();
            //levelauswahl.Owner = this;
            levelauswahl.Show();
            this.Close();
        }
        /// <summary>
        /// Generiert das Optionsmenü und schließt das Hauptmenü.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptionBtn_Click(object sender, RoutedEventArgs e)
        {
            //OptionsMenü optionsmenü = new OptionsMenü();
            //optionsmenü.Show();
            this.Close();
        }
        /// <summary>
        /// Generiert die Levelauswahlmenü und schließt das Hauptmenü.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

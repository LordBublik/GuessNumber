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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GuessNumber
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int randomNumber;
        private int attempts;
        public MainWindow()
        {
            InitializeComponent();
            RestartGame();
        }

        private void CheckBtn_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(InputNumberTb.Text, out int guessedNumber))
            {
                attempts++;
                Historylb.Items.Add(guessedNumber);
                if (guessedNumber < randomNumber)
                {
                    HintTbl.Text = "MALO";
                    InputNumberTb.BorderBrush = System.Windows.Media.Brushes.Red;
                }
                else if (guessedNumber > randomNumber)
                {
                    HintTbl.Text = "MNOGO";
                    InputNumberTb.BorderBrush = System.Windows.Media.Brushes.Red;
                }
                else
                {
                    HintTbl.Text = $"HOROSH, UGADAL ZA {attempts} POPITOK";
                    InputNumberTb.IsEnabled = false;
                    CheckBtn.IsEnabled = false;
                    InputNumberTb.BorderBrush = System.Windows.Media.Brushes.Green;
                }
                if (Math.Abs(guessedNumber - randomNumber) <= 5 && guessedNumber != randomNumber)
                {
                    HintTbl.Text += "/BLizKO";
                }
            }
            else
            {
                MessageBox.Show("PISHi normaLNO"); 
            }
        }

        private void Restartbtn_Click(object sender, RoutedEventArgs e)
        {
            RestartGame();
        }

        private void RestartGame()
        {
            Random rand = new Random();
            randomNumber = rand.Next(1, 101);
            attempts = 0;
            InputNumberTb.IsEnabled = true;
            CheckBtn.IsEnabled = true;
            InputNumberTb.Clear();
            HintTbl.Text = "";
            Historylb.Items.Clear();
            InputNumberTb.BorderBrush = System.Windows.Media.Brushes.Black;
        }
    }
}

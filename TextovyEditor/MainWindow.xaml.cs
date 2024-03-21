using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace TextovyEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string path;
        public MainWindow()
        {

            InitializeComponent();
        }
        private void Nacist_BTN(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog
            {
                Title = "Otevřít soubor",
                Filter = "txt files (*.txt)|*.txt"
            };
            if (OFD.ShowDialog() == true)
            {
                path = OFD.FileName;
                uloz.IsEnabled = true;
                Precti();
            }
        }
        private void Zapis(string obsah)
        {
            DateTime currentDateTime = DateTime.Now;

            if (Vstup.Text.Length == 0)
            {

            }

            else
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine($"{obsah} \n{currentDateTime}");
                }
            }
        }

        public void Precti()
        {
            string obsah = "";
            using (StreamReader sr = new StreamReader(path))
            {
                string radek;
                
                while ((radek = sr.ReadLine()) != null)
                { 
                    obsah += radek + "\n";
                }
            }
            TB.Text = obsah;
        }

        private void uloz_Click(object sender, RoutedEventArgs e)
        {
            if (Vstup.Text.Length == 0)
            {
                MessageBox.Show("Napiš nějaký text!!!", "Chyba");
            }

            Zapis(Vstup.Text);
            Vstup.Text = "";
            Precti();
        }

    }
}

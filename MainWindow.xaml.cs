using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppLetra.Models;

namespace letraWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SolidColorBrush szin;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Sli_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            byte red = (byte)redSli.Value;
            byte green = (byte)greenSli.Value;
            byte blue = (byte)blueSli.Value;

            szin = new SolidColorBrush(Color.FromRgb((byte)red, (byte)green, (byte)blue));

            colorEll.Fill = szin;
        }

        List<Jatekos> jatekosok = new List<Jatekos>();
        private void regBtn(object sender, RoutedEventArgs e)
        {
            Jatekos nev = new Jatekos(playerNameTb.Text, szin as SolidColorBrush);

            if (playerNameTb.Text == "")
            {
                MessageBox.Show("Adj meg egy nevet!");
                return;
            }

            var item = new ListBoxItem()
            {
                Content = nev.Nev,
                Foreground = nev.Szin
            };

            jatekosok.Add(nev);

            jatekosLb.Items.Add(item);

            jatekosNeve.Content = $"jatékos: {nev.Nev}";
        }

        int allas = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {   if(jatekosok.Count == 0)
            {
                MessageBox.Show("Adj hozzá játékost!");
                return;
            }

            Random rnd = new Random();
            int dobas = rnd.Next(1, 7);
            allas += dobas;

            eredmenyLb.Content = dobas;
            Output.Items.Add(allas);

            if(allas % 10 == 0)
            {
                MessageBox.Show("Megcsúsztál, lépj vissza 3 mezőt!");
                allas -= 3;
                Output.Items.Add(allas);
            }

            if(allas >= 45)
            {
                MessageBox.Show("Nyertél!");
                allas = 0;
                Output.Items.Clear();
                eredmenyLb.Content = "";
            }
        }
    }
}
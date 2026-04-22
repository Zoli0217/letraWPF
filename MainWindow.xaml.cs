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
            if (playerNameTb.Text == "")
            {
                MessageBox.Show("Adj meg egy nevet!");
                return;
            }
            
            Jatekos nev = new Jatekos(playerNameTb.Text, szin);

            var item = new ListBoxItem()
            {
                Content = nev.Nev,
                Foreground = nev.Szin
            };

            jatekosok.Add(nev);

            jatekosLb.Items.Add(item);

            jatekosNeve.Content = $"jatékos: {nev.Nev}";
            jatekosNeve.Foreground = nev.Szin;
        }

        int aktualisJatekosIndex = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {   if(jatekosok.Count == 0)
            {
                MessageBox.Show("Adj hozzá játékost!");
                return;
            }

            Jatekos aktualis = jatekosok[aktualisJatekosIndex];
            jatekosNeve.Content = $"Játékos: {aktualis.Nev}";


            Random rnd = new Random();
            int dobas = rnd.Next(1, 7);
            int ujPozicio = aktualis.Pozicio + dobas;
            aktualis.Lep(ujPozicio);

            eredmenyLb.Content = dobas;
            Output.Items.Add(ujPozicio);

            if(ujPozicio % 10 == 0)
            {
                MessageBox.Show("Megcsúsztál, lépj vissza 3 mezőt!");
                ujPozicio -= 3;
                Output.Items.Add(ujPozicio);
            }

            if(ujPozicio >= 45)
            {
                MessageBox.Show("Nyertél!");
                aktualis.Ujrakzedes();
                Output.Items.Clear();
                eredmenyLb.Content = "";
            }
            aktualisJatekosIndex++;
            if (aktualisJatekosIndex >= jatekosok.Count)
            {
                aktualisJatekosIndex = 0;
            }
        }
    }
}
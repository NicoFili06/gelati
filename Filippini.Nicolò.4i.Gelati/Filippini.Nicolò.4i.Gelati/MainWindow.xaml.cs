using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Filippini.Nicolò._4i.Gelati.Ingrediente;

namespace Filippini.Nicolò._4i.Gelati

{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Ingredienti ingredienti = new Ingredienti();
        Gelati gelati = new Gelati();

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Filippini_Window_Loaded(object sender, RoutedEventArgs e)
        {
            ingredienti = new("Ingredienti.csv");
            dataGridIngredienti.ItemsSource = ingredienti;
            gelati = new("Gelati.csv");
            dataGridGelati.ItemsSource = gelati;
        }
        private void dataGridGelati_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Gelato g = e.AddedItems[0] as Gelato;

            if (g != null)
            {
                statusbar.Text = $"hai selezionato {g.Nome} {g.Descrizione}";

                Ingredienti ingredientifiltrati = new();
                foreach (var item in ingredienti)
                    if (item.idGelato == g.IdGelato)
                        ingredientifiltrati.Add(item);
                dataGridIngredienti.ItemsSource = ingredientifiltrati;
            }
        }
        private void dataGridIngredienti_SelectionChanged(object sender, SelectionChangedEventArgs e) { }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }

}

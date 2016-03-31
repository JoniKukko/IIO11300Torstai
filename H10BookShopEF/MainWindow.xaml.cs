using System;
using System.Collections.Generic;
using System.Collections.ObjectModel; //for ObservableCollection
using System.ComponentModel;
using System.Data.Entity;
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

namespace H10BookShopEF
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    BookShopEntities ctx;
    public MainWindow()
    {
      InitializeComponent();
      IniMyStuff();
    }

    private void IniMyStuff()
    {
      //tänne kaikki tarvittavat alustukset
      ctx = new BookShopEntities();
    }
    private void btnHaeAsiakkaat_Click(object sender, RoutedEventArgs e)
    {
      //TODO
      var customers = ctx.Customers.ToList();
      dgBooks.DataContext = customers;
    }

    private void btnHaeKirjat_Click(object sender, RoutedEventArgs e)
    {
        //TODO
    }

    private void dgBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      //valittu item (tässä tapauksessa Customer-olio) asetetaan stackpanelin dataconteksiksi
      spCustomer.DataContext = dgBooks.SelectedItem;
    }

    private void btnTallenna_Click(object sender, RoutedEventArgs e)
    {
        //tallennetaan kirjaan tehdyt muutokset kantaan
    }

    private void btnUusi_Click(object sender, RoutedEventArgs e)
    {
        //luodaan uusi kirja-olio ensin kontekstiin ja sitten tietokantaan
    }

    private void btnPoista_Click(object sender, RoutedEventArgs e)
    {
      //poistetaan valittu kirja-olio kontekstiksi ja sitten kannasta
    }

    private void cbCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      //suodatetaan kirjat käyttäjän valinnan mukaan
    }
  }
}

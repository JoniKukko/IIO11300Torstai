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

namespace H9BookshopORM
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void dgBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      //asetetaan stackpanelin datacontekstiksi valittu olio
      spBook.DataContext = dgBooks.SelectedItem;
    }

    private void btnHaeTesti_Click(object sender, RoutedEventArgs e)
    {
      dgBooks.DataContext = Bookshop.GetTestBooks();
    }

    private void btnHaeSQLServer_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        //haetaan kirjat BL-kerroksesta
        dgBooks.DataContext = Bookshop.GetBooks(true);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }    }

    private void btnTallenna_Click(object sender, RoutedEventArgs e)
    {
      //mistä tiedetään mitä muokata --> Book-olion ID:stä!
      try
      {
        Book current = (Book)spBook.DataContext;
        if (Bookshop.UpdateBook(current) > 0)
        {
          tbMessage.Text = string.Format("Kirja {0} päivitetty tietokantaan onnistuneesti", current.ToString());
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }

    }

    private void btnUusi_Click(object sender, RoutedEventArgs e)
    {
      if (btnUusi.Content.ToString() == "Uusi")
      {
        //luodaan uusi kirja -olio
        Book newBook = new Book(0);
        newBook.Name = "Anna kirjan nimi";
        spBook.DataContext = newBook;
        btnUusi.Content = "Tallenna uusi kantaan";
      }
      else
      {
        //tallennetaan
        Book current = (Book)spBook.DataContext;
        Bookshop.InsertBook(current);
        dgBooks.DataContext = Bookshop.GetBooks(true);
        tbMessage.Text = string.Format("Kirja {0} tallennettu kantaan onnistuneesti", current.ToString());
        btnUusi.Content = "Uusi";
      }

    }

    private void btnPoista_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        //poistetaan valittu kirja
        Book current = (Book)spBook.DataContext;
        var retval = MessageBox.Show("Haluatko varmasti poistaa kirjan " + current.ToString(), 
          "Wanhat kirjat kysyy", MessageBoxButton.YesNo);
        if (retval == MessageBoxResult.Yes)
        {
          Bookshop.DeleteBook(current);
          dgBooks.DataContext = Bookshop.GetBooks(true);
          tbMessage.Text = string.Format("Kirja {0} poistettu tietokannasta", current.ToString());
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }
  }
}

using System;
using System.Data.SqlClient;

namespace H7ADONETConsole
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        //1 luodaan yhteys
        string connStr = H7ADONETConsole.Properties.Settings.Default.Tietokanta;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
          //avataan yhteys
          conn.Open();
          //2 luodaan komento ja suoritetaan se
          SqlCommand cmd = new SqlCommand(
 "SELECT asioid, lastname, firstname, date FROM presences WHERE asioid = 'salesa'", conn);
          //3 käydään tulos=Reader-olio läpi
          SqlDataReader rdr = cmd.ExecuteReader();
          //käydään rdr läpi
          if (rdr.HasRows)
          {
            int lkm = 0;
            while (rdr.Read())
            {
              //tulos näkyviin
              Console.WriteLine("Läsnäolosi {0} {1} {2} {3}", 
                rdr.GetString(0), 
                rdr.GetString(1),
                rdr.GetString(2),
                rdr.GetDateTime(3).ToShortDateString());
              lkm++;
            }
            Console.WriteLine("Tulostettu {0} läsnäoloa", lkm);
          }
          //sen minkä avaat muista myös sulkea
          rdr.Close();
          conn.Close();
          Console.WriteLine("Tietoantayhteys suljettu onnistuneesti!");
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      finally
      {
        //Hmm mitä tapahtuu jos ohjelma kaatuu suorituksen aikana,jääkö yhteys sulkematta
        Console.ReadKey();
      }
    }
  }
}

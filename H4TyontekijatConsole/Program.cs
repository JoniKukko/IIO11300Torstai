using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace H4TyontekijatConsole
{
  class Program
  {
    static void CalculateSalarySumFromXML(string filu)
    {
      try
      {
        //tutkitaan onko tiedostoa olemassa
        if (System.IO.File.Exists(filu))
        {
          //luetaan XML-tiedosto XmlDocument-olioon
          XmlDocument xmldoc = new XmlDocument();
          xmldoc.Load(filu);
          //haetaan kaikkien vakituisten työntekijöitten palkka-elementit XPathilla 
          XmlNodeList xnl = xmldoc.SelectNodes
            ("/tyontekijat/tyontekija[tyosuhde='vakituinen']/palkka");
          //loopitetaan nodelista läpi
          int yht = 0;
          for (int i = 0; i < xnl.Count; i++)
          {
            yht += Convert.ToInt32(xnl.Item(i).InnerText);
          }
          Console.WriteLine(string.Format(
            "Vakituisia on {0} ja heidän palkat yhteensä {1} ", 
            xnl.Count, yht));
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    static void ReadWorkersFromXML(string filu)
    {
      try
      {
        //tutkitaan onko tiedostoa olemassa
        if (System.IO.File.Exists(filu))
        {
          //luetaan XML-tiedosto XmlDocument-olioon
          XmlDocument xmldoc = new XmlDocument();
          xmldoc.Load(filu);
          //haetaan kaikki työntekijä-elementit XPathilla 
          XmlNodeList xnl = xmldoc.SelectNodes("/tyontekijat/tyontekija");
          XmlNode xn; //Edustaa yksittäistä noodia 
          XmlNodeList xnl2;
          //loopitetaan nodelista läpi
          for (int i = 0; i < xnl.Count ; i++)
          {
            //näytetään käyttäjälle noodien sisältö
            xn = xnl.Item(i);
            Console.WriteLine(xn.InnerText);
            xnl2 = xn.ChildNodes;
            for (int j = 0; j < xnl2.Count; j++)
            {
              Console.WriteLine(xnl2.Item(j).InnerText);
            }
          }
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    static void Main(string[] args)
    {
      try
      {
        //ReadWorkersFromXML("d:\\Työntekijät2016.xml");
        CalculateSalarySumFromXML("d:\\Työntekijät2016.xml");
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}

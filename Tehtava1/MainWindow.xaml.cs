/*
* Copyright (C) JAMK/IT/Esa Salmikangas
* This file is part of the IIO11300 course project.
* Created: 12.1.2016 Modified: 13.1.2016
* Authors: Esa Salmikangas
*/
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
using JAMK.IT.IIO11300;

namespace JAMK.IT.IIO11300
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

    private void btnCalculate_Click(object sender, RoutedEventArgs e)
    {

      double width;
      double height;
      double frame;
      double perimeter;
      double windowArea;
      double frameArea;
      try
      {
        width = double.Parse(txtWidth.Text);
        height = double.Parse(txtHeight.Text);
        frame = double.Parse(txtFrame.Text);
        perimeter = BusinessLogicWindow.CalculatePerimeter(width, height, frame);
        txtPerimeter.Text = perimeter.ToString("0.##") + " m";
        windowArea = BusinessLogicWindow.CalculateWindowArea(width, height);
        txtWindowArea.Text = windowArea.ToString("0.##") + "m^2";
        frameArea = BusinessLogicWindow.CalculateFrameArea(width, height, frame);
        txtFrameArea.Text = frameArea.ToString("0.##") + "m^2";

      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
      finally
      {
        //yield to an user that everything okay
      }
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
      Application.Current.Shutdown();
    }

    private void btnCalculateOO_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        //olion avulla lasketaan pinta-ala, piiri ja hinta
        //luodaan olio
        Ikkuna ikk = new Ikkuna();
        ikk.Leveys = double.Parse(txtWidth.Text);
        ikk.Korkeus = double.Parse(txtHeight.Text);
        //VE1 pinta-alan laskeminen kutsumalla metodia
        txtWindowArea.Text = ikk.LaskePintaAla().ToString();
        //VE2 pinta-ala on olion ominaisuus
        txtWindowArea.Text = ikk.PintaAla.ToString();

      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }
  }


}
